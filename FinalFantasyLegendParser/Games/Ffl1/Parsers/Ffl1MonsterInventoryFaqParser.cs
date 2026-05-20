using System.Text.RegularExpressions;
using FinalFantasyLegendParser.Core;

namespace FinalFantasyLegendParser.Games.Ffl1.Parsers;

internal sealed partial class Ffl1MonsterInventoryFaqParser
{
    private static readonly string[] EquipmentPrefixes = ["a", "d", "g", "h", "s"];

    private static readonly string[] InternalPrefixes = ["o", "x"];

    private static readonly HashSet<string> SpellNames =
    [
        "bCURE",
        "bDEATH",
        "bELEC",
        "bFIRE",
        "bFLARE",
        "bFOG",
        "bICE",
        "bSLEEP",
        "bSTONE",
        "ROD",
        "WAND",
        "STAFF",
        "BOOK",
        "TEMPTER"
    ];

    private static readonly HashSet<string> EquipmentNames =
    [
        "s",
        "HAMMER", "AXE", "RAPIER", "ROCK",
        "/KING", "/LONG", "/BATTLE", "/KATANA", "/SILVER", "/CORAL", "/OGRE", "/DRAGON", "/SUN", "/FLAME", "/ICE", "/ELEC", "/DEFEND", "/RUNE", "/XCLBR", "/GLASS", "MASMUNE",
        "SABER", "L-SABER", "CATCRAW", "P-KNIFE", "P-SWORD", "REVENGE", "/VAMPIC",
        "BOW", "LONGBOW", "Gr. BOW", "COLT", "MUSKET", "MAGNUM", "SMG", "GRENADE", "BAZOOKA", "BALKAN", "MISSILE", "NUKE", "HYPER", "LASER",
        "WHIP", "E-WHIP", "SAW",
        "PUNCH", "KICK", "BUTT", "X-KICK", "JUDO", "KARATE", "COUNTER"
    ];

    private static readonly HashSet<string> ConsumableItems =
    [
        "h",
        "POTION", "XPOTION", "NEEDLE", "SYMBOL", "EYEDROP", "REVIVE", "ELIXIR", "ARCANE", "DOOR", "STRONG", "AGILITY", "HP200", "HP400", "HP600",
        "AIRSEED", "RED ORB", "BLUEORB", "ERASE99", "BLUEKEY", "JAILKEY", "WHITKEY", "ROM", "BOARD",
        "ANTDOTE", "BELL", "PAN", "SHOCKER", "HONEY", "CURE", "HEAL", "CARE", "RAISE", "TELEPOR", "LEFT", "RIGHT"
    ];

    public Ffl1InventoryParseResult Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL1", "In-Depth Guides", "21924_Monster_Inventory_FAQ.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL1 monster inventory guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var monsters = ParseMonsters(lines, sourcePath).ToList();
        var inventoryEntries = ParseInventoryEntries(lines).ToList();

        var equipment = new List<Ffl1EquipmentRecord>();
        var items = new List<Ffl1ItemRecord>();
        var abilities = new List<Ffl1AbilityRecord>();

        foreach (var entry in inventoryEntries)
        {
            if (IsInternalEntry(entry))
            {
                continue;
            }

            if (IsEquipment(entry))
            {
                equipment.Add(ToEquipmentRecord(entry, sourcePath));
                continue;
            }

            if (IsItem(entry))
            {
                items.Add(ToItemRecord(entry, sourcePath));
                continue;
            }

            abilities.Add(ToAbilityRecord(entry, sourcePath));
        }

