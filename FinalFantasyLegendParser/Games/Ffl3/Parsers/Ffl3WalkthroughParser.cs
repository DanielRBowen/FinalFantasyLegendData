using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl3.Parsers;

internal sealed partial class Ffl3WalkthroughParser
{
    private static readonly ConcurrentDictionary<string, Regex> MentionPatternCache = new(StringComparer.OrdinalIgnoreCase);

    private static readonly (string Name, string Category)[] KeyItems =
    [
        ("Past Unit", "Talon Unit"),
        ("Flushex Unit", "Talon Unit"),
        ("Rover Unit", "Talon Unit"),
        ("Tower Key", "Key Item"),
        ("Air Crystal", "Crystal"),
        ("Water Crystal", "Crystal"),
        ("Future Unit", "Talon Unit"),
        ("Hover Unit", "Talon Unit"),
        ("Radio", "Key Item"),
        ("Remote", "Key Item"),
        ("Firestar", "Key Item"),
        ("X-Plane Unit", "Talon Unit"),
        ("Missile Unit", "Talon Unit"),
        ("Shield Unit", "Talon Unit"),
        ("Laser Unit", "Talon Unit"),
        ("Prison Key", "Key Item"),
        ("Dark Crystal", "Crystal"),
        ("Light Crystal", "Crystal"),
        ("Fire Crystal", "Crystal"),
        ("Earth Crystal", "Crystal"),
        ("Rocket", "Key Item"),
        ("Tablet", "Key Item"),
        ("B-jack", "Tool"),
        ("Teargas", "Tool"),
        ("Catnip", "Tool")
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
        var collectibles = ExtractCollectibles(sections, baseEntityCandidates, sourceGuide);
        var allCandidates = baseEntityCandidates
            .Concat(items.Select(item => new StoryEntityCandidate("Item", item.Name)))
            .GroupBy(candidate => $"{candidate.EntityType}|{candidate.EntityName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();

        var storyLocations = new List<Ffl3StoryLocationRecord>();
        var storyAppearances = new List<Ffl3EntityStoryAppearanceRecord>();

        foreach (var section in sections)
        {
            var bodyText = NormalizeSearchBody(NormalizeBody(section.BodyLines));
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

        return new Ffl3WalkthroughParseResult(items, collectibles, storyLocations, storyAppearances);
    }

    private static IReadOnlyList<Ffl3ItemRecord> ExtractItems(IReadOnlyList<WalkthroughSection> sections, string sourceGuide)
    {
        var itemsByName = new Dictionary<string, ItemAccumulator>(StringComparer.OrdinalIgnoreCase);

        foreach (var section in sections)
        {
            foreach (var rawLine in section.BodyLines)
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var availability = section.Title;
                var note = ClassifyItemNote(line);
                var searchableLine = NormalizeSearchBody(line);

                foreach (var keyItem in KeyItems)
                {
                    if (GetMentionPattern(keyItem.Name).IsMatch(searchableLine))
                    {
                        AddItem(itemsByName, keyItem.Category, keyItem.Name, availability, note, sourceGuide);
                    }
                }

                foreach (var groupedItem in ExtractGroupedItems(line))
                {
                    AddItem(itemsByName, groupedItem.Category, groupedItem.Name, availability, note, sourceGuide);
                }

                foreach (Match match in ConsumableRegex().Matches(line))
                {
                    var normalizedName = NormalizeConsumable(match.Groups["name"].Value);
                    AddItem(itemsByName, "Consumable", normalizedName, availability, note, sourceGuide);
                }
            }
        }

        return itemsByName.Values
            .Select(item => item.ToRecord())
            .OrderBy(item => item.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(item => item.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl3WalkthroughCollectibleRecord> ExtractCollectibles(
        IReadOnlyList<WalkthroughSection> sections,
        IReadOnlyCollection<StoryEntityCandidate> baseEntityCandidates,
        string sourceGuide)
    {
        var collectibleCandidates = baseEntityCandidates
            .Where(candidate => candidate.EntityType is "Equipment" or "Spell")
            .ToList();

        var collectiblesByName = new Dictionary<string, CollectibleAccumulator>(StringComparer.OrdinalIgnoreCase);

        foreach (var section in sections)
        {
            foreach (var rawLine in section.BodyLines)
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line) || !AcquisitionCueRegex().IsMatch(line))
                {
                    continue;
                }

                var availability = section.Title;
                var note = ClassifyCollectibleNote(line);
                var searchableLine = NormalizeCollectibleSearchBody(line);

                foreach (var candidate in collectibleCandidates)
                {
                    if (GetMentionPattern(candidate.EntityName).IsMatch(searchableLine))
                    {
                        AddCollectible(collectiblesByName, candidate.EntityType, candidate.EntityName, availability, note, sourceGuide);
                    }
                }
            }
        }

        return collectiblesByName.Values
            .Select(item => item.ToRecord())
            .OrderBy(item => item.EntityType, StringComparer.OrdinalIgnoreCase)
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

    private static void AddItem(
        IDictionary<string, ItemAccumulator> itemsByName,
        string category,
        string name,
        string availability,
        string notes,
        string sourceGuide)
    {
        if (!itemsByName.TryGetValue(name, out var accumulator))
        {
            accumulator = new ItemAccumulator(category, name, sourceGuide);
            itemsByName[name] = accumulator;
        }

        accumulator.Availabilities.Add(availability);
        accumulator.Notes.Add(notes);
    }

    private static void AddCollectible(
        IDictionary<string, CollectibleAccumulator> collectiblesByName,
        string entityType,
        string name,
        string availability,
        string notes,
        string sourceGuide)
    {
        var key = $"{entityType}|{name}";
        if (!collectiblesByName.TryGetValue(key, out var accumulator))
        {
            accumulator = new CollectibleAccumulator(entityType, name, sourceGuide);
            collectiblesByName[key] = accumulator;
        }

        accumulator.Availabilities.Add(availability);
        accumulator.Notes.Add(notes);
    }

    private static string ClassifyItemNote(string line)
    {
        if (line.Contains("buy", StringComparison.OrdinalIgnoreCase))
        {
            return "Purchased or restocked during the walkthrough.";
        }

        if (line.Contains("after the fight", StringComparison.OrdinalIgnoreCase)
            || line.Contains("after the battle", StringComparison.OrdinalIgnoreCase)
            || line.Contains("boss", StringComparison.OrdinalIgnoreCase))
        {
            return "Boss reward or progression item from the walkthrough.";
        }

        if (line.Contains("chest", StringComparison.OrdinalIgnoreCase)
            || line.Contains("box", StringComparison.OrdinalIgnoreCase)
            || line.Contains("pick up", StringComparison.OrdinalIgnoreCase)
            || line.Contains("get ", StringComparison.OrdinalIgnoreCase)
            || line.StartsWith("Get ", StringComparison.OrdinalIgnoreCase))
        {
            return "Treasure or route pickup from the walkthrough.";
        }

        if (line.Contains("talk to", StringComparison.OrdinalIgnoreCase)
            || line.Contains("speak with", StringComparison.OrdinalIgnoreCase)
            || line.Contains("gives you", StringComparison.OrdinalIgnoreCase))
        {
            return "NPC reward or story gift from the walkthrough.";
        }

        return "Referenced in walkthrough progression.";
    }

    private static string ClassifyCollectibleNote(string line)
    {
        if (line.Contains("buy", StringComparison.OrdinalIgnoreCase) || line.Contains("restock", StringComparison.OrdinalIgnoreCase))
        {
            return "Purchased or restocked during the walkthrough.";
        }

        if (line.Contains("mix", StringComparison.OrdinalIgnoreCase)
            || (line.Contains("make", StringComparison.OrdinalIgnoreCase) && !line.Contains("make sure", StringComparison.OrdinalIgnoreCase)))
        {
            return "Crafted or mixed during the walkthrough.";
        }

        if (line.Contains("drop", StringComparison.OrdinalIgnoreCase) || line.Contains("might get", StringComparison.OrdinalIgnoreCase))
        {
            return "Possible enemy drop noted in the walkthrough.";
        }

        if (line.Contains("after the fight", StringComparison.OrdinalIgnoreCase)
            || line.Contains("after the battle", StringComparison.OrdinalIgnoreCase)
            || line.Contains("boss", StringComparison.OrdinalIgnoreCase))
        {
            return "Boss reward or post-boss pickup from the walkthrough.";
        }

        if (line.Contains("talk to", StringComparison.OrdinalIgnoreCase)
            || line.Contains("speak with", StringComparison.OrdinalIgnoreCase)
            || line.Contains("gives you", StringComparison.OrdinalIgnoreCase))
        {
            return "NPC reward or story gift from the walkthrough.";
        }

        return "Treasure or route pickup from the walkthrough.";
    }

    private static IEnumerable<(string Name, string Category)> ExtractGroupedItems(string line)
    {
        if (line.Contains("Future and Hover units", StringComparison.OrdinalIgnoreCase))
        {
            yield return ("Future Unit", "Talon Unit");
            yield return ("Hover Unit", "Talon Unit");
        }

        if (line.Contains("Teargas/Air Crystal", StringComparison.OrdinalIgnoreCase))
        {
            yield return ("Teargas", "Tool");
            yield return ("Air Crystal", "Crystal");
        }

        if (line.Contains("Dark and Light Crystals", StringComparison.OrdinalIgnoreCase)
            || line.Contains("Light/Dark Crystals", StringComparison.OrdinalIgnoreCase)
            || line.Contains("Dark/Light Crystals", StringComparison.OrdinalIgnoreCase))
        {
            yield return ("Dark Crystal", "Crystal");
            yield return ("Light Crystal", "Crystal");
        }

        if (line.Contains("Earth and Water Crystals", StringComparison.OrdinalIgnoreCase)
            || line.Contains("Earth/Water Crystals", StringComparison.OrdinalIgnoreCase))
        {
            yield return ("Earth Crystal", "Crystal");
            yield return ("Water Crystal", "Crystal");
        }
    }

    private static string NormalizeSearchBody(string text)
    {
        return text
            .Replace("Future and Hover units", "Future Unit Hover Unit", StringComparison.OrdinalIgnoreCase)
            .Replace("Aero1", "Aero", StringComparison.OrdinalIgnoreCase)
            .Replace("Teargas/Air Crystal", "Teargas Air Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("Dark and Light Crystals", "Dark Crystal Light Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("Light/Dark Crystals", "Light Crystal Dark Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("Dark/Light Crystals", "Dark Crystal Light Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("Earth and Water Crystals", "Earth Crystal Water Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("Earth/Water Crystals", "Earth Crystal Water Crystal", StringComparison.OrdinalIgnoreCase)
            .Replace("units", "unit", StringComparison.OrdinalIgnoreCase)
            .Replace("Crystals", "Crystal", StringComparison.OrdinalIgnoreCase);
    }

    private static string NormalizeCollectibleSearchBody(string text)
    {
        return NormalizeSearchBody(text)
            .Replace("Armors", "Armor", StringComparison.OrdinalIgnoreCase)
            .Replace("Helmets", "Helmet", StringComparison.OrdinalIgnoreCase)
            .Replace("Shields", "Shield", StringComparison.OrdinalIgnoreCase)
            .Replace("Gloves", "Glove", StringComparison.OrdinalIgnoreCase)
            .Replace("Swords", "Sword", StringComparison.OrdinalIgnoreCase)
            .Replace("Axes", "Axe", StringComparison.OrdinalIgnoreCase)
            .Replace("Daggers", "Dagger", StringComparison.OrdinalIgnoreCase)
            .Replace("Bracelets", "Bracelet", StringComparison.OrdinalIgnoreCase)
            .Replace("Pendants", "Pendant", StringComparison.OrdinalIgnoreCase)
            .Replace("Bangles", "Bangle", StringComparison.OrdinalIgnoreCase)
            .Replace("Plumes", "Plume", StringComparison.OrdinalIgnoreCase);
    }

    private static string NormalizeConsumable(string rawName)
    {
        return rawName.Trim().ToLowerInvariant() switch
        {
            "cure1 potion" => "Cure1 Potion",
            "cure1 potions" => "Cure1 Potion",
            "cure2 potion" => "Cure2 Potion",
            "cure2 potions" => "Cure2 Potion",
            "cure3 potion" => "Cure3 Potion",
            "cure3 potions" => "Cure3 Potion",
            "elixir" => "Elixir",
            "elixirs" => "Elixir",
            "soft" => "Soft",
            "softs" => "Soft",
            "soft potion" => "Soft",
            "soft potions" => "Soft",
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

    [GeneratedRegex(@"\b(buy|bought|get|pick\s+up|receive|received|restock|drop|drops?)\b|\bmix\b|\bmake\b(?!\s+sure)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex AcquisitionCueRegex();

    [GeneratedRegex(@"[A-Za-z0-9]+", RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    internal sealed record StoryEntityCandidate(string EntityType, string EntityName);

    private sealed class ItemAccumulator(string category, string name, string sourceGuide)
    {
        public HashSet<string> Availabilities { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> Notes { get; } = new(StringComparer.OrdinalIgnoreCase);

        public Ffl3ItemRecord ToRecord()
        {
            return new Ffl3ItemRecord(
                category,
                name,
                string.Join("; ", Availabilities.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", Notes.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                sourceGuide);
        }
    }

    private sealed class CollectibleAccumulator(string entityType, string name, string sourceGuide)
    {
        public HashSet<string> Availabilities { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> Notes { get; } = new(StringComparer.OrdinalIgnoreCase);

        public Ffl3WalkthroughCollectibleRecord ToRecord()
        {
            return new Ffl3WalkthroughCollectibleRecord(
                entityType,
                name,
                string.Join("; ", Availabilities.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", Notes.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                sourceGuide);
        }
    }

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
