using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2WalkthroughParser
{
    private static readonly ConcurrentDictionary<string, Regex> MentionPatternCache = new(StringComparer.OrdinalIgnoreCase);

    private static readonly HashSet<string> ValidMagiNames =
    [
        "Prism",
        "Power",
        "Speed",
        "Mana",
        "Defense",
        "Fire",
        "Ice",
        "Thunder",
        "Poison"
    ];

    private static readonly HashSet<string> AmbiguousNames =
    [
        "Human", "Mutant", "Robot", "Monster", "Cure", "Sleep", "Thunder", "Defense", "Speed", "Power", "Mana", "World", "Town", "Tower", "Base", "Sword", "Shield", "Armor"
    ];

    public Ffl2WalkthroughParseResult Parse(string repositoryRoot, IReadOnlyCollection<StoryEntityCandidate> entityCandidates)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "Full Game Guides", "12292_Guide_and_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL2 walkthrough guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var sections = ParseSections(lines).ToList();
        var storyLocations = new List<Ffl2StoryLocationRecord>();
        var storyAppearances = new List<Ffl2EntityStoryAppearanceRecord>();
        var sourceGuide = Path.GetFileName(sourcePath);
        var collectibles = ExtractCollectibles(sections, entityCandidates, sourceGuide);

        foreach (var section in sections)
        {
            var bodyText = NormalizeBody(section.BodyLines);
            var summary = BuildSummary(section.BodyLines);
            var mentions = FindMentions(bodyText, entityCandidates)
                .OrderBy(candidate => candidate.EntityType, StringComparer.OrdinalIgnoreCase)
                .ThenBy(candidate => candidate.EntityName, StringComparer.OrdinalIgnoreCase)
                .ToList();

            foreach (var mention in mentions)
            {
                storyAppearances.Add(new Ffl2EntityStoryAppearanceRecord(
                    section.Order,
                    section.SectionId,
                    section.Title,
                    mention.EntityType,
                    mention.EntityName,
                    "ExplicitMention",
                    sourceGuide));
            }

            storyLocations.Add(new Ffl2StoryLocationRecord(
                section.Order,
                section.SectionId,
                section.Title,
                section.Context,
                ParseWorld(section.Title, section.Context),
                string.Empty,
                summary,
                JoinMentionNames(mentions, "Character"),
                JoinMentionNames(mentions, "Monster"),
                JoinMentionNames(mentions, "Item"),
                JoinMentionNames(mentions, "Equipment"),
                JoinMentionNames(mentions, "Spell"),
                JoinMentionNames(mentions, "Ability"),
                JoinMentionNames(mentions, "StatusEffect"),
                sourceGuide));
        }

        return new Ffl2WalkthroughParseResult(storyLocations, storyAppearances, collectibles);
    }

    private static IReadOnlyList<Ffl2WalkthroughCollectibleRecord> ExtractCollectibles(
        IReadOnlyList<WalkthroughSection> sections,
        IReadOnlyCollection<StoryEntityCandidate> entityCandidates,
        string sourceGuide)
    {
        var collectibleCandidates = entityCandidates
            .Where(candidate => candidate.EntityType is "Equipment" or "Item" or "Spell")
            .ToList();

        var accumulators = new Dictionary<string, CollectibleAccumulator>(StringComparer.OrdinalIgnoreCase);

        foreach (var section in sections)
        {
            foreach (var rawLine in section.BodyLines)
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line) || ShopHeaderRegex().IsMatch(line) || ShopRowRegex().IsMatch(line) || !IsAcquisitionLine(line))
                {
                    continue;
                }

                var normalizedLine = NormalizeAcquisitionLine(line);
                var availability = BuildAvailability(section);
                var note = ClassifyCollectibleNote(line);

                foreach (var candidate in collectibleCandidates)
                {
                    if (GetMentionPattern(candidate.EntityName).IsMatch(normalizedLine))
                    {
                        AddCollectible(accumulators, candidate.EntityType, candidate.EntityName, availability, note, sourceGuide);
                    }
                }

                foreach (var potionName in ExtractPotionNames(normalizedLine))
                {
                    AddCollectible(accumulators, "Item", potionName, availability, note, sourceGuide);
                }

                foreach (var magiName in ExtractMagiNames(line))
                {
                    AddCollectible(accumulators, "Item", magiName, availability, note, sourceGuide);
                }
            }
        }

        return accumulators.Values
            .Select(accumulator => accumulator.ToRecord())
            .OrderBy(row => row.EntityType, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IEnumerable<WalkthroughSection> ParseSections(IEnumerable<string> lines)
    {
        WalkthroughSectionBuilder? current = null;
        string currentTopLevelId = string.Empty;
        string currentTopLevelTitle = string.Empty;
        var order = 0;
        var inWalkthrough = false;

        foreach (var rawLine in lines)
        {
            var line = rawLine.TrimEnd();
            var headingMatch = HeadingRegex().Match(line.Trim());
            if (headingMatch.Success)
            {
                if (current is not null)
                {
                    yield return current.Build();
                }

                inWalkthrough = true;
                currentTopLevelId = headingMatch.Groups["id"].Value;
                currentTopLevelTitle = headingMatch.Groups["title"].Value.Trim();
                current = new WalkthroughSectionBuilder(currentTopLevelId, ++order, currentTopLevelTitle, string.Empty);
                continue;
            }

            if (!inWalkthrough)
            {
                continue;
            }

            var subsectionMatch = SubsectionRegex().Match(line.Trim());
            if (subsectionMatch.Success && !string.IsNullOrWhiteSpace(currentTopLevelTitle))
            {
                if (current is not null)
                {
                    yield return current.Build();
                }

                current = new WalkthroughSectionBuilder(
                    $"{currentTopLevelId}.{subsectionMatch.Groups["sub"].Value}",
                    ++order,
                    subsectionMatch.Groups["title"].Value.Trim(),
                    currentTopLevelTitle);
                continue;
            }

            if (current is not null)
            {
                current.BodyLines.Add(line);
            }
        }

        if (current is not null)
        {
            yield return current.Build();
        }
    }

    private static string NormalizeBody(IEnumerable<string> lines)
    {
        return string.Join(' ', lines.Select(line => line.Trim()))
            .Replace("\t", " ")
            .Replace("  ", " ")
            .Trim();
    }

    private static string BuildSummary(IEnumerable<string> lines)
    {
        var narrativeLines = lines
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Where(line => !ShopHeaderRegex().IsMatch(line))
            .Where(line => !ShopRowRegex().IsMatch(line))
            .Take(10)
            .ToList();

        var summary = WhitespaceRegex().Replace(string.Join(' ', narrativeLines), " ").Trim();
        return summary.Length <= 420 ? summary : summary[..420].TrimEnd() + "...";
    }

    private static IReadOnlyList<StoryEntityCandidate> FindMentions(string bodyText, IReadOnlyCollection<StoryEntityCandidate> entityCandidates)
    {
        var mentions = new List<StoryEntityCandidate>();

        foreach (var candidate in entityCandidates)
        {
            if (!ShouldSearchCandidate(candidate.EntityName))
            {
                continue;
            }

            if (GetMentionPattern(candidate.EntityName).IsMatch(bodyText))
            {
                mentions.Add(candidate);
            }
        }

        return mentions;
    }

    private static bool ShouldSearchCandidate(string entityName)
    {
        if (AmbiguousNames.Contains(entityName))
        {
            return false;
        }

        if (entityName.Length >= 5)
        {
            return true;
        }

        return entityName.Contains(' ') || entityName.Contains('-') || entityName.Contains('.') || entityName.Any(char.IsDigit);
    }

    private static Regex GetMentionPattern(string entityName)
    {
        return MentionPatternCache.GetOrAdd(entityName, static name =>
        {
            var tokens = TokenRegex().Matches(name).Select(match => Regex.Escape(match.Value)).ToArray();
            if (tokens.Length == 0)
            {
                return new Regex("$a", RegexOptions.Compiled);
            }

            var inner = tokens.Length == 1 ? tokens[0] : string.Join("[\\s\\-_']*", tokens);
            return new Regex($@"(?<![A-Za-z0-9]){inner}(?![A-Za-z0-9])", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        });
    }

    private static string JoinMentionNames(IEnumerable<StoryEntityCandidate> mentions, string entityType)
    {
        return string.Join("; ", mentions
            .Where(candidate => candidate.EntityType.Equals(entityType, StringComparison.OrdinalIgnoreCase))
            .Select(candidate => candidate.EntityName)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase));
    }

    private static void AddCollectible(
        IDictionary<string, CollectibleAccumulator> accumulators,
        string entityType,
        string name,
        string availability,
        string note,
        string sourceGuide)
    {
        var key = $"{entityType}|{name}";
        if (!accumulators.TryGetValue(key, out var accumulator))
        {
            accumulator = new CollectibleAccumulator(entityType, name, sourceGuide);
            accumulators[key] = accumulator;
        }

        accumulator.Availabilities.Add(availability);
        accumulator.Notes.Add(note);
    }

    private static string BuildAvailability(WalkthroughSection section)
    {
        return string.IsNullOrWhiteSpace(section.Context)
            ? section.Title
            : $"{section.Context} / {section.Title}";
    }

    private static string ClassifyCollectibleNote(string line)
    {
        if (line.Contains("chest", StringComparison.OrdinalIgnoreCase))
        {
            return "Treasure chest pickup from the walkthrough.";
        }

        if (line.Contains("after the fight", StringComparison.OrdinalIgnoreCase)
            || line.Contains("after beating", StringComparison.OrdinalIgnoreCase)
            || line.Contains("battle", StringComparison.OrdinalIgnoreCase)
            || line.Contains("boss", StringComparison.OrdinalIgnoreCase)
            || line.Contains("Magi:", StringComparison.OrdinalIgnoreCase))
        {
            return "Boss reward or progression pickup from the walkthrough.";
        }

        if (line.Contains("give", StringComparison.OrdinalIgnoreCase) || line.Contains("receive", StringComparison.OrdinalIgnoreCase))
        {
            return "NPC reward or story gift from the walkthrough.";
        }

        return "Walkthrough pickup.";
    }

    private static IEnumerable<string> ExtractMagiNames(string line)
    {
        var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (Match match in ExplicitMagiRegex().Matches(line))
        {
            var normalized = NormalizeName(match.Groups["name"].Value);
            var prefix = normalized.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? string.Empty;
            if (ValidMagiNames.Contains(prefix))
            {
                names.Add($"{prefix} Magi");
            }
        }

        foreach (Match match in ParenthesizedMagiListRegex().Matches(line))
        {
            foreach (var token in SplitMagiList(match.Groups["list"].Value))
            {
                names.Add($"{NormalizeName(token)} Magi");
            }
        }

        foreach (Match match in LabeledMagiListRegex().Matches(line))
        {
            foreach (var token in SplitMagiList(match.Groups["list"].Value))
            {
                names.Add($"{NormalizeName(token)} Magi");
            }
        }

        return names;
    }

    private static IEnumerable<string> ExtractPotionNames(string line)
    {
        return PotionRegex().Matches(line)
            .Select(match => NormalizePotionName(match.Groups["name"].Value))
            .Distinct(StringComparer.OrdinalIgnoreCase);
    }

    private static bool IsAcquisitionLine(string line)
    {
        return AcquisitionCueRegex().IsMatch(line)
               || line.Contains("Magi:", StringComparison.OrdinalIgnoreCase)
               || ParenthesizedMagiListRegex().IsMatch(line)
               || PotionRegex().IsMatch(line);
    }

    private static string NormalizeAcquisitionLine(string line)
    {
        return line
            .Replace("Swords", "Sword", StringComparison.OrdinalIgnoreCase)
            .Replace("Shields", "Shield", StringComparison.OrdinalIgnoreCase)
            .Replace("Helmets", "Helmet", StringComparison.OrdinalIgnoreCase)
            .Replace("Gauntlets", "Gauntlet", StringComparison.OrdinalIgnoreCase)
            .Replace("Potions", "Potion", StringComparison.OrdinalIgnoreCase)
            .Replace("Books", "Book", StringComparison.OrdinalIgnoreCase);
    }

    private static string NormalizeName(string value)
    {
        var tokens = TokenRegex().Matches(value)
            .Select(match => match.Value)
            .ToList();

        return string.Join(" ", tokens.Select(static token =>
            token.Length == 0 ? string.Empty : char.ToUpperInvariant(token[0]) + token[1..].ToLowerInvariant()));
    }

    private static string NormalizePotionName(string value)
    {
        var trimmed = value.Trim();

        if (trimmed.StartsWith("a ", StringComparison.OrdinalIgnoreCase))
        {
            trimmed = trimmed[2..];
        }
        else if (trimmed.StartsWith("an ", StringComparison.OrdinalIgnoreCase))
        {
            trimmed = trimmed[3..];
        }
        else if (trimmed.StartsWith("the ", StringComparison.OrdinalIgnoreCase))
        {
            trimmed = trimmed[4..];
        }

        return NormalizeName(trimmed);
    }

    private static IEnumerable<string> SplitMagiList(string rawList)
    {
        var normalized = rawList
            .Replace(" and ", ",", StringComparison.OrdinalIgnoreCase)
            .Replace('/', ',');

        return normalized
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Where(token => token.Length > 0)
            .Where(token => !token.Contains("list", StringComparison.OrdinalIgnoreCase))
            .Select(NormalizeName)
            .Where(token => ValidMagiNames.Contains(token));
    }

    private static string ParseWorld(string title, string context)
    {
        if (title.Contains("World", StringComparison.OrdinalIgnoreCase))
        {
            return title;
        }

        if (context.Contains("World", StringComparison.OrdinalIgnoreCase))
        {
            return context;
        }

        return string.Empty;
    }

    [GeneratedRegex(@"^\*\*\*(?<id>\d+)\.(?<title>.+?)\*\*\*$", RegexOptions.Compiled)]
    private static partial Regex HeadingRegex();

    [GeneratedRegex(@"^(?<sub>[a-z])\.(?<title>[A-Z].+)$", RegexOptions.Compiled)]
    private static partial Regex SubsectionRegex();

    [GeneratedRegex(@"^Weapons? Shop\s+Item Shop$", RegexOptions.Compiled)]
    private static partial Regex ShopHeaderRegex();

    [GeneratedRegex(@"\s+x(?:-|\d+)\s+\d+\s+GP", RegexOptions.Compiled)]
    private static partial Regex ShopRowRegex();

    [GeneratedRegex(@"\b(get|collect|open the chest|get to|there is|there are|contains?|give you|gives you|receive|received|pick up)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex AcquisitionCueRegex();

    [GeneratedRegex(@"\b(?<name>[A-Za-z]+\sMagi)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex ExplicitMagiRegex();

    [GeneratedRegex(@"Magi[^()]*\((?<list>[A-Za-z,\sand]+)\)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex ParenthesizedMagiListRegex();

    [GeneratedRegex(@"Magi:\s*(?<list>[A-Za-z,\sand]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex LabeledMagiListRegex();

    [GeneratedRegex(@"\b(?<name>[A-Za-z]+(?:\s[A-Za-z]+)?\sPotion)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex PotionRegex();

    [GeneratedRegex(@"[A-Za-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    internal sealed record StoryEntityCandidate(string EntityType, string EntityName);

    private sealed class CollectibleAccumulator(string entityType, string name, string sourceGuide)
    {
        public HashSet<string> Availabilities { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> Notes { get; } = new(StringComparer.OrdinalIgnoreCase);

        public Ffl2WalkthroughCollectibleRecord ToRecord()
        {
            return new Ffl2WalkthroughCollectibleRecord(
                entityType,
                name,
                string.Join("; ", Availabilities.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", Notes.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                sourceGuide);
        }
    }

    private sealed record WalkthroughSection(string SectionId, int Order, string Title, string Context, IReadOnlyList<string> BodyLines);

    private sealed class WalkthroughSectionBuilder(string sectionId, int order, string title, string context)
    {
        public List<string> BodyLines { get; } = [];

        public WalkthroughSection Build()
        {
            return new WalkthroughSection(sectionId, order, title, context, BodyLines.ToList());
        }
    }
}
