using System.Text;

namespace FinalFantasyLegendParser.Games.Ffl2;

internal sealed class Ffl2MarkdownCompiler
{
    public string Compile(
        Ffl2SystemData systemData,
        IReadOnlyList<Ffl2CharacterRecord> characters,
        IReadOnlyList<Ffl2StoryLocationRecord> storyLocations,
        IReadOnlyList<Ffl2MonsterRecord> monsters,
        IReadOnlyList<Ffl2EquipmentRecord> equipment,
        IReadOnlyList<Ffl2ItemRecord> items,
        IReadOnlyList<Ffl2ItemRecord> spells,
        IReadOnlyList<Ffl2AbilityRecord> abilities,
        IReadOnlyList<Ffl2StatusEffectRecord> statusEffects)
    {
        var builder = new StringBuilder();

        builder.AppendLine("# Final Fantasy Legend 2 - Complete LLM Guide");
        builder.AppendLine();
        builder.AppendLine("**Version**: 0.2");
        builder.AppendLine();
        builder.AppendLine("**Sources**: 12292_Guide_and_Walkthrough.txt, 29741_Robot_Guide.txt, and 16852_Monster_Evolution_FAQ.txt.");
        builder.AppendLine();
        builder.AppendLine("**Notes**: This parser-generated FFL2 reference now combines system notes with structured monsters, shop-derived equipment and item lists, status data, and a walkthrough chronology linked to named entities.");
        builder.AppendLine();
        builder.AppendLine("## Sections");
        builder.AppendLine();
        builder.AppendLine("- Combat and Damage Rules");
        builder.AppendLine("- Character Progression");
        builder.AppendLine("- Enhancement and Class Differences");
        builder.AppendLine("- Extra System Notes");
        builder.AppendLine("- Story Chronology");
        builder.AppendLine("- Characters");
        builder.AppendLine("- Equipment");
        builder.AppendLine("- Items");
        builder.AppendLine("- Spells and Books");
        builder.AppendLine("- Abilities");
        builder.AppendLine("- Status Effects");
        builder.AppendLine("- Monsters");
        builder.AppendLine("- Class Progression Summary");
        builder.AppendLine("- Mutant Skill Tiers");
        builder.AppendLine();

        AppendMechanicsSections(builder, systemData.Mechanics);

        builder.AppendLine("## Story Chronology");
        builder.AppendLine();
        foreach (var location in storyLocations.OrderBy(location => location.Order))
        {
            builder.AppendLine($"### {location.Order}. {location.LocationName}");
            builder.AppendLine();

            if (!string.IsNullOrWhiteSpace(location.LocationContext))
            {
                builder.AppendLine($"- **Context**: {location.LocationContext}");
            }

            builder.AppendLine($"- **Section**: {location.SectionId}");
            builder.AppendLine($"- **Summary**: {location.Summary}");

            AppendMentionLine(builder, "Characters", location.MentionedCharacters);
            AppendMentionLine(builder, "Monsters", location.MentionedMonsters);
            AppendMentionLine(builder, "Items", location.MentionedItems);
            AppendMentionLine(builder, "Equipment", location.MentionedEquipment);
            AppendMentionLine(builder, "Spells", location.MentionedSpells);
            AppendMentionLine(builder, "Abilities", location.MentionedAbilities);
            AppendMentionLine(builder, "Status Effects", location.MentionedStatusEffects);
            builder.AppendLine();
        }

        builder.AppendLine("## Characters");
        builder.AppendLine();
        foreach (var character in characters.OrderBy(character => character.CharacterName, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{character.CharacterName}** ({character.CharacterType}) - {character.Description}");
        }

        builder.AppendLine();
        builder.AppendLine("## Equipment");
        builder.AppendLine();
        foreach (var row in equipment.OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - Uses: {FormatValue(row.Uses)}; Cost: {FormatValue(row.Cost)}; Availability: {FormatValue(row.Availability)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Items");
        builder.AppendLine();
        foreach (var row in items.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** - Uses: {FormatValue(row.Uses)}; Cost: {FormatValue(row.Cost)}; Availability: {FormatValue(row.Availability)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Spells and Books");
        builder.AppendLine();
        foreach (var row in spells.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** - Uses: {FormatValue(row.Uses)}; Cost: {FormatValue(row.Cost)}; Availability: {FormatValue(row.Availability)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Abilities");
        builder.AppendLine();
        foreach (var row in abilities.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.AbilityType}] - Availability: {FormatValue(row.Availability)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Status Effects");
        builder.AppendLine();
        foreach (var row in statusEffects.OrderBy(row => row.StatusEffect, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.StatusEffect}** - Cured by: {FormatValue(row.CuredBy)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Monsters");
        builder.AppendLine();
        foreach (var row in monsters.OrderBy(row => row.MonsterName, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.MonsterName}** - Tier: {row.Tier}; HP: {row.HP}; STR: {row.Strength}; AGL: {row.Agility}; MAN: {row.Mana}; DEF: {row.Defense}; Abilities: {FormatValue(row.Abilities)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Class Progression Summary");
        builder.AppendLine();
        foreach (var row in systemData.ClassProgressions)
        {
            builder.AppendLine($"- **{row.ClassName}** - Growth: {row.GrowthModel} Enhancement: {row.EnhancementMethods} Constraints: {row.Constraints}");
        }

        builder.AppendLine();
        builder.AppendLine("## Mutant Skill Tiers");
        builder.AppendLine();
        foreach (var row in systemData.MutantSkillTiers)
        {
            builder.AppendLine($"- **{row.DsTier}** - {row.Abilities} ({row.Notes})");
        }

        return builder.ToString();
    }

    private static void AppendMechanicsSections(StringBuilder builder, IReadOnlyList<GuideMechanicRecord> mechanics)
    {
        foreach (var section in mechanics
                     .OrderBy(record => record.SectionOrder)
                     .ThenBy(record => record.EntryOrder)
                     .GroupBy(record => record.SectionTitle, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"## {section.Key}");
            builder.AppendLine();

            foreach (var entry in section)
            {
                builder.AppendLine($"- **{entry.Topic}**: {entry.Details}");
                builder.AppendLine($"  Sources: {entry.SourceGuides}");
            }

            builder.AppendLine();
        }
    }

    private static void AppendMentionLine(StringBuilder builder, string label, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            builder.AppendLine($"- **{label}**: {value}");
        }
    }

    private static string FormatValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "None" : value;
    }
}
