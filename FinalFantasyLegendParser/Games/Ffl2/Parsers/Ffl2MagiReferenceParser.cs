using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2MagiReferenceParser
{
    private static readonly Dictionary<string, string> CanonicalTranslationNames = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Power"] = "Power Magi",
        ["Speed"] = "Speed Magi",
        ["Mana"] = "Mana Magi",
        ["Defense"] = "Defense Magi",
        ["Fire"] = "Fire Magi",
        ["Thunder"] = "Thunder Magi",
        ["Ice"] = "Ice Magi",
        ["Poison"] = "Poison Magi",
        ["Prism"] = "Prism Magi",
        ["TrueEye"] = "True Eye Magi",
        ["Aegis"] = "Aegis Magi"
    };

    private static readonly Dictionary<string, string> RobotGuideEffects = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Prism Magi"] = "Shows how many MAGI remain in the current world when used from the MAGI menu.",
        ["Power Magi"] = "Hidden STR boost when equipped.",
        ["Speed Magi"] = "Hidden AGL boost when equipped.",
        ["Mana Magi"] = "Hidden MAN boost when equipped.",
        ["Defense Magi"] = "Hidden defensive boost when equipped.",
        ["Fire Magi"] = "Elemental MAGI tied to fire protection and attack boosts.",
        ["Thunder Magi"] = "Elemental MAGI tied to thunder protection and attack boosts.",
        ["Ice Magi"] = "Elemental MAGI tied to ice protection and attack boosts.",
        ["Poison Magi"] = "Elemental MAGI tied to poison protection and attack boosts.",
        ["True Eye Magi"] = "Works automatically in special dungeons to reveal otherwise obscured areas.",
        ["Aegis Magi"] = "Special MAGI that can be equipped and used as a battle item.",
        ["Heart Magi"] = "Special MAGI that can be equipped and used as a battle item.",
        ["Masamune Magi"] = "Special MAGI documented in the item reference guides.",
        ["Pegasus Magi"] = "Teleports the party to visited towns and other main locations."
    };

    public IReadOnlyList<Ffl2ItemRecord> Parse(string repositoryRoot)
    {
        var magi = new Dictionary<string, MagiAccumulator>(StringComparer.OrdinalIgnoreCase);

        LoadTranslationDifferences(repositoryRoot, magi);
        LoadRobotGuide(repositoryRoot, magi);
        LoadSaveStateGuide(repositoryRoot, magi);
        LoadSupplementalAvailability(repositoryRoot, magi);

        return magi.Values
            .Select(record => record.ToItemRecord())
            .OrderBy(record => record.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static void LoadTranslationDifferences(string repositoryRoot, IDictionary<string, MagiAccumulator> magi)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "In-Depth Guides", "29802_Translation_Differences_FAQ.txt");
        if (!File.Exists(sourcePath))
        {
            return;
        }

        var sourceGuide = Path.GetFileName(sourcePath);
        foreach (var line in File.ReadLines(sourcePath))
        {
            var match = TranslationRowRegex().Match(line.TrimEnd());
            if (!match.Success)
            {
                continue;
            }

            var legacyName = match.Groups["legacy"].Value.Trim();
            if (!CanonicalTranslationNames.TryGetValue(legacyName, out var canonicalName))
            {
                continue;
            }

            if (!line.Contains("MAGI", StringComparison.OrdinalIgnoreCase)
                && !legacyName.Equals("Prism", StringComparison.OrdinalIgnoreCase)
                && !legacyName.Equals("TrueEye", StringComparison.OrdinalIgnoreCase)
                && !legacyName.Equals("Aegis", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var accumulator = GetOrCreateAccumulator(magi, canonicalName);
            accumulator.SourceGuides.Add(sourceGuide);
            accumulator.Notes.Add($"Alternate translation: {match.Groups["translated"].Value.Trim()}.");

            if (RobotGuideEffects.TryGetValue(canonicalName, out var effect))
            {
                accumulator.PrimaryEffects.Add(effect);
            }
        }
    }

    private static void LoadRobotGuide(string repositoryRoot, IDictionary<string, MagiAccumulator> magi)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "In-Depth Guides", "29741_Robot_Guide.txt");
        if (!File.Exists(sourcePath))
        {
            return;
        }

        var sourceGuide = Path.GetFileName(sourcePath);
        var sourceText = File.ReadAllText(sourcePath);
        if (!sourceText.Contains("MAGI", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        foreach (var pair in RobotGuideEffects)
        {
            var accumulator = GetOrCreateAccumulator(magi, pair.Key);
            accumulator.PrimaryEffects.Add(pair.Value);
            accumulator.SourceGuides.Add(sourceGuide);
        }

        foreach (var elementalName in new[] { "Fire Magi", "Thunder Magi", "Ice Magi", "Poison Magi" })
        {
            var accumulator = GetOrCreateAccumulator(magi, elementalName);
            accumulator.Notes.Add("Robot guide notes that elemental MAGI behavior is buggy in some situations.");
        }
    }

    private static void LoadSaveStateGuide(string repositoryRoot, IDictionary<string, MagiAccumulator> magi)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "In-Depth Guides", "12084_Save_State_Hacking_Guide.txt");
        if (!File.Exists(sourcePath))
        {
            return;
        }

        var sourceGuide = Path.GetFileName(sourcePath);
        foreach (var line in File.ReadLines(sourcePath))
        {
            var match = SaveStateMagiRegex().Match(line.TrimEnd());
            if (!match.Success)
            {
                continue;
            }

            var canonicalName = NormalizeSpecialMagiName(match.Groups["name"].Value.Trim());
            var accumulator = GetOrCreateAccumulator(magi, canonicalName);
            accumulator.SourceGuides.Add(sourceGuide);
            accumulator.Notes.Add("Listed in the save-state hacking guide item table.");

            if (RobotGuideEffects.TryGetValue(canonicalName, out var effect))
            {
                accumulator.PrimaryEffects.Add(effect);
            }
        }
    }

    private static void LoadSupplementalAvailability(string repositoryRoot, IDictionary<string, MagiAccumulator> magi)
    {
        AddIfGuideContains(
            repositoryRoot,
            Path.Combine("FFL2", "Full Game Guides", "6486_Guide_and_Walkthrough.txt"),
            "Open the treasure chest for a Pegasus Magi",
            ["Pegasus Magi"],
            static records =>
            {
                records["Pegasus Magi"].Availabilities.Add("Nasty Dungeon");
                records["Pegasus Magi"].Notes.Add("Alternate walkthrough identifies Pegasus Magi as the only MAGI in Nasty Dungeon.");
            },
            magi);

        AddIfGuideContains(
            repositoryRoot,
            Path.Combine("FFL2", "Full Game Guides", "46173_Guide_and_Walkthrough.txt"),
            "you will get the Heart Magi from the chest",
            ["Heart Magi"],
            static records =>
            {
                records["Heart Magi"].Availabilities.Add("Death Machine chest");
                records["Heart Magi"].Notes.Add("Alternate walkthrough identifies Heart Magi as the Death Machine chest reward.");
            },
            magi);

        AddIfGuideContains(
            repositoryRoot,
            Path.Combine("FFL2", "Full Game Guides", "62397_Guide_and_Walkthrough.txt"),
            "find three MAGI: Fire, Poison, and TrueEye",
            ["Fire Magi", "Poison Magi", "True Eye Magi"],
            static records =>
            {
                records["Fire Magi"].Availabilities.Add("Volcano");
                records["Poison Magi"].Availabilities.Add("Volcano");
                records["True Eye Magi"].Availabilities.Add("Volcano");
                records["True Eye Magi"].Notes.Add("Alternate walkthrough places TrueEye in the volcano alongside Fire and Poison MAGI.");
            },
            magi);

        AddIfGuideContains(
            repositoryRoot,
            Path.Combine("FFL2", "Full Game Guides", "6486_Guide_and_Walkthrough.txt"),
            "Once Venus is defeated you will get the Power, Speed, Mana, Fire, Ice, Thunder, Poison and Aegis Magi.",
            ["Power Magi", "Speed Magi", "Mana Magi", "Fire Magi", "Ice Magi", "Thunder Magi", "Poison Magi", "Aegis Magi"],
            static records =>
            {
                foreach (var name in new[] { "Power Magi", "Speed Magi", "Mana Magi", "Fire Magi", "Ice Magi", "Thunder Magi", "Poison Magi", "Aegis Magi" })
                {
                    records[name].Availabilities.Add("Venus battle reward");
                }

                records["Aegis Magi"].Notes.Add("Alternate walkthrough includes Aegis as part of the Venus MAGI reward bundle.");
            },
            magi);
    }

    private static void AddIfGuideContains(
        string repositoryRoot,
        string relativePath,
        string probe,
        IReadOnlyCollection<string> affectedNames,
        Action<IDictionary<string, MagiAccumulator>> onMatch,
        IDictionary<string, MagiAccumulator> magi)
    {
        var sourcePath = Path.Combine(repositoryRoot, relativePath);
        if (!File.Exists(sourcePath))
        {
            return;
        }

        var sourceText = NormalizeWhitespace(File.ReadAllText(sourcePath));
        if (!sourceText.Contains(NormalizeWhitespace(probe), StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        onMatch(magi);
        var sourceGuide = Path.GetFileName(sourcePath);
        foreach (var name in affectedNames)
        {
            GetOrCreateAccumulator(magi, name).SourceGuides.Add(sourceGuide);
        }
    }

    private static MagiAccumulator GetOrCreateAccumulator(IDictionary<string, MagiAccumulator> magi, string name)
    {
        if (!magi.TryGetValue(name, out var accumulator))
        {
            accumulator = new MagiAccumulator(name);
            magi[name] = accumulator;
        }

        return accumulator;
    }

    private static string NormalizeSpecialMagiName(string rawName)
    {
        return rawName switch
        {
            "TrueEye" => "True Eye Magi",
            "TrueEye Magi" => "True Eye Magi",
            _ => rawName
        };
    }

    private static string NormalizeWhitespace(string value)
    {
        return WhitespaceRegex().Replace(value, " ").Trim();
    }

    [GeneratedRegex(@"^(?<legacy>[A-Za-z]+)\s{2,}.+?\s{2,}(?<translated>.+?)\s*$", RegexOptions.Compiled)]
    private static partial Regex TranslationRowRegex();

    [GeneratedRegex(@"^[0-9A-F]{2}:\s*(?<name>(?:[A-Za-z]+(?:\s+[A-Za-z]+)?\s+Magi|TrueEye|True Eye Magi))\s*$", RegexOptions.Compiled)]
    private static partial Regex SaveStateMagiRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    private sealed class MagiAccumulator(string name)
    {
        public HashSet<string> Availabilities { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> PrimaryEffects { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> Notes { get; } = new(StringComparer.OrdinalIgnoreCase);

        public HashSet<string> SourceGuides { get; } = new(StringComparer.OrdinalIgnoreCase);

        public Ffl2ItemRecord ToItemRecord()
        {
            return new Ffl2ItemRecord(
                "Key Item",
                name,
                string.Empty,
                string.Empty,
                string.Join("; ", Availabilities.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", PrimaryEffects.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", Notes.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", SourceGuides.OrderBy(value => value, StringComparer.OrdinalIgnoreCase)));
        }
    }
}