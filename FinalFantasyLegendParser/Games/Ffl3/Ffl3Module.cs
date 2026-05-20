using System.Text;
using FinalFantasyLegendParser.Core;
using FinalFantasyLegendParser.Games.Ffl3.Parsers;

namespace FinalFantasyLegendParser.Games.Ffl3;

internal sealed class Ffl3Module : IGameModule
{
    public string Key => "ffl3";

    public async Task<int> RunAsync(GameModuleContext context)
    {
        Directory.CreateDirectory(context.OutputDirectory);

        var systemParser = new Ffl3SystemParser();
        var systemData = systemParser.Parse();

        var gameListsParser = new Ffl3GameListsParser();
        var guideData = gameListsParser.Parse(context.RepositoryRoot);
        var characters = BuildCharacters(guideData.Characters);
        var entityCandidates = BuildEntityCandidates(characters, guideData.Monsters, guideData.Equipment, guideData.Spells, guideData.Abilities, guideData.StatusEffects);

        var walkthroughParser = new Ffl3WalkthroughParser();
        var walkthroughData = walkthroughParser.Parse(context.RepositoryRoot, entityCandidates);

        var markdownCompiler = new Ffl3MarkdownCompiler();
        var markdown = markdownCompiler.Compile(
            systemData,
            characters,
            walkthroughData.StoryLocations,
            guideData.Monsters,
            guideData.Equipment,
            walkthroughData.Items,
            guideData.Spells,
            guideData.Abilities,
            guideData.StatusEffects);

        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Mechanics.csv"), systemData.Mechanics);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Formula_Reference.csv"), systemData.Formulas);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Robot_Capsules.csv"), systemData.RobotCapsules);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Talon_Units.csv"), systemData.TalonUnits);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Equipment.csv"), guideData.Equipment);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Items.csv"), walkthroughData.Items);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Spells.csv"), guideData.Spells);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Abilities.csv"), guideData.Abilities);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_StatusEffects.csv"), guideData.StatusEffects);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Characters.csv"), characters);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Monsters.csv"), guideData.Monsters);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Story_Chronology.csv"), walkthroughData.StoryLocations);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL3_Entity_Story_Appearances.csv"), walkthroughData.StoryAppearances);
        await File.WriteAllTextAsync(Path.Combine(context.OutputDirectory, "FFL3_Complete_LLM_Guide.markdown"), markdown, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), context.CancellationToken);

        await context.Output.WriteLineAsync("Generated FFL3 structured reference files:");
        await context.Output.WriteLineAsync($"- Mechanics notes: {systemData.Mechanics.Count}");
        await context.Output.WriteLineAsync($"- Formula rows: {systemData.Formulas.Count}");
        await context.Output.WriteLineAsync($"- Robot capsules: {systemData.RobotCapsules.Count}");
        await context.Output.WriteLineAsync($"- Talon units: {systemData.TalonUnits.Count}");
        await context.Output.WriteLineAsync($"- Equipment: {guideData.Equipment.Count}");
        await context.Output.WriteLineAsync($"- Items: {walkthroughData.Items.Count}");
        await context.Output.WriteLineAsync($"- Spells: {guideData.Spells.Count}");
        await context.Output.WriteLineAsync($"- Abilities: {guideData.Abilities.Count}");
        await context.Output.WriteLineAsync($"- Status effects: {guideData.StatusEffects.Count}");
        await context.Output.WriteLineAsync($"- Characters: {characters.Count}");
        await context.Output.WriteLineAsync($"- Monsters/species: {guideData.Monsters.Count}");
        await context.Output.WriteLineAsync($"- Story locations: {walkthroughData.StoryLocations.Count}");
        await context.Output.WriteLineAsync($"- Story entity links: {walkthroughData.StoryAppearances.Count}");
        await context.Output.WriteLineAsync($"Output directory: {context.OutputDirectory}");
        return 0;
    }

    private static IReadOnlyList<Ffl3CharacterRecord> BuildCharacters(IReadOnlyList<Ffl3CharacterRecord> mainCharacters)
    {
        var extraCharacters = new List<Ffl3CharacterRecord>
        {
            new("Myron", "NPC Ally", string.Empty, string.Empty, "Early guest ally and route-stable healer in the opening sequence.", "80317_Glitchless_Walkthrough.txt"),
            new("Lara", "NPC Ally", string.Empty, string.Empty, "Temporary ally through the southern cave and Dogra sequence.", "80317_Glitchless_Walkthrough.txt"),
            new("Dion", "NPC Ally", string.Empty, string.Empty, "Late temporary ally recruited in Viper City.", "80317_Glitchless_Walkthrough.txt"),
            new("Chronos", "NPC", string.Empty, string.Empty, "Key time-travel NPC who grants progression items.", "80317_Glitchless_Walkthrough.txt"),
            new("Granny", "NPC", string.Empty, string.Empty, "Recurring NPC who supplies key travel spells.", "80317_Glitchless_Walkthrough.txt"),
            new("Water Hag", "Boss", string.Empty, string.Empty, "Early boss encountered near Talon Shrine.", "80317_Glitchless_Walkthrough.txt"),
            new("Dogra", "Boss", string.Empty, string.Empty, "Boss fought after Lara joins in the southern cave arc.", "80317_Glitchless_Walkthrough.txt"),
            new("Ashura", "Boss", string.Empty, string.Empty, "South Tower boss in the present timeline.", "80317_Glitchless_Walkthrough.txt"),
            new("Chaos", "Boss", string.Empty, string.Empty, "Castle of Chaos boss and major difficulty spike.", "80317_Glitchless_Walkthrough.txt"),
            new("Maitreya", "Boss", string.Empty, string.Empty, "Floatland tower boss guarding the X-Plane unit.", "80317_Glitchless_Walkthrough.txt"),
            new("Fenrir", "Boss", string.Empty, string.Empty, "Eitar Prison boss in Pureland progression.", "80317_Glitchless_Walkthrough.txt"),
            new("Guha", "Boss", string.Empty, string.Empty, "Mount Hasid boss.", "80317_Glitchless_Walkthrough.txt"),
            new("Dahak", "Boss", string.Empty, string.Empty, "Southwest Ruins boss.", "80317_Glitchless_Walkthrough.txt"),
            new("Jorgandr", "Boss", string.Empty, string.Empty, "Frost Cape boss before Talonsburg.", "80317_Glitchless_Walkthrough.txt"),
            new("Agron", "Boss", string.Empty, string.Empty, "Barrier Machine Cave boss in the underworld segment.", "80317_Glitchless_Walkthrough.txt"),
            new("Balor", "Boss", string.Empty, string.Empty, "Goht Castle boss on the path to Sol.", "80317_Glitchless_Walkthrough.txt"),
            new("Sol", "Boss", string.Empty, string.Empty, "Late-game boss in the final approach.", "80317_Glitchless_Walkthrough.txt"),
            new("Xagor", "Final Boss", string.Empty, string.Empty, "Final boss fought with Sol in the endgame section.", "80317_Glitchless_Walkthrough.txt"),
            new("Darius", "NPC", string.Empty, string.Empty, "Pureland story NPC tied to city progression.", "80317_Glitchless_Walkthrough.txt"),
            new("Dr. Pulcer", "NPC", string.Empty, string.Empty, "Scientist NPC tied to Talon communication and undersea base progression.", "80317_Glitchless_Walkthrough.txt"),
            new("Dr. Belksi", "NPC", string.Empty, string.Empty, "Future-era base NPC used for healing and route setup.", "80317_Glitchless_Walkthrough.txt")
        };

        return mainCharacters
            .Concat(extraCharacters)
            .GroupBy(character => character.CharacterName, StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .OrderBy(character => character.CharacterName, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl3WalkthroughParser.StoryEntityCandidate> BuildEntityCandidates(
        IReadOnlyList<Ffl3CharacterRecord> characters,
        IReadOnlyList<Ffl3MonsterRecord> monsters,
        IReadOnlyList<Ffl3EquipmentRecord> equipment,
        IReadOnlyList<Ffl3SpellRecord> spells,
        IReadOnlyList<Ffl3AbilityRecord> abilities,
        IReadOnlyList<Ffl3StatusEffectRecord> statusEffects)
    {
        var candidates = new List<Ffl3WalkthroughParser.StoryEntityCandidate>();

        candidates.AddRange(characters.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("Character", row.CharacterName)));
        candidates.AddRange(monsters.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("Monster", row.SpeciesName)));
        candidates.AddRange(equipment.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("Equipment", row.Name)));
        candidates.AddRange(spells.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("Spell", row.Name)));
        candidates.AddRange(abilities.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("Ability", row.Name)));
        candidates.AddRange(statusEffects.Select(row => new Ffl3WalkthroughParser.StoryEntityCandidate("StatusEffect", row.StatusEffect)));

        return candidates
            .GroupBy(candidate => $"{candidate.EntityType}|{candidate.EntityName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();
    }
}
