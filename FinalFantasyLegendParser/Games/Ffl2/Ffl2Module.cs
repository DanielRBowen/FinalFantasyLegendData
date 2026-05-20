using System.Text;
using FinalFantasyLegendParser.Core;
using FinalFantasyLegendParser.Games;
using FinalFantasyLegendParser.Games.Ffl2.Parsers;

namespace FinalFantasyLegendParser.Games.Ffl2;

internal sealed class Ffl2Module : IGameModule
{
    public string Key => "ffl2";

    public async Task<int> RunAsync(GameModuleContext context)
    {
        Directory.CreateDirectory(context.OutputDirectory);

        var systemParser = new Ffl2SystemParser();
        var systemData = systemParser.Parse();

        var monsterParser = new Ffl2MonsterEvolutionFaqParser();
        var monsterResult = monsterParser.Parse(context.RepositoryRoot);

        var shopParser = new Ffl2ShopParser();
        var shopResult = shopParser.Parse(context.RepositoryRoot);

        var characterParser = new Ffl2CharacterParser();
        var characters = characterParser.Parse();

        var statusEffectParser = new Ffl2StatusEffectParser();
        var statusEffects = statusEffectParser.Parse(context.RepositoryRoot);

        var abilities = BuildAbilities(systemData, monsterResult.AbilityNames);
        var entityCandidates = BuildEntityCandidates(characters, monsterResult.Monsters, shopResult.Equipment, shopResult.Items, shopResult.Spells, abilities, statusEffects);

        var walkthroughParser = new Ffl2WalkthroughParser();
        var walkthroughResult = walkthroughParser.Parse(context.RepositoryRoot, entityCandidates);
        var magiReferenceParser = new Ffl2MagiReferenceParser();
        var magiReferences = magiReferenceParser.Parse(context.RepositoryRoot);
        var equipment = MergeEquipment(shopResult.Equipment, walkthroughResult.Collectibles);
        var items = MergeSupplementalItems(MergeItems(shopResult.Items, walkthroughResult.Collectibles), magiReferences);
        var spells = MergeSpells(shopResult.Spells, walkthroughResult.Collectibles);

        var markdownCompiler = new Ffl2MarkdownCompiler();
        var markdown = markdownCompiler.Compile(
            systemData,
            characters,
            walkthroughResult.StoryLocations,
            monsterResult.Monsters,
            equipment,
            items,
            spells,
            abilities,
            statusEffects);

        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Mechanics.csv"), systemData.Mechanics);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Class_Progression.csv"), systemData.ClassProgressions);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Mutant_Skill_Tiers.csv"), systemData.MutantSkillTiers);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Monsters.csv"), monsterResult.Monsters.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Equipment.csv"), equipment.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Items.csv"), items.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Spells.csv"), spells.Select(row => row.ToNormalizedSpell()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Abilities.csv"), abilities.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_StatusEffects.csv"), statusEffects.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Characters.csv"), characters.Select(row => row.ToNormalized()).ToList());
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Story_Chronology.csv"), walkthroughResult.StoryLocations);
        CsvFileWriter.WriteRecords(Path.Combine(context.OutputDirectory, "FFL2_Entity_Story_Appearances.csv"), walkthroughResult.StoryAppearances);
        var outputMarkdownPath = Path.Combine(context.OutputDirectory, "FFL2_Complete_LLM_Guide.markdown");
        var repositoryMarkdownPath = Path.Combine(context.RepositoryRoot, "FFL2", "FFL2_Complete_LLM_Guide.markdown");
        var utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
        await File.WriteAllTextAsync(outputMarkdownPath, markdown, utf8Encoding, context.CancellationToken);
        await File.WriteAllTextAsync(repositoryMarkdownPath, markdown, utf8Encoding, context.CancellationToken);

        await context.Output.WriteLineAsync("Generated FFL2 structured reference files:");
        await context.Output.WriteLineAsync($"- Mechanics notes: {systemData.Mechanics.Count}");
        await context.Output.WriteLineAsync($"- Class progression rows: {systemData.ClassProgressions.Count}");
        await context.Output.WriteLineAsync($"- Mutant skill tiers: {systemData.MutantSkillTiers.Count}");
        await context.Output.WriteLineAsync($"- Monsters: {monsterResult.Monsters.Count}");
        await context.Output.WriteLineAsync($"- Equipment: {equipment.Count}");
        await context.Output.WriteLineAsync($"- Items: {items.Count}");
        await context.Output.WriteLineAsync($"- Spells: {spells.Count}");
        await context.Output.WriteLineAsync($"- Abilities: {abilities.Count}");
        await context.Output.WriteLineAsync($"- Status effects: {statusEffects.Count}");
        await context.Output.WriteLineAsync($"- Characters: {characters.Count}");
        await context.Output.WriteLineAsync($"- Story locations: {walkthroughResult.StoryLocations.Count}");
        await context.Output.WriteLineAsync($"- Story entity links: {walkthroughResult.StoryAppearances.Count}");
        await context.Output.WriteLineAsync($"Output directory: {context.OutputDirectory}");
        return 0;
    }

    private static IReadOnlyList<Ffl2AbilityRecord> BuildAbilities(Ffl2SystemData systemData, IReadOnlyCollection<string> monsterAbilityNames)
    {
        var records = new List<Ffl2AbilityRecord>();

        foreach (var tier in systemData.MutantSkillTiers)
        {
            foreach (var abilityName in tier.Abilities.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                records.Add(new Ffl2AbilityRecord(
                    abilityName,
                    "Mutant Skill",
                    tier.DsTier,
                    tier.Notes,
                    tier.SourceGuide));
            }
        }

        records.AddRange(monsterAbilityNames.Select(name => new Ffl2AbilityRecord(
            name,
            "Monster Ability/Trait",
            "Monster stats guide",
            string.Empty,
            "16852_Monster_Evolution_FAQ.txt")));

        return records
            .GroupBy(record => $"{record.AbilityType}|{record.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2AbilityRecord(
                group.First().Name,
                group.First().AbilityType,
                string.Join("; ", group.Select(record => record.Availability).Where(value => !string.IsNullOrWhiteSpace(value)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", group.Select(record => record.Notes).Where(value => !string.IsNullOrWhiteSpace(value)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(value => value, StringComparer.OrdinalIgnoreCase)),
                string.Join("; ", group.Select(record => record.SourceGuides).Where(value => !string.IsNullOrWhiteSpace(value)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(value => value, StringComparer.OrdinalIgnoreCase))))
            .OrderBy(record => record.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl2WalkthroughParser.StoryEntityCandidate> BuildEntityCandidates(
        IReadOnlyList<Ffl2CharacterRecord> characters,
        IReadOnlyList<Ffl2MonsterRecord> monsters,
        IReadOnlyList<Ffl2EquipmentRecord> equipment,
        IReadOnlyList<Ffl2ItemRecord> items,
        IReadOnlyList<Ffl2ItemRecord> spells,
        IReadOnlyList<Ffl2AbilityRecord> abilities,
        IReadOnlyList<Ffl2StatusEffectRecord> statusEffects)
    {
        var candidates = new List<Ffl2WalkthroughParser.StoryEntityCandidate>();

        candidates.AddRange(characters.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Character", row.CharacterName)));
        candidates.AddRange(monsters.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Monster", row.MonsterName)));
        candidates.AddRange(equipment.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Equipment", row.Name)));
        candidates.AddRange(items.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Item", row.Name)));
        candidates.AddRange(spells.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Spell", row.Name)));
        candidates.AddRange(abilities.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("Ability", row.Name)));
        candidates.AddRange(statusEffects.Select(row => new Ffl2WalkthroughParser.StoryEntityCandidate("StatusEffect", row.StatusEffect)));

        return candidates
            .GroupBy(candidate => $"{candidate.EntityType}|{candidate.EntityName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();
    }

    private static IReadOnlyList<Ffl2EquipmentRecord> MergeEquipment(
        IReadOnlyList<Ffl2EquipmentRecord> baseRows,
        IReadOnlyList<Ffl2WalkthroughCollectibleRecord> collectibles)
    {
        var collectedRows = collectibles
            .Where(row => row.EntityType.Equals("Equipment", StringComparison.OrdinalIgnoreCase))
            .Select(row =>
            {
                var existing = baseRows.FirstOrDefault(candidate => candidate.Name.Equals(row.Name, StringComparison.OrdinalIgnoreCase));
                return new Ffl2EquipmentRecord(
                    existing?.Category ?? DetermineEquipmentCategory(row.Name),
                    existing?.Name ?? row.Name,
                    existing?.Uses ?? string.Empty,
                    existing?.Cost ?? string.Empty,
                    row.Availability,
                    row.Notes,
                    row.SourceGuide);
            });

        return baseRows
            .Concat(collectedRows)
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

    private static IReadOnlyList<Ffl2ItemRecord> MergeItems(
        IReadOnlyList<Ffl2ItemRecord> baseRows,
        IReadOnlyList<Ffl2WalkthroughCollectibleRecord> collectibles)
    {
        var collectedRows = collectibles
            .Where(row => row.EntityType.Equals("Item", StringComparison.OrdinalIgnoreCase))
            .Select(row =>
            {
                var existing = baseRows.FirstOrDefault(candidate => candidate.Name.Equals(row.Name, StringComparison.OrdinalIgnoreCase));
                return new Ffl2ItemRecord(
                    existing?.Category ?? DetermineItemCategory(row.Name),
                    existing?.Name ?? row.Name,
                    existing?.Uses ?? string.Empty,
                    existing?.Cost ?? string.Empty,
                    row.Availability,
                    existing?.PrimaryEffect ?? string.Empty,
                    row.Notes,
                    row.SourceGuide);
            });

        return baseRows
            .Concat(collectedRows)
            .GroupBy(row => $"{row.Category}|{row.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2ItemRecord(
                group.First().Category,
                group.First().Name,
                JoinDistinct(group.Select(row => row.Uses)),
                JoinDistinct(group.Select(row => row.Cost)),
                JoinDistinct(group.Select(row => row.Availability)),
                JoinDistinct(group.Select(row => row.PrimaryEffect)),
                JoinDistinct(group.Select(row => row.Notes)),
                JoinDistinct(group.Select(row => row.SourceGuides))))
            .OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl2ItemRecord> MergeSupplementalItems(
        IReadOnlyList<Ffl2ItemRecord> baseRows,
        IReadOnlyList<Ffl2ItemRecord> supplementalRows)
    {
        return baseRows
            .Concat(supplementalRows)
            .GroupBy(row => $"{row.Category}|{row.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2ItemRecord(
                group.First().Category,
                group.First().Name,
                JoinDistinct(group.Select(row => row.Uses)),
                JoinDistinct(group.Select(row => row.Cost)),
                JoinDistinct(group.Select(row => row.Availability)),
                JoinDistinct(group.Select(row => row.PrimaryEffect)),
                JoinDistinct(group.Select(row => row.Notes)),
                JoinDistinct(group.Select(row => row.SourceGuides))))
            .OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static IReadOnlyList<Ffl2ItemRecord> MergeSpells(
        IReadOnlyList<Ffl2ItemRecord> baseRows,
        IReadOnlyList<Ffl2WalkthroughCollectibleRecord> collectibles)
    {
        var collectedRows = collectibles
            .Where(row => row.EntityType.Equals("Spell", StringComparison.OrdinalIgnoreCase))
            .Select(row =>
            {
                var existing = baseRows.FirstOrDefault(candidate => candidate.Name.Equals(row.Name, StringComparison.OrdinalIgnoreCase));
                return new Ffl2ItemRecord(
                    existing?.Category ?? "Spell/Book",
                    existing?.Name ?? row.Name,
                    existing?.Uses ?? string.Empty,
                    existing?.Cost ?? string.Empty,
                    row.Availability,
                    existing?.PrimaryEffect ?? string.Empty,
                    row.Notes,
                    row.SourceGuide);
            });

        return baseRows
            .Concat(collectedRows)
            .GroupBy(row => $"{row.Category}|{row.Name}", StringComparer.OrdinalIgnoreCase)
            .Select(group => new Ffl2ItemRecord(
                group.First().Category,
                group.First().Name,
                JoinDistinct(group.Select(row => row.Uses)),
                JoinDistinct(group.Select(row => row.Cost)),
                JoinDistinct(group.Select(row => row.Availability)),
                JoinDistinct(group.Select(row => row.PrimaryEffect)),
                JoinDistinct(group.Select(row => row.Notes)),
                JoinDistinct(group.Select(row => row.SourceGuides))))
            .OrderBy(row => row.Category, StringComparer.OrdinalIgnoreCase)
            .ThenBy(row => row.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static string DetermineEquipmentCategory(string name)
    {
        return name.EndsWith("Armor", StringComparison.OrdinalIgnoreCase) ? "Armor"
            : name.EndsWith("Helmet", StringComparison.OrdinalIgnoreCase) ? "Helmet"
            : name.EndsWith("Shield", StringComparison.OrdinalIgnoreCase) ? "Shield"
            : name.EndsWith("Gauntlet", StringComparison.OrdinalIgnoreCase) ? "Gauntlet"
            : "Weapon";
    }

    private static string DetermineItemCategory(string name)
    {
        return name.EndsWith("Magi", StringComparison.OrdinalIgnoreCase)
               || name.Equals("Micron Potion", StringComparison.OrdinalIgnoreCase)
            ? "Key Item"
            : "Item";
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
}
