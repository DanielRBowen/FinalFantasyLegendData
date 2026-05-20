using System.Globalization;

namespace FinalFantasyLegendParser.Core;

internal static class NameNormalizer
{
    private static readonly Dictionary<string, string> NameOverrides = new(StringComparer.OrdinalIgnoreCase)
    {
        ["h"] = "Heart",
        ["s"] = "Shoes",
        ["XCLBR"] = "Xcalibur",
        ["MASMUNE"] = "Masmune",
        ["XPOTION"] = "X-Potion",
        ["ANTDOTE"] = "Antidote",
        ["L-SABER"] = "L-Saber",
        ["P-KNIFE"] = "P-Knife",
        ["P-SWORD"] = "P-Sword",
        ["GR. BOW"] = "Great Bow",
        ["AEZIS"] = "Aezis",
        ["ATHTALOT"] = "Athtalot",
        ["MOU-JYA"] = "Mou-Jya",
        ["SEI-RYU"] = "Sei-Ryu",
        ["BYAK-KO"] = "Byak-Ko",
        ["SU-ZAKU"] = "Su-Zaku",
        ["GEN-BU"] = "Gen-Bu",
        ["KO-RUN"] = "Ko-Run",
        ["P-FROG"] = "P-Frog",
        ["P-WORM"] = "P-Worm",
        ["O-BAKE"] = "O-Bake",
        ["HI-SLIME"] = "Hi-Slime",
        ["P-BLAST"] = "P-Blast",
        ["D-BEAM"] = "D-Beam",
        ["LIGHT"] = "Light",
        ["REPENT"] = "Repent"
    };

    private static readonly Dictionary<string, string> StatusOverrides = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Blin"] = "Blind",
        ["Conf"] = "Confusion",
        ["Curs"] = "Curse",
        ["Dead"] = "Death",
        ["Para"] = "Paralysis",
        ["Pois"] = "Poison",
        ["Slep"] = "Sleep",
        ["Ston"] = "Stone"
    };

    public static string NormalizeInventoryName(string rawName)
    {
        if (string.IsNullOrWhiteSpace(rawName))
        {
            return string.Empty;
        }

        var working = rawName.Trim();

        if (working.StartsWith('/'))
        {
            working = working[1..];
        }

        if (working.Length > 1 && char.IsLower(working[0]) && char.IsUpper(working[1]))
        {
            working = working[1..];
        }

        if (NameOverrides.TryGetValue(rawName.Trim(), out var rawOverrideName))
        {
            return rawOverrideName;
        }

        if (NameOverrides.TryGetValue(working, out var overrideName))
        {
            return overrideName;
        }

        var textInfo = CultureInfo.InvariantCulture.TextInfo;
        return textInfo.ToTitleCase(working.ToLowerInvariant());
    }

    public static string NormalizeMonsterName(string rawName)
    {
        var trimmed = rawName.Trim();
        return NameOverrides.TryGetValue(trimmed, out var overrideName)
            ? overrideName
            : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(trimmed.ToLowerInvariant());
    }

    public static string NormalizeStatus(string rawStatus)
    {
        var trimmed = rawStatus.Trim();
        return StatusOverrides.TryGetValue(trimmed, out var overrideName) ? overrideName : trimmed;
    }
}
