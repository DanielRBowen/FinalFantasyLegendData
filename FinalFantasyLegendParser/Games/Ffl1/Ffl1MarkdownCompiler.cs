using System.Text;

namespace FinalFantasyLegendParser.Games.Ffl1;

internal sealed class Ffl1MarkdownCompiler
{
    public string Compile(
        IReadOnlyList<GuideMechanicRecord> mechanics,
        IReadOnlyList<Ffl1CharacterRecord> characters,
        IReadOnlyList<Ffl1StoryLocationRecord> storyLocations,
        IReadOnlyList<Ffl1MonsterRecord> monsters,
        IReadOnlyList<Ffl1EquipmentRecord> equipment,
        IReadOnlyList<Ffl1ItemRecord> items,
        IReadOnlyList<Ffl1ItemRecord> spells,
        IReadOnlyList<Ffl1AbilityRecord> abilities,
        IReadOnlyList<Ffl1StatusEffectRecord> statusEffects)
    {
        var builder = new StringBuilder();

        builder.AppendLine("# Final Fantasy Legend 1 - Initial LLM-Friendly Guide");
        builder.AppendLine();
        builder.AppendLine("**Version**: 0.2");
        builder.AppendLine();
        builder.AppendLine("**Sources**: Compiled from the initial FFL1 parser sources: 21924_Monster_Inventory_FAQ.txt, 31005_Guide_and_Walkthrough.txt, 5829_Guide_and_Walkthrough.txt, 8347_Human_FAQ.txt, 8348_Mutant_FAQ.txt, and 16731_Meat_Transformations_FAQ.txt.");
        builder.AppendLine();
        builder.AppendLine("**Notes**: This parser-generated FFL1 reference now includes battle rules, progression notes, and stat-growth guidance alongside the structured entity and chronology data. Story links remain mention-based and are meant to be extended as more FFL1 guides are added.");
        builder.AppendLine();
        builder.AppendLine("## Sections");
        builder.AppendLine();
        builder.AppendLine("- Battle Calculations and Combat Rules");
        builder.AppendLine("- Character Progression");
        builder.AppendLine("- Stat and Ability Enhancement");
        builder.AppendLine("- Game-Specific System Notes");
        builder.AppendLine("- Story Chronology");
        builder.AppendLine("- Characters");
        builder.AppendLine("- Equipment");
        builder.AppendLine("- Items");
        builder.AppendLine("- Spells and Books");
        builder.AppendLine("- Abilities");
        builder.AppendLine("- Status Effects");
        builder.AppendLine("- Monsters");
        builder.AppendLine();

        AppendMechanicsSections(builder, mechanics);

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
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - Uses: {FormatValue(row.Uses)}; Effect: {FormatValue(row.PrimaryEffect)}; Extra: {FormatValue(row.SecondaryEffect)}; Notes: {FormatValue(row.Notes)}");
        }
        builder.AppendLine();

        builder.AppendLine("## Items");
        builder.AppendLine();
        foreach (var row in items.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** - Uses: {FormatValue(row.Uses)}; Effect: {FormatValue(row.PrimaryEffect)}; Extra: {FormatValue(row.SecondaryEffect)}");
        }
        builder.AppendLine();

        builder.AppendLine("## Spells and Books");
        builder.AppendLine();
        foreach (var row in spells.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** - Uses: {FormatValue(row.Uses)}; Effect: {FormatValue(row.PrimaryEffect)}; Extra: {FormatValue(row.SecondaryEffect)}; Notes: {FormatValue(row.Notes)}");
        }
        builder.AppendLine();

        builder.AppendLine("## Abilities");
        builder.AppendLine();
        foreach (var row in abilities.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** - Uses: {FormatValue(row.Uses)}; Effect: {FormatValue(row.PrimaryEffect)}; Extra: {FormatValue(row.SecondaryEffect)}; Notes: {FormatValue(row.Notes)}");
        }
        builder.AppendLine();

        builder.AppendLine("## Status Effects");
        builder.AppendLine();
        foreach (var row in statusEffects.OrderBy(row => row.StatusEffect, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.StatusEffect}** - Applied by: {FormatValue(row.AppliedBy)}; Cured by: {FormatValue(row.CuredBy)}; Related elements: {FormatValue(row.RelatedElements)}");
        }
        builder.AppendLine();

        builder.AppendLine("## Monsters");
        builder.AppendLine();
        foreach (var row in monsters.OrderBy(row => row.MonsterName, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.MonsterName}** - HP: {row.HP}; STR: {row.Strength}; AGL: {row.Agility}; MAN: {row.Mana}; DEF: {row.Defense}; Gold: {row.Gold}; Resistances: {FormatValue(row.Resistances)}; Weaknesses: {FormatValue(row.Weaknesses)}; Family: {FormatValue(row.MonsterFamily)}");
        }

        return builder.ToString();
    }

    private static void AppendMentionLine(StringBuilder builder, string label, string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            builder.AppendLine($"- **{label}**: {value}");
        }
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

    private static string FormatValue(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "None" : value;
    }
}
