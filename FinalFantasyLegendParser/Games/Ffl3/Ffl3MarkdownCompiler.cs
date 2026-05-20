using System.Text;

namespace FinalFantasyLegendParser.Games.Ffl3;

internal sealed class Ffl3MarkdownCompiler
{
    public string Compile(
        Ffl3SystemData systemData,
        IReadOnlyList<Ffl3CharacterRecord> characters,
        IReadOnlyList<Ffl3StoryLocationRecord> storyLocations,
        IReadOnlyList<Ffl3MonsterRecord> monsters,
        IReadOnlyList<Ffl3EquipmentRecord> equipment,
        IReadOnlyList<Ffl3ItemRecord> items,
        IReadOnlyList<Ffl3SpellRecord> spells,
        IReadOnlyList<Ffl3AbilityRecord> abilities,
        IReadOnlyList<Ffl3StatusEffectRecord> statusEffects)
    {
        var builder = new StringBuilder();

        builder.AppendLine("# Final Fantasy Legend 3 - Complete LLM Guide");
        builder.AppendLine();
        builder.AppendLine("**Version**: 0.2");
        builder.AppendLine();
        builder.AppendLine("**Sources**: 47306_Game_Lists.txt and 80317_Glitchless_Walkthrough.txt.");
        builder.AppendLine();
        builder.AppendLine("**Notes**: This parser-generated FFL3 reference combines formula and system notes with structured equipment, spells, talents, status conditions, species tables, walkthrough-derived route items plus equipment and spell acquisitions, and chronology-linked story mentions.");
        builder.AppendLine();
        builder.AppendLine("## Sections");
        builder.AppendLine();
        builder.AppendLine("- Attack Properties and Damage Rules");
        builder.AppendLine("- Stats and Upgrades");
        builder.AppendLine("- Class and Progression Differences");
        builder.AppendLine("- Changing Class");
        builder.AppendLine("- Story Chronology");
        builder.AppendLine("- Characters");
        builder.AppendLine("- Equipment");
        builder.AppendLine("- Items");
        builder.AppendLine("- Spells");
        builder.AppendLine("- Abilities");
        builder.AppendLine("- Status Effects");
        builder.AppendLine("- Monster and Species Tables");
        builder.AppendLine("- Formula Reference");
        builder.AppendLine("- Robot Capsules");
        builder.AppendLine("- Talon Units");
        builder.AppendLine();

        AppendMechanicsSections(builder, systemData.Mechanics);

        builder.AppendLine("## Story Chronology");
        builder.AppendLine();
        foreach (var location in storyLocations.OrderBy(location => location.Order))
        {
            builder.AppendLine($"### {location.Order}. {location.LocationName}");
            builder.AppendLine();
            builder.AppendLine($"- **Section**: {location.SectionId}");
            builder.AppendLine($"- **World**: {FormatValue(location.World)}");
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
            builder.AppendLine($"- **{character.CharacterName}** ({character.CharacterType}) - Class: {FormatValue(character.StartingClass)}; Element: {FormatValue(character.InnateElement)}; {character.Description}");
        }

        builder.AppendLine();
        builder.AppendLine("## Equipment");
        builder.AppendLine();
        foreach (var row in equipment.OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category} / {row.Subcategory}] - Cost: {FormatValue(row.Cost)}; {row.Details}");
        }

        builder.AppendLine();
        builder.AppendLine("## Items");
        builder.AppendLine();
        foreach (var row in items.OrderBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - Availability: {FormatValue(row.Availability)}; Notes: {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Spells");
        builder.AppendLine();
        foreach (var row in spells.OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - Cost: {FormatValue(row.Cost)}; MP: {FormatValue(row.Mp)}; {row.Details}");
        }

        builder.AppendLine();
        builder.AppendLine("## Abilities");
        builder.AppendLine();
        foreach (var row in abilities.OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - {row.Details}");
        }

        builder.AppendLine();
        builder.AppendLine("## Status Effects");
        builder.AppendLine();
        foreach (var row in statusEffects.OrderBy(row => row.StatusEffect, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.StatusEffect}** - {row.Description} {FormatValue(row.Notes)}");
        }

        builder.AppendLine();
        builder.AppendLine("## Monster and Species Tables");
        builder.AppendLine();
        foreach (var row in monsters.OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.LevelRange, StringComparer.OrdinalIgnoreCase).ThenBy(row => row.SpeciesName, StringComparer.OrdinalIgnoreCase))
        {
            builder.AppendLine($"- **{row.SpeciesName}** [{row.Category}] - Level range: {row.LevelRange}; Element: {row.Element}");
        }

        builder.AppendLine();
        builder.AppendLine("## Formula Reference");
        builder.AppendLine();
        foreach (var row in systemData.Formulas)
        {
            builder.AppendLine($"- **{row.FormulaName}** [{row.Category}] - {row.Expression} Notes: {row.Notes}");
        }

        builder.AppendLine();
        builder.AppendLine("## Robot Capsules");
        builder.AppendLine();
        foreach (var row in systemData.RobotCapsules)
        {
            builder.AppendLine($"- **{row.Capsule}** - Cost: {row.Cost}; Effect: {row.Effect}; Bought: {row.Bought}");
        }

        builder.AppendLine();
        builder.AppendLine("## Talon Units");
        builder.AppendLine();
        foreach (var row in systemData.TalonUnits)
        {
            builder.AppendLine($"- **{row.Name}** [{row.Category}] - {row.Effect}; Found: {row.Found}");
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
