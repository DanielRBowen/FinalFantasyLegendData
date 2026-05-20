using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl1.Parsers;

internal sealed partial class Ffl1CharacterParser
{
    public IReadOnlyList<Ffl1CharacterRecord> Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL1", "Full Game Guides", "31005_Guide_and_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL1 walkthrough used for character options.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var characters = new List<Ffl1CharacterRecord>();
        var inChoiceBlock = false;

        foreach (var line in lines)
        {
            if (line.Contains("choices are:", StringComparison.OrdinalIgnoreCase))
            {
                inChoiceBlock = true;
                continue;
            }

            if (!inChoiceBlock)
            {
                continue;
            }

            if (line.StartsWith("Pick your first character", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            var match = ChoiceRegex().Match(line);
            if (!match.Success)
            {
                continue;
            }

            var name = match.Groups["name"].Value.Trim();
            characters.Add(new Ffl1CharacterRecord(
                CharacterName: name,
                CharacterType: GetCharacterType(name),
                Description: GetDescription(name),
                SourceGuides: "31005_Guide_and_Walkthrough.txt; 8347_Human_FAQ.txt; 8348_Mutant_FAQ.txt; 16731_Meat_Transformations_FAQ.txt"));
        }

        return characters;
    }

    private static string GetCharacterType(string name)
    {
        return name switch
        {
            var value when value.StartsWith("Human", StringComparison.OrdinalIgnoreCase) => "Playable Archetype",
            var value when value.StartsWith("Mutant", StringComparison.OrdinalIgnoreCase) => "Playable Archetype",
            _ => "Monster Archetype"
        };
    }

    private static string GetDescription(string name)
    {
        return name switch
        {
            var value when value.StartsWith("Human", StringComparison.OrdinalIgnoreCase)
                => "Humans improve through purchased stat items and can equip the widest range of gear.",
            var value when value.StartsWith("Mutant", StringComparison.OrdinalIgnoreCase)
                => "Mutants improve through battle and specialize in magic and natural abilities.",
            _ => "Monster starting option available during character creation; long-term growth is tied to the monster transformation system."
        };
    }

    [GeneratedRegex(@"^\d+:\s+(?<name>.+)$", RegexOptions.Compiled)]
    private static partial Regex ChoiceRegex();
}