        var statusEffects = BuildStatusEffects(inventoryEntries, sourcePath);
        return new Ffl1InventoryParseResult(monsters, equipment, items, abilities, statusEffects);
    }

    private static IEnumerable<Ffl1MonsterRecord> ParseMonsters(IEnumerable<string> lines, string sourcePath)
    {
        foreach (var line in lines)
        {
            var match = MonsterRegex().Match(line);
            if (!match.Success)
            {
                continue;
            }

            yield return new Ffl1MonsterRecord(
                MonsterName: NameNormalizer.NormalizeMonsterName(match.Groups["name"].Value),
                IndexHex: NormalizeHex(match.Groups["hex"].Value),
                HP: int.Parse(match.Groups["hp"].Value),
                Strength: int.Parse(match.Groups["strength"].Value),
                Agility: int.Parse(match.Groups["agility"].Value),
                Mana: int.Parse(match.Groups["mana"].Value),
                Defense: int.Parse(match.Groups["defense"].Value),
                Gold: int.Parse(match.Groups["gold"].Value),
                Resistances: ElementCodec.DecodeFlags(match.Groups["resistances"].Value),
                Weaknesses: ElementCodec.DecodeFlags(match.Groups["weaknesses"].Value),
                MonsterFamily: match.Groups["family"].Value.Trim(),
                SourceGuide: Path.GetFileName(sourcePath));
        }
    }

    private static IEnumerable<InventoryEntry> ParseInventoryEntries(IEnumerable<string> lines)
    {
        var inInventorySection = false;

        foreach (var line in lines)
        {
            if (line.Contains("Section 4.2 Inventory listing, alphabetical order", StringComparison.Ordinal))
            {
                inInventorySection = true;
                continue;
            }

            if (inInventorySection && line.Contains("Appendix A - Character bytes", StringComparison.Ordinal))
            {
                yield break;
            }

            if (!inInventorySection || string.IsNullOrWhiteSpace(line) || line.StartsWith('-'))
            {
                continue;
            }

            if (TryParseInventoryEntry(line, out var entry))
            {
                yield return entry;
            }
        }
    }

    private static bool TryParseInventoryEntry(string line, out InventoryEntry entry)
    {
        entry = default!;

        var countMatch = InventoryEntryRegex().Match(line);

        if (!countMatch.Success)
        {
            return false;
        }

        var rawName = countMatch.Groups["name"].Value.TrimEnd();

        var attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var rest = countMatch.Groups["rest"].Value;

        foreach (Match match in AttributeRegex().Matches(rest))
        {
            attributes[match.Groups["label"].Value.Trim()] = match.Groups["value"].Value.Trim();
        }

        var descriptorText = AttributeRegex().Replace(rest, " ");
        var tokens = descriptorText.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        entry = new InventoryEntry(
            RawName: rawName,
            DisplayName: NameNormalizer.NormalizeInventoryName(rawName),
            Uses: countMatch.Groups["count"].Value.Trim(),
            IndexHex: NormalizeHex(countMatch.Groups["hex"].Value),
            Availability: string.Join("; ", tokens.Where(token => token is "Combat" or "World")),
            Targeting: string.Join("; ", tokens.Where(token => token is "Melee" or "Friend" or "Party" or "Group" or "Enemy" or "All" or "Self" or "Counter")),
            Attributes: attributes);

        return true;
    }

    private static bool IsInternalEntry(InventoryEntry entry)
    {
        var rawName = entry.RawName;
        return InternalPrefixes.Any(prefix => rawName.StartsWith(prefix, StringComparison.Ordinal) && rawName.Length > 1 && char.IsUpper(rawName[1]));
    }

    private static bool IsEquipment(InventoryEntry entry)
    {
        var rawName = entry.RawName;

        if (EquipmentPrefixes.Any(prefix => rawName.StartsWith(prefix, StringComparison.Ordinal) && rawName.Length > 1 && char.IsUpper(rawName[1])))
        {
            return true;
        }

        if (EquipmentNames.Contains(rawName))
        {
            return true;
        }

        return false;
    }

    private static bool IsItem(InventoryEntry entry)
    {
        if (SpellNames.Contains(entry.RawName))
        {
            return true;
        }

        if (ConsumableItems.Contains(entry.RawName))
        {
            return true;
        }

        return false;
    }

    private static Ffl1EquipmentRecord ToEquipmentRecord(InventoryEntry entry, string sourcePath)
    {
        var category = DetermineEquipmentCategory(entry.RawName);
        return new Ffl1EquipmentRecord(
            Category: category,
            Name: entry.DisplayName,
            Uses: entry.Uses,
            IndexHex: entry.IndexHex,
            Availability: entry.Availability,
            Targeting: entry.Targeting,
            PrimaryEffect: ExtractPrimaryEffect(entry),
            SecondaryEffect: ExtractSecondaryEffect(entry),
            Notes: BuildNotes(entry),
            SourceGuide: Path.GetFileName(sourcePath));
    }

    private static Ffl1ItemRecord ToItemRecord(InventoryEntry entry, string sourcePath)
    {
        var category = SpellNames.Contains(entry.RawName) ? "Spell/Book" : "Item";
        return new Ffl1ItemRecord(
            Category: category,
            Name: entry.DisplayName,
            Uses: entry.Uses,
            IndexHex: entry.IndexHex,
            Availability: entry.Availability,
            Targeting: entry.Targeting,
            PrimaryEffect: ExtractPrimaryEffect(entry),
            SecondaryEffect: ExtractSecondaryEffect(entry),
            Notes: BuildNotes(entry),
            SourceGuide: Path.GetFileName(sourcePath));
    }

    private static Ffl1AbilityRecord ToAbilityRecord(InventoryEntry entry, string sourcePath)
    {
        return new Ffl1AbilityRecord(
            Name: entry.DisplayName,
            Uses: entry.Uses,
            IndexHex: entry.IndexHex,
            Availability: entry.Availability,
            Targeting: entry.Targeting,
            PrimaryEffect: ExtractPrimaryEffect(entry),
            SecondaryEffect: ExtractSecondaryEffect(entry),
            Notes: BuildNotes(entry),
            SourceGuide: Path.GetFileName(sourcePath));
    }

    private static IReadOnlyList<Ffl1StatusEffectRecord> BuildStatusEffects(IEnumerable<InventoryEntry> entries, string sourcePath)
    {
        var effects = new Dictionary<string, StatusAccumulator>(StringComparer.OrdinalIgnoreCase);

        foreach (var entry in entries)
        {
            if (entry.Attributes.TryGetValue("Status", out var appliedStatus))
            {
                var normalizedStatus = NameNormalizer.NormalizeStatus(appliedStatus);
                var accumulator = GetOrCreate(effects, normalizedStatus);
                accumulator.AppliedBy.Add(entry.DisplayName);

                if (entry.Attributes.TryGetValue("Elem", out var elementFlags))
                {
                    accumulator.RelatedElements.Add(ElementCodec.DecodeFlags(elementFlags));
                }
            }

            if (entry.Attributes.TryGetValue("Remove", out var curedStatus))
            {
                var normalizedStatus = NameNormalizer.NormalizeStatus(curedStatus);
                var accumulator = GetOrCreate(effects, normalizedStatus);
                accumulator.CuredBy.Add(entry.DisplayName);
            }
        }

        return effects
            .OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase)
            .Select(pair => new Ffl1StatusEffectRecord(
                StatusEffect: pair.Key,
                AppliedBy: string.Join("; ", pair.Value.AppliedBy.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                CuredBy: string.Join("; ", pair.Value.CuredBy.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                RelatedElements: string.Join("; ", pair.Value.RelatedElements.Where(value => !string.IsNullOrWhiteSpace(value)).OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                Notes: string.Empty,
                SourceGuide: Path.GetFileName(sourcePath)))
            .ToList();
    }

    private static string DetermineEquipmentCategory(string rawName)
    {
        return rawName switch
        {
            var value when value.StartsWith("a", StringComparison.Ordinal) => "Armor",
            var value when value.StartsWith("d", StringComparison.Ordinal) => "Shield",
            var value when value.StartsWith("g", StringComparison.Ordinal) => "Gauntlet",
            var value when value.StartsWith("h", StringComparison.Ordinal) => "Helmet",
            var value when value.StartsWith("s", StringComparison.Ordinal) => "Shoes",
            "BOW" or "LONGBOW" or "Gr. BOW" => "Bow",
            "COLT" or "MUSKET" or "MAGNUM" or "SMG" or "GRENADE" or "BAZOOKA" or "BALKAN" or "MISSILE" or "NUKE" or "HYPER" or "LASER" or "ROCK" => "Ranged Weapon",
            "WHIP" or "E-WHIP" => "Whip",
            "PUNCH" or "KICK" or "BUTT" or "X-KICK" or "JUDO" or "KARATE" or "COUNTER" => "Martial Weapon",
            _ => "Weapon"
        };
    }

    private static string ExtractPrimaryEffect(InventoryEntry entry)
    {
        foreach (var key in new[] { "Defense", "Str-Atk", "Agi-Atk", "Man-Atk", "Drain-Atk", "Man-Pwr", "Gun-Dam", "Bow-Dam", "Whp-Dam", "Heal", "Status", "Remove", "Prot", "Weak", "Resi", "Elem", "#Atk", "???-Atk" })
        {
            if (entry.Attributes.TryGetValue(key, out var value))
            {
                return FormatEffect(key, value);
            }
        }

        return string.Empty;
    }

    private static string ExtractSecondaryEffect(InventoryEntry entry)
    {
        var parts = new List<string>();

        foreach (var pair in entry.Attributes)
        {
            if (pair.Key is "Defense" or "Str-Atk" or "Agi-Atk" or "Man-Atk" or "Drain-Atk" or "Man-Pwr" or "Gun-Dam" or "Bow-Dam" or "Whp-Dam" or "Heal" or "Status" or "Remove" or "Prot" or "Weak" or "Resi" or "Elem" or "#Atk" or "???-Atk")
            {
                continue;
            }

            parts.Add(FormatEffect(pair.Key, pair.Value));
        }

        return string.Join("; ", parts);
    }

    private static string BuildNotes(InventoryEntry entry)
    {
        var notes = new List<string>();

        if (entry.Attributes.TryGetValue("Elem", out var elementFlags))
        {
            var decoded = ElementCodec.DecodeFlags(elementFlags);
            if (!string.IsNullOrWhiteSpace(decoded))
            {
                notes.Add($"Element: {decoded}");
            }
        }

        if (entry.Attributes.TryGetValue("Resi", out var resistanceFlags))
        {
            var decoded = ElementCodec.DecodeFlags(resistanceFlags);
            if (!string.IsNullOrWhiteSpace(decoded))
            {
                notes.Add($"Resists: {decoded}");
            }
        }

        if (entry.Attributes.TryGetValue("Weak", out var weaknessFlags))
        {
            var decoded = ElementCodec.DecodeFlags(weaknessFlags);
            if (!string.IsNullOrWhiteSpace(decoded))
            {
                notes.Add($"Weak to: {decoded}");
            }
        }

        return string.Join("; ", notes);
    }

    private static string FormatEffect(string key, string value)
    {
        return key switch
        {
            "Status" => $"Inflicts {NameNormalizer.NormalizeStatus(value)}",
            "Remove" => $"Cures {NameNormalizer.NormalizeStatus(value)}",
            "Elem" => $"Element {ElementCodec.DecodeFlags(value)}",
            "Resi" => $"Resists {ElementCodec.DecodeFlags(value)}",
            "Weak" => $"Weak to {ElementCodec.DecodeFlags(value)}",
            _ => $"{key} {value}".Trim()
        };
    }

    private static StatusAccumulator GetOrCreate(Dictionary<string, StatusAccumulator> effects, string status)
    {
        if (!effects.TryGetValue(status, out var accumulator))
        {
            accumulator = new StatusAccumulator();
            effects[status] = accumulator;
        }

        return accumulator;
    }

    private static string NormalizeHex(string rawHex)
    {
        return rawHex.Trim().PadLeft(2, '0').ToUpperInvariant();
    }

    [GeneratedRegex(@"^(?<name>.+?)\s+\[(?<hex>[0-9A-Fa-f ]{1,2})\]\s+hp\s+(?<hp>\d+)\.\s+(?<strength>\d+)\/\s*(?<agility>\d+)\/\s*(?<mana>\d+)\/\s*(?<defense>\d+)\.\s+au\s+(?<gold>\d+)\.\s+r(?<resistances>[A-Z\-]{8})\s+w(?<weaknesses>[A-Z\-]{8})(?:\s+(?<family>.+))?$", RegexOptions.Compiled)]
    private static partial Regex MonsterRegex();

    [GeneratedRegex(@"^(?<name>.+?)(?<count>-|\d+)\s+\[(?<hex>[0-9A-Fa-f ]{1,2})\](?<rest>.*)$", RegexOptions.Compiled)]
    private static partial Regex InventoryEntryRegex();

    [GeneratedRegex(@"(?<label>[A-Za-z0-9#/\-!?+]+):\s*(?<value>.*?)(?=(?:\s+[A-Za-z0-9#/\-!?+]+:\s)|$)", RegexOptions.Compiled)]
    private static partial Regex AttributeRegex();

    private sealed record InventoryEntry(
        string RawName,
        string DisplayName,
        string Uses,
        string IndexHex,
        string Availability,
        string Targeting,
        IReadOnlyDictionary<string, string> Attributes);

    private sealed class StatusAccumulator
    {
        public HashSet<string> AppliedBy { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> CuredBy { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> RelatedElements { get; } = new(StringComparer.OrdinalIgnoreCase);
    }
}
