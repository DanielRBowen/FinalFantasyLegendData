namespace FinalFantasyLegendParser.Core;

internal static class ElementCodec
{
    private static readonly (int Index, string Name)[] ElementOrder =
    [
        (0, "Fire"),
        (1, "Ice"),
        (2, "Elem"),
        (3, "Poison"),
        (4, "Stone"),
        (5, "Para"),
        (6, "Weapon"),
        (7, "Quake")
    ];

    public static string DecodeFlags(string? flags)
    {
        if (string.IsNullOrWhiteSpace(flags))
        {
            return string.Empty;
        }

        var normalized = flags.Trim();

        if (normalized.Length < ElementOrder.Length)
        {
            return normalized;
        }

        var values = new List<string>();

        foreach (var (index, name) in ElementOrder)
        {
            if (normalized[index] != '-')
            {
                values.Add(name);
            }
        }

        return string.Join("; ", values);
    }
}
