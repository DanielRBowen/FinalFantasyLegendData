using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl1.Parsers;

internal sealed partial class Ffl1WalkthroughParser
{
    private static readonly ConcurrentDictionary<string, Regex> MentionPatternCache = new(StringComparer.OrdinalIgnoreCase);

    private static readonly HashSet<string> AmbiguousNames =
    [
        "Fire", "Ice", "Elec", "Fog", "Cure", "Heal", "Care", "Book", "Door", "Board", "Armor", "Power", "Bronze", "Gold", "Silver",
        "Dragon", "King", "Light", "Beam", "Tail", "Acid", "Flame", "Mirror", "Barrier", "Counter", "Punch", "Kick", "Stone", "Sleep", "Death",
        "Left", "Right", "Sword", "Sphere"
    ];

    public Ffl1WalkthroughParseResult Parse(string repositoryRoot, IReadOnlyCollection<StoryEntityCandidate> entityCandidates)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL1", "Full Game Guides", "31005_Guide_and_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL1 walkthrough guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var sections = ParseSections(lines).ToList();
        var storyLocations = new List<Ffl1StoryLocationRecord>();
        var storyAppearances = new List<Ffl1EntityStoryAppearanceRecord>();

        foreach (var section in sections)
        {
            var bodyText = NormalizeBody(section.BodyLines);
            var summary = BuildSummary(section.BodyLines);
            var (locationName, locationContext) = SplitTitle(section.Title);
            var (world, floor) = ParseContext(locationContext);

            var mentions = FindMentions(bodyText, entityCandidates)
                .OrderBy(candidate => candidate.EntityType, StringComparer.OrdinalIgnoreCase)
                .ThenBy(candidate => candidate.EntityName, StringComparer.OrdinalIgnoreCase)
                .ToList();

            foreach (var mention in mentions)
            {
                storyAppearances.Add(new Ffl1EntityStoryAppearanceRecord(
                    Order: section.Order,
                    SectionId: section.SectionId,
                    LocationName: locationName,
                    EntityType: mention.EntityType,
                    EntityName: mention.EntityName,
                    MentionType: "ExplicitMention",
                    SourceGuide: Path.GetFileName(sourcePath)));
            }

            storyLocations.Add(new Ffl1StoryLocationRecord(
                Order: section.Order,
                SectionId: section.SectionId,
                LocationName: locationName,
                LocationContext: locationContext,
                World: world,
                Floor: floor,
                Summary: summary,
                MentionedCharacters: JoinMentionNames(mentions, "Character"),
                MentionedMonsters: JoinMentionNames(mentions, "Monster"),
                MentionedItems: JoinMentionNames(mentions, "Item"),
                MentionedEquipment: JoinMentionNames(mentions, "Equipment"),
                MentionedSpells: JoinMentionNames(mentions, "Spell"),
                MentionedAbilities: JoinMentionNames(mentions, "Ability"),
                MentionedStatusEffects: JoinMentionNames(mentions, "StatusEffect"),
                SourceGuide: Path.GetFileName(sourcePath)));
        }

        return new Ffl1WalkthroughParseResult(storyLocations, storyAppearances);
    }

    private static IEnumerable<WalkthroughSection> ParseSections(IEnumerable<string> lines)
    {
        WalkthroughSectionBuilder? current = null;
        var inWalkthrough = false;
        var firstSectionCount = 0;

        foreach (var line in lines)
        {
            var headingMatch = SectionRegex().Match(line);

            if (!inWalkthrough)
            {
                if (headingMatch.Success && headingMatch.Groups["section"].Value == "01")
                {
                    firstSectionCount++;
                    if (firstSectionCount == 2)
                    {
                        inWalkthrough = true;
                        current = new WalkthroughSectionBuilder(
                            sectionId: $"3.{headingMatch.Groups["section"].Value}",
                            order: int.Parse(headingMatch.Groups["section"].Value),
                            title: headingMatch.Groups["title"].Value.Trim());
                    }
                }

                continue;
            }

            if (headingMatch.Success)
            {
                if (current is not null)
                {
                    yield return current.Build();
                }

                current = new WalkthroughSectionBuilder(
                    sectionId: $"3.{headingMatch.Groups["section"].Value}",
                    order: int.Parse(headingMatch.Groups["section"].Value),
                    title: headingMatch.Groups["title"].Value.Trim());

                continue;
            }

            if (current is null)
            {
                continue;
            }

            if (line.StartsWith("Section 4:", StringComparison.Ordinal))
            {
                break;
            }

            current.BodyLines.Add(line);
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
            .Where(line => !line.StartsWith("---", StringComparison.Ordinal))
            .Where(line => !line.StartsWith("===", StringComparison.Ordinal))
            .Where(line => !InventoryLineRegex().IsMatch(line))
            .Take(10)
            .ToList();

        var summary = string.Join(' ', narrativeLines);
        summary = WhitespaceRegex().Replace(summary, " ").Trim();

        return summary.Length <= 420 ? summary : summary[..420].TrimEnd() + "...";
    }

    private static (string LocationName, string LocationContext) SplitTitle(string title)
    {
        var openIndex = title.IndexOf('(');
        var closeIndex = title.LastIndexOf(')');

        if (openIndex >= 0 && closeIndex > openIndex)
        {
            return (title[..openIndex].Trim(), title[(openIndex + 1)..closeIndex].Trim());
        }

        return (title.Trim(), string.Empty);
    }

    private static (string World, string Floor) ParseContext(string context)
    {
        if (string.IsNullOrWhiteSpace(context))
        {
            return (string.Empty, string.Empty);
        }

        var worldMatch = WorldRegex().Match(context);
        var floorMatch = FloorRegex().Match(context);

        return (
            worldMatch.Success ? worldMatch.Groups["world"].Value : string.Empty,
            floorMatch.Success ? floorMatch.Groups["floor"].Value : string.Empty);
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

        return entityName.Contains(' ') || entityName.Contains('-') || entityName.Any(char.IsDigit);
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

            var inner = tokens.Length == 1
                ? tokens[0]
                : string.Join("[\\s\\-_']*", tokens);

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

    [GeneratedRegex(@"^3\.(?<section>\d{2}):\s+(?<title>.+)$", RegexOptions.Compiled)]
    private static partial Regex SectionRegex();

    [GeneratedRegex(@"World\s+(?<world>\d+)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex WorldRegex();

    [GeneratedRegex(@"Floor\s+(?<floor>\d+)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex FloorRegex();

    [GeneratedRegex(@"[A-Za-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    [GeneratedRegex(@"^[A-Za-z0-9().\- /]+:\s+\d", RegexOptions.Compiled)]
    private static partial Regex InventoryLineRegex();

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
