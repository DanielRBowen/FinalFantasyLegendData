using System.Globalization;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl3.Parsers;

internal sealed partial class Ffl3GameListsParser
{
    public Ffl3GuideData Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL3", "In-Depth Guides", "47306_Game_Lists.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL3 game-lists guide.", sourcePath);
        }

        var sourceGuide = Path.GetFileName(sourcePath);
        var lines = File.ReadAllLines(sourcePath);
        var spells = ParseSpells(lines, sourceGuide).ToList();

        return new Ffl3GuideData(
            ParseEquipment(lines, sourceGuide).ToList(),
            spells,
            ParseAbilities(lines, sourceGuide).ToList(),
            ParseStatusEffects(lines, spells, sourceGuide).ToList(),
            ParseCharacters(lines, sourceGuide).ToList(),
            ParseMonsters(lines, sourceGuide).ToList());
    }

    private static IEnumerable<Ffl3EquipmentRecord> ParseEquipment(IEnumerable<string> lines, string sourceGuide)
    {
        var currentMainSection = string.Empty;
        var currentSubsection = string.Empty;
        var currentType = string.Empty;
        var weaponsSectionCount = 0;
        var armorSectionCount = 0;
        var magicSectionCount = 0;

        foreach (var rawLine in lines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.Equals("II. WEAPONS", StringComparison.Ordinal))
            {
                weaponsSectionCount++;
                if (weaponsSectionCount >= 2)
                {
                    currentMainSection = "Weapons";
                    currentSubsection = string.Empty;
                    currentType = string.Empty;
                }

                continue;
            }

            if (trimmed.Equals("III. ARMOR", StringComparison.Ordinal))
            {
                armorSectionCount++;
                if (armorSectionCount >= 2)
                {
                    currentMainSection = "Armor";
                    currentSubsection = string.Empty;
                    currentType = string.Empty;
                }

                continue;
            }

            if (trimmed.Equals("IV. MAGIC", StringComparison.Ordinal))
            {
                magicSectionCount++;
                if (magicSectionCount >= 2)
                {
                    yield break;
                }

                continue;
            }

            if (string.IsNullOrWhiteSpace(currentMainSection))
            {
                continue;
            }

            var subsectionMatch = SubsectionRegex().Match(trimmed);
            if (subsectionMatch.Success)
            {
                currentSubsection = NormalizeTitle(subsectionMatch.Groups["title"].Value);
                currentType = string.Empty;
                continue;
            }

            if (trimmed.StartsWith("Type:", StringComparison.Ordinal))
            {
                currentType = NormalizeTitle(trimmed[5..].Trim());
                continue;
            }

            var columns = SplitColumns(trimmed);
            if (!IsEquipmentRow(columns, currentMainSection, currentSubsection, currentType))
            {
                continue;
            }

            var details = currentMainSection.Equals("Weapons", StringComparison.Ordinal)
                ? BuildWeaponDetails(currentSubsection, columns.Skip(2).ToArray())
                : BuildArmorDetails(currentSubsection, columns.Skip(2).ToArray());

            yield return new Ffl3EquipmentRecord(
                currentMainSection,
                string.IsNullOrWhiteSpace(currentType) ? currentSubsection : $"{currentSubsection} / {currentType}",
                columns[0],
                columns[1],
                details,
                sourceGuide);
        }
    }

    private static IEnumerable<Ffl3SpellRecord> ParseSpells(IEnumerable<string> lines, string sourceGuide)
    {
        var inMagic = false;
        var currentSubsection = string.Empty;
        var magicSectionCount = 0;
        var talentSectionCount = 0;

        foreach (var rawLine in lines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.Equals("V. TALENTS", StringComparison.Ordinal))
            {
                talentSectionCount++;
                if (inMagic && talentSectionCount >= 2)
                {
                    yield break;
                }

                if (!inMagic)
                {
                    continue;
                }
            }

            if (trimmed.Equals("IV. MAGIC", StringComparison.Ordinal))
            {
                magicSectionCount++;
                inMagic = magicSectionCount >= 2;
                continue;
            }

            if (!inMagic)
            {
                continue;
            }

            var subsectionMatch = SubsectionRegex().Match(trimmed);
            if (subsectionMatch.Success)
            {
                currentSubsection = NormalizeTitle(subsectionMatch.Groups["title"].Value);
                continue;
            }

            if (currentSubsection.Equals("Item Magic", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var columns = SplitColumns(trimmed);
            if (!IsSpellRow(columns))
            {
                continue;
            }

            var details = currentSubsection switch
            {
                "Attack Magic" => FormatLabeledDetails(columns.Skip(3).ToArray(), ["SP", "Target", "Property"]),
                "Support Magic" => FormatLabeledDetails(columns.Skip(3).ToArray(), ["Target", "Effect"]),
                "Travel Magic" => FormatLabeledDetails(columns.Skip(3).ToArray(), ["Effect"]),
                _ => string.Join("; ", columns.Skip(3))
            };

            yield return new Ffl3SpellRecord(currentSubsection, columns[0], columns[1], columns[2], details, sourceGuide);
        }
    }

    private static IEnumerable<Ffl3AbilityRecord> ParseAbilities(IEnumerable<string> lines, string sourceGuide)
    {
        var inTalents = false;
        var currentType = string.Empty;
        var talentSectionCount = 0;
        var statsSectionCount = 0;

        foreach (var rawLine in lines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.Equals("VI. STATS & UPGRADES", StringComparison.Ordinal))
            {
                statsSectionCount++;
                if (inTalents && statsSectionCount >= 2)
                {
                    yield break;
                }

                if (!inTalents)
                {
                    continue;
                }
            }

            if (trimmed.Equals("V. TALENTS", StringComparison.Ordinal))
            {
                talentSectionCount++;
                inTalents = talentSectionCount >= 2;
                continue;
            }

            if (!inTalents)
            {
                continue;
            }

            if (trimmed.StartsWith("Type:", StringComparison.Ordinal))
            {
                currentType = NormalizeTitle(trimmed[5..].Trim());
                continue;
            }

            if (string.IsNullOrWhiteSpace(currentType))
            {
                continue;
            }

            var columns = SplitColumns(trimmed);
            if (!IsAbilityRow(columns))
            {
                continue;
            }

            var details = currentType.Equals("Passive Talents", StringComparison.OrdinalIgnoreCase)
                ? FormatLabeledDetails(columns.Skip(1).ToArray(), ["Effect"])
                : FormatLabeledDetails(columns.Skip(1).ToArray(), ["TP", "Base", "Target", "Property", "Other"]);

            yield return new Ffl3AbilityRecord(currentType, columns[0], details, sourceGuide);
        }
    }

    private static IEnumerable<Ffl3StatusEffectRecord> ParseStatusEffects(IEnumerable<string> lines, IReadOnlyList<Ffl3SpellRecord> spells, string sourceGuide)
    {
        var inStatusSection = false;
        var statusSectionCount = 0;
        var othersSectionCount = 0;
        string? currentStatus = null;
        var descriptionParts = new List<string>();

        foreach (var rawLine in lines)
        {
            var trimmedEnd = rawLine.TrimEnd();
            var trimmed = trimmedEnd.Trim();

            if (trimmed.Equals("2. STATUS CONDITIONS", StringComparison.Ordinal))
            {
                statusSectionCount++;
                inStatusSection = statusSectionCount >= 2;
                continue;
            }

            if (trimmed.Equals("3. OTHERS", StringComparison.Ordinal))
            {
                othersSectionCount++;
                if (!inStatusSection || othersSectionCount < 2)
                {
                    continue;
                }

                if (currentStatus is not null)
                {
                    var record = BuildStatusRecord(currentStatus, descriptionParts, spells, sourceGuide);
                    if (record.StatusEffect is not "Normal")
                    {
                        yield return record;
                    }
                }

                yield break;
            }

            if (!inStatusSection)
            {
                continue;
            }

            var match = StatusRegex().Match(trimmed);
            if (match.Success)
            {
                if (currentStatus is not null)
                {
                    yield return BuildStatusRecord(currentStatus, descriptionParts, spells, sourceGuide);
                }

                currentStatus = NormalizeStatusName(match.Groups["status"].Value.Trim());
                descriptionParts.Clear();
                descriptionParts.Add(match.Groups["description"].Value.Trim());
                continue;
            }

            if (currentStatus is not null && !string.IsNullOrWhiteSpace(trimmed) && rawLine.Length > 0 && char.IsWhiteSpace(rawLine, 0))
            {
                descriptionParts.Add(trimmed);
            }
        }

        if (currentStatus is not null)
        {
            var record = BuildStatusRecord(currentStatus, descriptionParts, spells, sourceGuide);
            if (record.StatusEffect is not "Normal")
            {
                yield return record;
            }
        }
    }

    private static Ffl3StatusEffectRecord BuildStatusRecord(string statusName, IReadOnlyCollection<string> descriptionParts, IReadOnlyList<Ffl3SpellRecord> spells, string sourceGuide)
    {
        var description = string.Join(' ', descriptionParts).Trim();
        var notes = FindRelatedSpells(statusName, spells);
        return new Ffl3StatusEffectRecord(statusName, description, notes, sourceGuide);
    }

    private static IEnumerable<Ffl3MonsterRecord> ParseMonsters(IEnumerable<string> lines, string sourceGuide)
    {
        var inSpeciesSection = false;
        var speciesSectionCount = 0;
        var statsSectionCount = 0;
        var currentCategory = string.Empty;

        foreach (var rawLine in lines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.Equals("2. DETERMINING NEW SPECIES", StringComparison.Ordinal))
            {
                speciesSectionCount++;
                inSpeciesSection = speciesSectionCount >= 2;
                continue;
            }

            if (trimmed.Equals("3. DETERMINING NEW STATS", StringComparison.Ordinal))
            {
                statsSectionCount++;
                if (inSpeciesSection && statsSectionCount >= 2)
                {
                    yield break;
                }

                continue;
            }

            if (!inSpeciesSection)
            {
                continue;
            }

            if (trimmed is "Monsters" or "Beasts" or "Cyborgs" or "Robots")
            {
                currentCategory = trimmed;
                continue;
            }

            var columns = SplitColumns(trimmed);
            if (!IsSpeciesRow(columns))
            {
                continue;
            }

            var levelRange = columns[0].Replace(" ", string.Empty, StringComparison.Ordinal);
            if (currentCategory is "Monsters" or "Beasts")
            {
                var elements = new[] { "Earth", "Water", "Fire", "Air" };
                for (var index = 0; index < elements.Length && columns.Length > index + 1; index++)
                {
                    var name = columns[index + 1];
                    if (name.Equals("Removed", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    yield return new Ffl3MonsterRecord(name, currentCategory, levelRange, elements[index], string.Empty, sourceGuide);
                }

                continue;
            }

            var dualElements = new[] { "Earth/Water", "Fire/Air" };
            for (var index = 0; index < dualElements.Length && columns.Length > index + 1; index++)
            {
                var name = columns[index + 1];
                if (name.Equals("Removed", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                yield return new Ffl3MonsterRecord(name, currentCategory, levelRange, dualElements[index], string.Empty, sourceGuide);
            }
        }
    }

    private static IEnumerable<Ffl3CharacterRecord> ParseCharacters(IEnumerable<string> lines, string sourceGuide)
    {
        var inCharacters = false;
        var charactersSectionCount = 0;
        string? pendingName = null;

        foreach (var rawLine in lines)
        {
            var trimmed = rawLine.Trim();

            if (!inCharacters)
            {
                if (trimmed.Equals("IX. CHARACTERS", StringComparison.Ordinal))
                {
                    charactersSectionCount++;
                    inCharacters = charactersSectionCount >= 2;
                }

                continue;
            }

            if (NameLineRegex().IsMatch(trimmed))
            {
                pendingName = trimmed;
                continue;
            }

            if (pendingName is null)
            {
                continue;
            }

            var summaryMatch = CharacterSummaryRegex().Match(trimmed);
            if (!summaryMatch.Success)
            {
                continue;
            }

            var startingClass = summaryMatch.Groups["class"].Value.Trim();
            var innateElement = summaryMatch.Groups["element"].Value.Trim();
            yield return new Ffl3CharacterRecord(
                pendingName,
                "Main Character",
                startingClass,
                innateElement,
                $"Starts as a {startingClass} with innate {innateElement} element.",
                sourceGuide);

            pendingName = null;
        }
    }

    private static bool IsEquipmentRow(IReadOnlyList<string> columns, string currentMainSection, string currentSubsection, string currentType)
    {
        if (columns.Count < 4)
        {
            return false;
        }

        if (columns[0].Equals("Name", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Skill", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Damage", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Item", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Capsule", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (currentMainSection.Equals("Weapons", StringComparison.Ordinal))
        {
            if (string.IsNullOrWhiteSpace(currentType) && !currentSubsection.Equals("Martial Arts", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (currentSubsection.Equals("Martial Arts", StringComparison.OrdinalIgnoreCase)
                && columns[0].Equals("Martial arts", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }

        return IsNumberOrDash(columns[1]);
    }

    private static bool IsSpellRow(IReadOnlyList<string> columns)
    {
        if (columns.Count < 4)
        {
            return false;
        }

        if (columns[0].Equals("Name", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Skill", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Damage", StringComparison.OrdinalIgnoreCase)
            || columns[0].Equals("Item", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return IsNumberOrDash(columns[1]);
    }

    private static bool IsAbilityRow(IReadOnlyList<string> columns)
    {
        if (columns.Count < 2)
        {
            return false;
        }

        return !columns[0].Equals("Talent", StringComparison.OrdinalIgnoreCase)
               && !columns[0].Equals("Skill", StringComparison.OrdinalIgnoreCase)
               && !columns[0].Equals("Damage", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsSpeciesRow(IReadOnlyList<string> columns)
    {
        return columns.Count >= 3 && LevelRangeRegex().IsMatch(columns[0]);
    }

    private static string BuildWeaponDetails(string subsection, string[] columns)
    {
        var labels = subsection switch
        {
            "Melee Weapons" => new[] { "WP", "Cyb HP+", "Property", "Item/Other", "Bonus" },
            "Missile Weapons" => new[] { "WP", "Cyb HP+", "Property", "Bonus" },
            "Martial Arts" => new[] { "WP", "Cyb HP+", "Property", "Bonus" },
            "Fixed Damage Weapons" => new[] { "WP", "Cyb HP+", "Target", "Property", "Bonus" },
            _ => Array.Empty<string>()
        };

        return FormatLabeledDetails(columns, labels);
    }

    private static string BuildArmorDetails(string subsection, string[] columns)
    {
        var labels = subsection switch
        {
            "Shields" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb HP+", "Resist", "Bonus" },
            "Helmets" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb HP+", "Resist", "Item Magic", "Bonus" },
            "Armor" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb HP+", "Resist", "Bonus" },
            "Gloves" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb MP+", "Resist", "Bonus" },
            "Shoes" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb MP+", "Resist", "Bonus" },
            "Other" => new[] { "Def", "Evd", "MDef", "MEvd", "Cyb HP+", "Resist", "Item Magic", "Bonus" },
            _ => Array.Empty<string>()
        };

        return FormatLabeledDetails(columns, labels);
    }

    private static string FormatLabeledDetails(IReadOnlyList<string> values, IReadOnlyList<string> labels)
    {
        if (values.Count == 0)
        {
            return string.Empty;
        }

        var parts = new List<string>();
        for (var index = 0; index < values.Count; index++)
        {
            var label = index < labels.Count ? labels[index] : $"Extra {index - labels.Count + 1}";
            parts.Add($"{label}: {values[index]}");
        }

        return string.Join("; ", parts);
    }

    private static string FindRelatedSpells(string statusName, IEnumerable<Ffl3SpellRecord> spells)
    {
        var keywords = statusName switch
        {
            "Paralysis" => new[] { "Para", "Paralyze" },
            "Petrify" => new[] { "Stone" },
            "Confuse" => new[] { "Conf" },
            _ => new[] { statusName }
        };

        var names = spells
            .Where(spell => keywords.Any(keyword => spell.Details.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            .Select(spell => spell.Name)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        return names.Count == 0 ? string.Empty : $"Related spells: {string.Join("; ", names)}";
    }

    private static string NormalizeTitle(string title)
    {
        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(title.ToLowerInvariant());
    }

    private static string NormalizeStatusName(string raw)
    {
        return raw switch
        {
            "Good" => "Normal",
            "Paralysis (Para)" => "Paralysis",
            "Petrify (Stone)" => "Petrify",
            _ => raw
        };
    }

    private static string[] SplitColumns(string line)
    {
        return ColumnSeparatorRegex().Split(line.Trim()).Where(part => !string.IsNullOrWhiteSpace(part)).ToArray();
    }

    private static bool IsNumberOrDash(string value)
    {
        return value.Equals("-", StringComparison.Ordinal) || int.TryParse(value, out _);
    }

    [GeneratedRegex(@"^\d+\.\s+(?<title>.+)$", RegexOptions.Compiled)]
    private static partial Regex SubsectionRegex();

    [GeneratedRegex(@"^(?<status>[^:]+):\s*(?<description>.+)$", RegexOptions.Compiled)]
    private static partial Regex StatusRegex();

    [GeneratedRegex(@"^\d+\s*-\s*\d+$", RegexOptions.Compiled)]
    private static partial Regex LevelRangeRegex();

    [GeneratedRegex(@"^[A-Z][a-z]+$", RegexOptions.Compiled)]
    private static partial Regex NameLineRegex();

    [GeneratedRegex(@"^L\d+,\s*(?<class>[^,]+),\s*innate element:\s*(?<element>.+)$", RegexOptions.Compiled)]
    private static partial Regex CharacterSummaryRegex();

    [GeneratedRegex(@"\s{2,}", RegexOptions.Compiled)]
    private static partial Regex ColumnSeparatorRegex();
}
