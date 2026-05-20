using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2StatusEffectParser
{
    public IReadOnlyList<Ffl2StatusEffectRecord> Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "Full Game Guides", "12292_Guide_and_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL2 walkthrough guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var sourceGuide = Path.GetFileName(sourcePath);
        var results = new List<Ffl2StatusEffectRecord>();
        var inStatusSection = false;

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();

            if (!inStatusSection)
            {
                if (line.Contains("During the battle, your party member may be inflicted", StringComparison.Ordinal))
                {
                    inStatusSection = true;
                }

                continue;
            }

            if (line.StartsWith("After the battle", StringComparison.Ordinal))
            {
                break;
            }

            var match = StatusRegex().Match(line);
            if (!match.Success)
            {
                continue;
            }

            var statusName = NormalizeStatus(match.Groups["status"].Value);
            var description = match.Groups["details"].Value.Trim();
            var cureMatch = CureRegex().Match(description);
            var curedBy = cureMatch.Success ? cureMatch.Groups["cure"].Value.Trim() : string.Empty;
            var notes = cureMatch.Success
                ? description[..cureMatch.Index].Trim().TrimEnd('.')
                : description;

            results.Add(new Ffl2StatusEffectRecord(
                statusName,
                string.Empty,
                curedBy,
                notes,
                sourceGuide));
        }

        return results;
    }

    private static string NormalizeStatus(string raw)
    {
        return raw.Trim() switch
        {
            "The Curse" => "Curse",
            _ => raw.Trim()
        };
    }

    [GeneratedRegex(@"^(?<status>[A-Za-z ]+)-(?<details>.+)$", RegexOptions.Compiled)]
    private static partial Regex StatusRegex();

    [GeneratedRegex(@"\((?:cure with\s*)?(?<cure>[^)]+)\)", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex CureRegex();
}
