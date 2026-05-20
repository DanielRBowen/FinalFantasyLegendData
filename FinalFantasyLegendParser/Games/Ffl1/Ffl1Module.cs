using System.Text;
using FinalFantasyLegendParser.Core;
using FinalFantasyLegendParser.Games;
using FinalFantasyLegendParser.Games.Ffl1.Parsers;

namespace FinalFantasyLegendParser.Games.Ffl1;

internal sealed class Ffl1Module : IGameModule
{
    public string Key => "ffl1";

    public async Task<int> RunAsync(GameModuleContext context)
    {
        Directory.CreateDirectory(context.OutputDirectory);

        var mechanicsParser = new Ffl1MechanicsParser();
        var mechanics = mechanicsParser.Parse();

        var inventoryParser = new Ffl1MonsterInventoryFaqParser();
        var inventoryResult = inventoryParser.Parse(context.RepositoryRoot);
        var spells = inventoryResult.Items.Where(item => item.Category.Equals("Spell/Book", StringComparison.OrdinalIgnoreCase)).ToList();
        var items = inventoryResult.Items.Where(item => !item.Category.Equals("Spell/Book", StringComparison.OrdinalIgnoreCase)).ToList();

        var characterParser = new Ffl1CharacterParser();
        var characters = characterParser.Parse(context.RepositoryRoot);

        var entityCandidates = BuildEntityCandidates(characters, inventoryResult.Monsters, inventoryResult.Equipment, items, spells, inventoryResult.Abilities, inventoryResult.StatusEffects);

        var walkthroughParser = new Ffl1WalkthroughParser();
        var walkthroughResult = walkthroughParser.Parse(context.RepositoryRoot, entityCandidates);

        var markdownCompiler = new Ffl1MarkdownCompiler();
        var markdown = markdownCompiler.Compile(
            mechanics,
            characters,
            walkthroughResult.StoryLocations,
            inventoryResult.Monsters,
            inventoryResult.Equipment,
            items,
            spells,
            inventoryResult.Abilities,
            inventoryResult.StatusEffects);

        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Monsters.csv"), inventoryResult.Monsters.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Equipment.csv"), inventoryResult.Equipment.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Items.csv"), items.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Spells.csv"), spells.Select(row => row.ToNormalizedSpell()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Abilities.csv"), inventoryResult.Abilities.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_StatusEffects.csv"), inventoryResult.StatusEffects.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Characters.csv"), characters.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Mechanics.csv"), mechanics);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Story_Chronology.csv"), walkthroughResult.StoryLocations);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL1_Entity_Story_Appearances.csv"), walkthroughResult.StoryAppearances);
        var outputMarkdownPath = Path.Combine(context.OutputDirectory, "FFL1_Complete_LLM_Guide.markdown");
        var repositoryMarkdownPath = Path.Combine(context.RepositoryRoot, "FFL1", "FFL1_Complete_LLM_Guide.markdown");
        var utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        await File.WriteAllTextAsync(outputMarkdownPath, markdown, utf8Encoding, context.CancellationToken);
        await File.WriteAllTextAsync(repositoryMarkdownPath, markdown, utf8Encoding, context.CancellationToken);

        await context.Output.WriteLineAsync("Generated FFL1 structured reference files:");
        await context.Output.WriteLineAsync($"- Monsters: {inventoryResult.Monsters.Count}");
        await context.Output.WriteLineAsync($"- Equipment: {inventoryResult.Equipment.Count}");
        await context.Output.WriteLineAsync($"- Items: {items.Count}");
        await context.Output.WriteLineAsync($"- Spells: {spells.Count}");
        await context.Output.WriteLineAsync($"- Abilities: {inventoryResult.Abilities.Count}");
        await context.Output.WriteLineAsync($"- Status effects: {inventoryResult.StatusEffects.Count}");
        await context.Output.WriteLineAsync($"- Characters: {characters.Count}");
        await context.Output.WriteLineAsync($"- Mechanics notes: {mechanics.Count}");
        await context.Output.WriteLineAsync($"- Story locations: {walkthroughResult.StoryLocations.Count}");
        await context.Output.WriteLineAsync($"- Story entity links: {walkthroughResult.StoryAppearances.Count}");
        await context.Output.WriteLineAsync($"Output directory: {context.OutputDirectory}");
        return 0;
    }

    private static IReadOnlyList<Ffl1WalkthroughParser.StoryEntityCandidate> BuildEntityCandidates(
        IReadOnlyList<Ffl1CharacterRecord> characters,
        IReadOnlyList<Ffl1MonsterRecord> monsters,
        IReadOnlyList<Ffl1EquipmentRecord> equipment,
        IReadOnlyList<Ffl1ItemRecord> items,
        IReadOnlyList<Ffl1ItemRecord> spells,
        IReadOnlyList<Ffl1AbilityRecord> abilities,
        IReadOnlyList<Ffl1StatusEffectRecord> statusEffects)
    {
        var candidates = new List<Ffl1WalkthroughParser.StoryEntityCandidate>();

        candidates.AddRange(characters.Select(character => new Ffl1WalkthroughParser.StoryEntityCandidate("Character", character.CharacterName)));
        candidates.AddRange(monsters.Select(monster => new Ffl1WalkthroughParser.StoryEntityCandidate("Monster", monster.MonsterName)));
        candidates.AddRange(equipment.Select(row => new Ffl1WalkthroughParser.StoryEntityCandidate("Equipment", row.Name)));
        candidates.AddRange(items.Select(row => new Ffl1WalkthroughParser.StoryEntityCandidate("Item", row.Name)));
        candidates.AddRange(spells.Select(row => new Ffl1WalkthroughParser.StoryEntityCandidate("Spell", row.Name)));
        candidates.AddRange(abilities.Select(row => new Ffl1WalkthroughParser.StoryEntityCandidate("Ability", row.Name)));
        candidates.AddRange(statusEffects.Select(row => new Ffl1WalkthroughParser.StoryEntityCandidate("StatusEffect", row.StatusEffect)));

        return candidates
            .GroupBy(candidate => $"{candidate.EntityType}|{candidate.EntityName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();
    }
}