using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl3.Parsers;

internal sealed partial class Ffl3WalkthroughParser
{
    private static readonly ConcurrentDictionary<string, Regex> MentionPatternCache = new(StringComparer.OrdinalIgnoreCase);

    private static readonly (string Name, string Category)[] KeyItems =
    [
        ("Past Unit", "Key Item"),
        ("Flushex Unit", "Key Item"),
        ("Rover Unit", "Key Item"),
        ("Tower Key", "Key Item"),
        ("Air Crystal", "Key Item"),
        ("Water Crystal", "Key Item"),
        ("Future Unit", "Key Item"),
        ("Hover Unit", "Key Item"),
        ("Radio", "Key Item"),
        ("Remote", "Key Item"),
        ("Firestar", "Key Item")
    ];

    private static readonly HashSet<string> AmbiguousNames =
    [
        "Human", "Mutant", "Cyborg", "Robot", "Monster", "Beast", "Guard", "Laser", "Shield", "Sleep", "Float", "Dive", "Morph", "Future", "Past", "Hover", "Damage", "Attack", "Defense", "Magic", "City", "Tower", "Cave", "Castle"
    ];

    public Ffl3WalkthroughParseResult Parse(string repositoryRoot, IReadOnlyCollection<StoryEntityCandidate> baseEntityCandidates)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL3", "In-Depth Guides", "80317_Glitchless_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL3 walkthrough guide.", sourcePath);
        }

        var sourceGuide = Path.GetFileName(sourcePath);
        var lines = File.ReadAllLines(sourcePath);
        var sections = ParseSections(lines).ToList();
        var items = ExtractItems(sections, sourceGuide);
        var allCandidates = baseEntityCandidates
            .Concat(items.Select(item => new StoryEntityCandidate("Item", item.Name)))
            .GroupBy(candidate => $"{candidate.EntityType}|{candidate.EntityName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();

        var storyLocations = new List<Ffl3StoryLocationRecord>();
        var storyAppearances = new List<Ffl3EntityStoryAppearanceRecord>();

        foreach (var section in sections)
        {
            var bodyText = NormalizeBody(section.BodyLines);
            var summary = BuildSummary(section.BodyLines);
            var mentions = FindMentions(bodyText, allCandidates)
                .OrderBy(candidate => candidate.EntityType, StringComparer.OrdinalIgnoreCase)
                .ThenBy(candidate => candidate.EntityName, StringComparer.OrdinalIgnoreCase)
                .ToList();

            foreach (var mention in mentions)
            {
                storyAppearances.Add(new Ffl3EntityStoryAppearanceRecord(
                    section.Order,
                    section.SectionId,
                    section.Title,
                    mention.EntityType,
                    mention.EntityName,
                    "ExplicitMention",
                    sourceGuide));
            }

            storyLocations.Add(new Ffl3StoryLocationRecord(
                section.Order,
                section.SectionId,
                section.Title,
                string.Empty,
                ParseWorld(section.Title),
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

        return new Ffl3WalkthroughParseResult(items, storyLocations, storyAppearances);
    }

    private static IReadOnlyList<Ffl3ItemRecord> ExtractItems(IReadOnlyList<WalkthroughSection> sections, string sourceGuide)
    {
        var itemsByName = new Dictionary<string, Ffl3ItemRecord>(StringComparer.OrdinalIgnoreCase);

        foreach (var section in sections)
        {
            var bodyText = NormalizeBody(section.BodyLines);

            foreach (var keyItem in KeyItems)
            {
                if (!GetMentionPattern(keyItem.Name).IsMatch(bodyText))
                {
                    continue;
                }

                itemsByName.TryAdd(
                    keyItem.Name,
                    new Ffl3ItemRecord(keyItem.Category, keyItem.Name, section.Title, "Referenced in walkthrough progression.", sourceGuide));
            }

            if (bodyText.Contains("Future and Hover units", StringComparison.OrdinalIgnoreCase))
            {
                itemsByName.TryAdd("Future Unit", new Ffl3ItemRecord("Key Item", "Future Unit", section.Title, "Referenced in walkthrough progression.", sourceGuide));
                itemsByName.TryAdd("Hover Unit", new Ffl3ItemRecord("Key Item", "Hover Unit", section.Title, "Referenced in walkthrough progression.", sourceGuide));
            }

            foreach (Match match in ConsumableRegex().Matches(bodyText))
            {
                var normalizedName = NormalizeConsumable(match.Groups["name"].Value);
                itemsByName.TryAdd(
                    normalizedName,
                    new Ffl3ItemRecord("Consumable", normalizedName, section.Title, "Bought or used during the walkthrough.", sourceGuide));
            }
        }

        return itemsByName.Values
            .OrderBy(item => item.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(item => item.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IEnumerable<WalkthroughSection> ParseSections(IEnumerable<string> lines)
    {
        WalkthroughSectionBuilder? current = null;
        var order = 0;

        foreach (var rawLine in lines)
        {
            var line = rawLine.TrimEnd();
            var match = HeadingRegex().Match(line.Trim());
            if (match.Success)
            {
                if (current is not null)
                {
                    yield return current.Build();
                }

                current = new WalkthroughSectionBuilder($"S{++order:00}", order, match.Groups["title"].Value.Trim());
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
        var summary = string.Join(' ', lines.Select(line => line.Trim()).Where(line => !string.IsNullOrWhiteSpace(line)).Take(8));
        summary = WhitespaceRegex().Replace(summary, " ").Trim();
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

        if (entityName.Length >= 6)
        {
            return true;
        }

        return entityName.Contains(' ') || entityName.Contains('-') || entityName.Contains('/') || entityName.Any(char.IsDigit);
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

    private static string NormalizeConsumable(string rawName)
    {
        return rawName.Trim() switch
        {
            "Cure1 Potions" => "Cure1 Potion",
            "Cure2 Potions" => "Cure2 Potion",
            "Cure3 Potions" => "Cure3 Potion",
            "Elixirs" => "Elixir",
            "Softs" => "Soft",
            "Soft Potion" => "Soft",
            "Soft Potions" => "Soft",
            _ => rawName.Trim()
        };
    }

    private static string ParseWorld(string title)
    {
        if (title.Contains("(Past)", StringComparison.OrdinalIgnoreCase))
        {
            return "Past";
        }

        if (title.Contains("(Present)", StringComparison.OrdinalIgnoreCase))
        {
            return "Present";
        }

        if (title.Contains("(Future)", StringComparison.OrdinalIgnoreCase))
        {
            return "Future";
        }

        if (title.Contains("Pureland", StringComparison.OrdinalIgnoreCase))
        {
            return "Pureland";
        }

        if (title.Contains("Underworld", StringComparison.OrdinalIgnoreCase))
        {
            return "Underworld";
        }

        return string.Empty;
    }

    [GeneratedRegex(@"^~(?<title>[^:]+):$", RegexOptions.Compiled)]
    private static partial Regex HeadingRegex();

    [GeneratedRegex(@"\b(?<name>Cure[123] Potions?|Elixirs?|Softs?|Soft Potions?)\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex ConsumableRegex();

    [GeneratedRegex(@"[A-Za-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    internal sealed record StoryEntityCandidate(string EntityType, string EntityName);

    private sealed record WalkthroughSection(string SectionId, int Order, string Title, IReadOnlyList<string> BodyLines);

    private sealed class WalkthroughSectionBuilder(string sectionId, int order, string title)
    {
        public List<string> BodyLines { get; } = [];

        public WalkthroughSection Build()
        {
            return new WalkthroughSection(sectionId, order, title, BodyLines.ToList());
        }
    }
}
