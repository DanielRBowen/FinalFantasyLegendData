using System.Text.RegularExpressions;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed partial class Ffl2ShopParser
{
    private static readonly HashSet<string> SpellNames =
    [
        "Ice B", "Temptat", "Thunder", "Fog B", "Sleep B", "Prayer B", "Cure B", "Heal Rod"
    ];

    public Ffl2ShopParseResult Parse(string repositoryRoot)
    {
        var sourcePath = Path.Combine(repositoryRoot, "FFL2", "Full Game Guides", "12292_Guide_and_Walkthrough.txt");

        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Missing FFL2 walkthrough guide.", sourcePath);
        }

        var lines = File.ReadAllLines(sourcePath);
        var sourceGuide = Path.GetFileName(sourcePath);
        var currentLocation = string.Empty;
        var equipment = new List<ShopEntry>();
        var items = new List<ShopEntry>();
        var spells = new List<ShopEntry>();

        for (var index = 0; index < lines.Length; index++)
        {
            var line = lines[index].TrimEnd();
            var headingMatch = HeadingRegex().Match(line.Trim());
            if (headingMatch.Success)
            {
                currentLocation = headingMatch.Groups["title"].Value.Trim();
                continue;
            }

            var subsectionMatch = SubsectionRegex().Match(line.Trim());
            if (subsectionMatch.Success)
            {
                currentLocation = subsectionMatch.Groups["title"].Value.Trim();
                continue;
            }

            if (!ShopHeaderRegex().IsMatch(line.Trim()))
            {
                continue;
            }

            index++;
            for (; index < lines.Length; index++)
            {
                var row = lines[index];
                if (string.IsNullOrWhiteSpace(row) || !row.Contains("GP", StringComparison.Ordinal))
                {
                    index--;
                    break;
                }

                var matches = ShopEntryRegex().Matches(row.Replace('\t', ' '));
                if (matches.Count == 0)
                {
                    continue;
                }

                foreach (Match match in matches)
                {
                    var entry = CreateEntry(match, currentLocation, sourceGuide);

                    if (IsEquipment(entry.Name))
                    {
                        equipment.Add(entry with { Name = NormalizeEquipmentName(entry.Name), Category = DetermineEquipmentCategory(entry.Name) });
                    }
                    else if (IsSpell(entry.Name))
                    {
                        spells.Add(entry with { Name = NormalizeSpellName(entry.Name), Category = "Spell/Book" });
                    }
                    else if (IsItem(entry.Name))
                    {
                        items.Add(entry with { Name = NormalizeItemName(entry.Name), Category = "Item" });
                    }
                    else
                    {
                        equipment.Add(entry with { Name = NormalizeWeaponName(entry.Name), Category = "Weapon" });
                    }
                }
            }
        }

        return new Ffl2ShopParseResult(
            AggregateEquipment(equipment),
            AggregateItems(items),
            AggregateItems(spells));
    }

    private static ShopEntry CreateEntry(Match match, string location, string sourceGuide)
    {
        return new ShopEntry(
            Category: string.Empty,
            Name: NormalizeWhitespace(match.Groups["name"].Value),
            Uses: match.Groups["uses"].Value.Trim(),
            Cost: match.Groups["cost"].Value.Trim(),
            Availability: location,
            Notes: "Sold in shops",
            SourceGuides: sourceGuide);
    }

    private static IReadOnlyList<Ffl2EquipmentRecord> AggregateEquipment(IEnumerable<ShopEntry> rows)
    {
        return rows
            .GroupBy(row => $"{row.Category}|{row.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2EquipmentRecord(
                group.First().Category,
                group.First().Name,
                JoinDistinct(group.Select(row => row.Uses)),
                JoinDistinct(group.Select(row => row.Cost)),
                JoinDistinct(group.Select(row => row.Availability)),
                JoinDistinct(group.Select(row => row.Notes)),
                JoinDistinct(group.Select(row => row.SourceGuides))))
            .OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl2ItemRecord> AggregateItems(IEnumerable<ShopEntry> rows)
    {
        return rows
            .GroupBy(row => $"{row.Category}|{row.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2ItemRecord(
                group.First().Category,
                group.First().Name,
                JoinDistinct(group.Select(row => row.Uses)),
                JoinDistinct(group.Select(row => row.Cost)),
                JoinDistinct(group.Select(row => row.Availability)),
                string.Empty,
                JoinDistinct(group.Select(row => row.Notes)),
                JoinDistinct(group.Select(row => row.SourceGuides))))
            .OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static bool IsEquipment(string name)
    {
        return EquipmentRegex().IsMatch(name);
    }

    private static bool IsSpell(string name)
    {
        return SpellNames.Contains(NormalizeWhitespace(name));
    }

    private static bool IsItem(string name)
    {
        var normalized = NormalizeWhitespace(name);
        return normalized.EndsWith(" P", StringComparison.OrdinalIgnoreCase)
               || normalized.Equals("Elixir", StringComparison.OrdinalIgnoreCase);
    }

    private static string DetermineEquipmentCategory(string name)
    {
        return NormalizeWhitespace(name) switch
        {
            var value when value.EndsWith(" A", StringComparison.OrdinalIgnoreCase) => "Armor",
            var value when value.EndsWith(" G", StringComparison.OrdinalIgnoreCase) => "Gauntlet",
            var value when value.EndsWith(" H", StringComparison.OrdinalIgnoreCase) => "Helmet",
            var value when value.EndsWith(" Sh", StringComparison.OrdinalIgnoreCase) => "Shield",
            _ => "Weapon"
        };
    }

    private static string NormalizeWeaponName(string rawName)
    {
        return NormalizeWhitespace(rawName) switch
        {
            "Rapier S" => "Rapier",
            "Long S" => "Long Sword",
            "Sabre S" => "Sabre Sword",
            "Battle S" => "Battle Sword",
            "Psi K" => "Psi Knife",
            _ => NormalizeWhitespace(rawName)
        };
    }

    private static string NormalizeEquipmentName(string rawName)
    {
        return NormalizeWhitespace(rawName) switch
        {
            var value when value.EndsWith(" A", StringComparison.OrdinalIgnoreCase) => value[..^2] + " Armor",
            var value when value.EndsWith(" G", StringComparison.OrdinalIgnoreCase) => value[..^2] + " Gauntlet",
            var value when value.EndsWith(" H", StringComparison.OrdinalIgnoreCase) => value[..^2] + " Helmet",
            var value when value.EndsWith(" Sh", StringComparison.OrdinalIgnoreCase) => value[..^3] + " Shield",
            _ => NormalizeWhitespace(rawName)
        };
    }

    private static string NormalizeSpellName(string rawName)
    {
        return NormalizeWhitespace(rawName) switch
        {
            "Ice B" => "Ice Book",
            "Fog B" => "Fog Book",
            "Sleep B" => "Sleep Book",
            "Prayer B" => "Prayer Book",
            "Cure B" => "Cure Book",
            _ => NormalizeWhitespace(rawName)
        };
    }

    private static string NormalizeItemName(string rawName)
    {
        return NormalizeWhitespace(rawName) switch
        {
            "Cure P" => "Cure Potion",
            "X-Cure P" => "X-Cure Potion",
            "EyeDrop P" => "Eye Drop Potion",
            "Soft P" => "Soft Potion",
            "Curse P" => "Curse Potion",
            _ => NormalizeWhitespace(rawName)
        };
    }

    private static string NormalizeWhitespace(string value)
    {
        return WhitespaceRegex().Replace(value.Trim(), " ");
    }

    private static string JoinDistinct(IEnumerable<string> values)
    {
        return string.Join(
            "; ",
            values
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(value => value, StringComparer.OrdinalIgnoreCase));
    }

    [GeneratedRegex(@"^\*\*\*(?<id>\d+)\.(?<title>.+?)\*\*\*$", RegexOptions.Compiled)]
    private static partial Regex HeadingRegex();

    [GeneratedRegex(@"^(?<sub>[a-z])\.(?<title>[A-Z].+)$", RegexOptions.Compiled)]
    private static partial Regex SubsectionRegex();

    [GeneratedRegex(@"^Weapons? Shop\s+Item Shop$", RegexOptions.Compiled)]
    private static partial Regex ShopHeaderRegex();

    [GeneratedRegex(@"(?<name>[A-Za-z0-9\- ]+?)\s+x(?<uses>-|\d+)\s+(?<cost>\d+)\s+GP", RegexOptions.Compiled)]
    private static partial Regex ShopEntryRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex WhitespaceRegex();

    [GeneratedRegex(@" [AGH]$| Sh$", RegexOptions.Compiled)]
    private static partial Regex EquipmentRegex();

    private sealed record ShopEntry(
        string Category,
        string Name,
        string Uses,
        string Cost,
        string Availability,
        string Notes,
        string SourceGuides);
}
