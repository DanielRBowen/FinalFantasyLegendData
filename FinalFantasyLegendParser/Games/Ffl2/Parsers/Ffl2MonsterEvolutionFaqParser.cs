using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2MonsterEvolutionFaqParser
{
    public Ffl2MonsterParseResult Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "In-Depth Guides", "16852_Monster_Evolution_FAQ.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL2 monster evolution guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var monsters = ParseMonsters(lines, Path.GetFileName(sourcePath)).ToList();
        var abilityNames = monsters
            .SelectMany(monster => monster.Abilities.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        return new Ffl2MonsterParseResult(monsters, abilityNames);
    }

    private static IEnumerable<Ffl2MonsterRecord> ParseMonsters(IEnumerable<string> lines, string sourceGuide)
    {
        var inMonsterSection = false;
        var partThreeCount = 0;
        MonsterBuilder? current = null;

        foreach (var rawLine in lines)
        {
            var line = rawLine.TrimEnd();

            if (line.Contains("PART III:: MONSTER STATS AND SKILLS", StringComparison.Ordinal))
            {
                partThreeCount++;
                inMonsterSection = partThreeCount >= 2;
                continue;
            }

            if (!inMonsterSection)
            {
                continue;
            }

            if (line.Contains("PART IV:: MONSTER LOCATIONS", StringComparison.Ordinal))
            {
                break;
            }

            var match = MonsterRegex().Match(line);
            if (match.Success)
            {
                if (current is not null)
                {
                    yield return current.Build(sourceGuide);
                }

                current = new MonsterBuilder(
                    match.Groups["name"].Value.Trim(),
                    int.Parse(match.Groups["tier"].Value),
                    int.Parse(match.Groups["hp"].Value),
                    int.Parse(match.Groups["strength"].Value),
                    int.Parse(match.Groups["agility"].Value),
                    int.Parse(match.Groups["mana"].Value),
                    int.Parse(match.Groups["defense"].Value),
                    match.Groups["abilities"].Value.Trim());
                continue;
            }

            if (current is null)
            {
                continue;
            }

            if (ContinuationRegex().IsMatch(line))
            {
                current.Abilities.Add(line.Trim(' ', ','));
            }
        }

        if (current is not null)
        {
            yield return current.Build(sourceGuide);
        }
    }

    [GeneratedRegex(@"^(?<name>[^,]+),\s*(?<tier>\d+),\s*(?<hp>\d+),\s*(?<strength>\d+),\s*(?<agility>\d+),\s*(?<mana>\d+),\s*(?<defense>\d+),\s*(?<abilities>.+)$", RegexOptions.Compiled)]
    private static partial Regex MonsterRegex();

    [GeneratedRegex(@"^\s{10,}\S", RegexOptions.Compiled)]
    private static partial Regex ContinuationRegex();

    private sealed class MonsterBuilder(
        string monsterName,
        int tier,
        int hp,
        int strength,
        int agility,
        int mana,
        int defense,
        string firstAbilityLine)
    {
        public List<string> Abilities { get; } = [firstAbilityLine];

        public Ffl2MonsterRecord Build(string sourceGuide)
        {
            return new Ffl2MonsterRecord(
                monsterName,
                tier,
                hp,
                strength,
                agility,
                mana,
                defense,
                string.Join(" ", Abilities)
                    .Replace(", ,", ",")
                    .Replace("  ", " ")
                    .Trim(),
                sourceGuide);
        }
    }
}
