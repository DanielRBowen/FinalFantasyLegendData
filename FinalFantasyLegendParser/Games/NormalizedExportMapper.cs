using System.Text.RegularExpressions;
using FinalFantasyLegendParser.Games.Ffl1;
using FinalFantasyLegendParser.Games.Ffl2;
using FinalFantasyLegendParser.Games.Ffl3;

namespace FinalFantasyLegendParser.Games;

internal static partial class NormalizedExportMapper
{
    public static NormalizedMonsterRecord ToNormalized(this Ffl1MonsterRecord row)
    {
        return new NormalizedMonsterRecord(
            row.MonsterName,
            row.MonsterFamily,
            string.Empty,
            string.Empty,
            row.HP.ToString(),
            row.Strength.ToString(),
            row.Agility.ToString(),
            row.Mana.ToString(),
            row.Defense.ToString(),
            row.Gold.ToString(),
            row.Resistances,
            row.Weaknesses,
            string.Empty,
            $"Index: {row.IndexHex}",
            row.SourceGuide);
    }

    public static NormalizedMonsterRecord ToNormalized(this Ffl2MonsterRecord row)
    {
        return new NormalizedMonsterRecord(
            row.MonsterName,
            string.Empty,
            string.Empty,
            row.Tier.ToString(),
            row.HP.ToString(),
            row.Strength.ToString(),
            row.Agility.ToString(),
            row.Mana.ToString(),
            row.Defense.ToString(),
            string.Empty,
            string.Empty,
            string.Empty,
            row.Abilities,
            string.Empty,
            row.SourceGuide);
    }

