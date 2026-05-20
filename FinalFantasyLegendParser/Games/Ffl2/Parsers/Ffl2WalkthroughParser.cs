using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2WalkthroughParser
{
    private static readonly ConcurrentDictionary<string, Regex> MentionPatternCache = new(StringComparer.OrdinalIgnoreCase);

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

        return new Ffl2WalkthroughParseResult(storyLocations, storyAppearances);
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

    [GeneratedRegex(@"[A-Za-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    internal sealed record StoryEntityCandidate(string EntityType, string EntityName);

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