    public static NormalizedMonsterRecord ToNormalized(this Ffl3MonsterRecord row)
    {
        return new NormalizedMonsterRecord(
            row.SpeciesName,
            row.Category,
            row.LevelRange,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Element,
            string.Empty,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedEquipmentRecord ToNormalized(this Ffl1EquipmentRecord row)
    {
        return new NormalizedEquipmentRecord(
            row.Category,
            row.Name,
            row.Uses,
            string.Empty,
            row.IndexHex,
            row.Availability,
            row.Targeting,
            row.PrimaryEffect,
            row.SecondaryEffect,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedEquipmentRecord ToNormalized(this Ffl2EquipmentRecord row)
    {
        return new NormalizedEquipmentRecord(
            row.Category,
            row.Name,
            row.Uses,
            row.Cost,
            string.Empty,
            row.Availability,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Notes,
            row.SourceGuides);
    }

    public static NormalizedEquipmentRecord ToNormalized(this Ffl3EquipmentRecord row)
    {
        return new NormalizedEquipmentRecord(
            string.IsNullOrWhiteSpace(row.Subcategory) ? row.Category : row.Subcategory,
            row.Name,
            string.Empty,
            row.Cost,
            string.Empty,
            string.Empty,
            GetDetailValue(row.Details, "Target"),
            GetDetailValue(row.Details, "Property"),
            GetDetailValue(row.Details, "Item Magic"),
            BuildResidualDetails(row.Details, "Target", "Property", "Item Magic"),
            row.SourceGuide);
    }

    public static NormalizedItemRecord ToNormalized(this Ffl1ItemRecord row)
    {
        return new NormalizedItemRecord(
            row.Category,
            row.Name,
            row.Uses,
            string.Empty,
            row.IndexHex,
            row.Availability,
            row.Targeting,
            row.PrimaryEffect,
            row.SecondaryEffect,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedItemRecord ToNormalized(this Ffl2ItemRecord row)
    {
        return new NormalizedItemRecord(
            row.Category,
            row.Name,
            row.Uses,
            row.Cost,
            string.Empty,
            row.Availability,
            string.Empty,
            row.PrimaryEffect,
            string.Empty,
            row.Notes,
            row.SourceGuides);
    }

    public static NormalizedItemRecord ToNormalized(this Ffl3ItemRecord row)
    {
        return new NormalizedItemRecord(
            row.Category,
            row.Name,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Availability,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedSpellRecord ToNormalizedSpell(this Ffl1ItemRecord row)
    {
        return new NormalizedSpellRecord(
            row.Category,
            row.Name,
            row.Uses,
            string.Empty,
            string.Empty,
            row.IndexHex,
            row.Availability,
            row.Targeting,
            row.PrimaryEffect,
            row.SecondaryEffect,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedSpellRecord ToNormalizedSpell(this Ffl2ItemRecord row)
    {
        return new NormalizedSpellRecord(
            row.Category,
            row.Name,
            row.Uses,
            row.Cost,
            string.Empty,
            string.Empty,
            row.Availability,
            string.Empty,
            row.PrimaryEffect,
            string.Empty,
            row.Notes,
            row.SourceGuides);
    }

    public static NormalizedSpellRecord ToNormalizedSpell(this Ffl3SpellRecord row)
    {
        return new NormalizedSpellRecord(
            row.Category,
            row.Name,
            string.Empty,
            row.Cost,
            row.Mp,
            string.Empty,
            string.Empty,
            GetDetailValue(row.Details, "Target"),
            FirstNonEmpty(GetDetailValue(row.Details, "Property"), GetDetailValue(row.Details, "Effect")),
            GetDetailValue(row.Details, "SP"),
            BuildResidualDetails(row.Details, "Target", "Property", "Effect", "SP"),
            row.SourceGuide);
    }

    public static NormalizedAbilityRecord ToNormalized(this Ffl1AbilityRecord row)
    {
        return new NormalizedAbilityRecord(
            row.Name,
            string.Empty,
            row.Uses,
            string.Empty,
            row.IndexHex,
            row.Availability,
            row.Targeting,
            row.PrimaryEffect,
            row.SecondaryEffect,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedAbilityRecord ToNormalized(this Ffl2AbilityRecord row)
    {
        return new NormalizedAbilityRecord(
            row.Name,
            row.AbilityType,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Availability,
            string.Empty,
            string.Empty,
            string.Empty,
            row.Notes,
            row.SourceGuides);
    }

    public static NormalizedAbilityRecord ToNormalized(this Ffl3AbilityRecord row)
    {
        return new NormalizedAbilityRecord(
            row.Name,
            row.Category,
            GetDetailValue(row.Details, "TP"),
            string.Empty,
            string.Empty,
            string.Empty,
            GetDetailValue(row.Details, "Target"),
            GetDetailValue(row.Details, "Property"),
            GetDetailValue(row.Details, "Base"),
            BuildResidualDetails(row.Details, "TP", "Target", "Property", "Base"),
            row.SourceGuide);
    }

    public static NormalizedStatusEffectRecord ToNormalized(this Ffl1StatusEffectRecord row)
    {
        return new NormalizedStatusEffectRecord(
            row.StatusEffect,
            row.AppliedBy,
            row.CuredBy,
            row.RelatedElements,
            row.Notes,
            row.SourceGuide);
    }

    public static NormalizedStatusEffectRecord ToNormalized(this Ffl2StatusEffectRecord row)
    {
        return new NormalizedStatusEffectRecord(
            row.StatusEffect,
            row.AppliedBy,
            row.CuredBy,
            string.Empty,
            row.Notes,
            row.SourceGuides);
    }

    public static NormalizedStatusEffectRecord ToNormalized(this Ffl3StatusEffectRecord row)
    {
        return new NormalizedStatusEffectRecord(
            row.StatusEffect,
            string.Empty,
            ExtractRelatedSpells(row.Notes),
            string.Empty,
            FirstNonEmpty(row.Description, row.Notes),
            row.SourceGuides);
    }

    public static NormalizedCharacterRecord ToNormalized(this Ffl1CharacterRecord row)
    {
        return new NormalizedCharacterRecord(
            row.CharacterName,
            row.CharacterType,
            string.Empty,
            string.Empty,
            row.Description,
            row.SourceGuides);
    }

    public static NormalizedCharacterRecord ToNormalized(this Ffl2CharacterRecord row)
    {
        return new NormalizedCharacterRecord(
            row.CharacterName,
            row.CharacterType,
            string.Empty,
            string.Empty,
            row.Description,
            row.SourceGuides);
    }

    public static NormalizedCharacterRecord ToNormalized(this Ffl3CharacterRecord row)
    {
        return new NormalizedCharacterRecord(
            row.CharacterName,
            row.CharacterType,
            row.StartingClass,
            row.InnateElement,
            row.Description,
            row.SourceGuides);
    }

    private static string BuildResidualDetails(string details, params string[] ignoredLabels)
    {
        var ignored = ignoredLabels.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var parts = details
            .Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Where(part =>
            {
                var index = part.IndexOf(':');
                return index < 0 || !ignored.Contains(part[..index].Trim());
            })
            .ToList();

        return string.Join("; ", parts);
    }

    private static string GetDetailValue(string details, string label)
    {
        var match = DetailLabelRegex().Matches(details)
            .Cast<Match>()
            .FirstOrDefault(match => match.Groups["label"].Value.Equals(label, StringComparison.OrdinalIgnoreCase));

        return match?.Groups["value"].Value.Trim() ?? string.Empty;
    }

    private static string ExtractRelatedSpells(string notes)
    {
        const string prefix = "Related spells:";
        return notes.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
            ? notes[prefix.Length..].Trim()
            : string.Empty;
    }

    private static string FirstNonEmpty(params string[] values)
    {
        return values.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value)) ?? string.Empty;
    }

    [GeneratedRegex(@"(?<label>[^:;]+):\s*(?<value>[^;]+)", RegexOptions.Compiled)]
    private static partial Regex DetailLabelRegex();
}