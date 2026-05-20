using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Games.Ffl3;

internal sealed record Ffl3FormulaRecord(
    string Category,
    string FormulaName,
    string Expression,
    string Notes,
    string SourceGuide);

internal sealed record Ffl3RobotCapsuleRecord(
    string Capsule,
    int Cost,
    string Effect,
    string Bought,
    string SourceGuide);

internal sealed record Ffl3TalonUnitRecord(
    string Category,
    string Name,
    string Effect,
    string Found,
    string SourceGuide);

internal sealed record Ffl3EquipmentRecord(
    string Category,
    string Subcategory,
    string Name,
    string Cost,
    string Details,
    string SourceGuide);

internal sealed record Ffl3ItemRecord(
    string Category,
    string Name,
    string Availability,
    string Notes,
    string SourceGuide);

internal sealed record Ffl3SpellRecord(
    string Category,
    string Name,
    string Cost,
    string Mp,
    string Details,
    string SourceGuide);

internal sealed record Ffl3AbilityRecord(
    string Category,
    string Name,
    string Details,
    string SourceGuide);

internal sealed record Ffl3StatusEffectRecord(
    string StatusEffect,
    string Description,
    string Notes,
    string SourceGuides);

internal sealed record Ffl3CharacterRecord(
    string CharacterName,
    string CharacterType,
    string StartingClass,
    string InnateElement,
    string Description,
    string SourceGuides);

internal sealed record Ffl3MonsterRecord(
    string SpeciesName,
    string Category,
    string LevelRange,
    string Element,
    string Notes,
    string SourceGuide);

internal sealed record Ffl3StoryLocationRecord(
    int Order,
    string SectionId,
    string LocationName,
    string LocationContext,
    string World,
    string Floor,
    string Summary,
    string MentionedCharacters,
    string MentionedMonsters,
    string MentionedItems,
    string MentionedEquipment,
    string MentionedSpells,
    string MentionedAbilities,
    string MentionedStatusEffects,
    string SourceGuide);

internal sealed record Ffl3EntityStoryAppearanceRecord(
    int Order,
    string SectionId,
    string LocationName,
    string EntityType,
    string EntityName,
    string MentionType,
    string SourceGuide);

internal sealed record Ffl3GuideData(
    IReadOnlyList<Ffl3EquipmentRecord> Equipment,
    IReadOnlyList<Ffl3SpellRecord> Spells,
    IReadOnlyList<Ffl3AbilityRecord> Abilities,
    IReadOnlyList<Ffl3StatusEffectRecord> StatusEffects,
    IReadOnlyList<Ffl3CharacterRecord> Characters,
    IReadOnlyList<Ffl3MonsterRecord> Monsters);

internal sealed record Ffl3WalkthroughCollectibleRecord(
    string EntityType,
    string Name,
    string Availability,
    string Notes,
    string SourceGuide);

internal sealed record Ffl3WalkthroughParseResult(
    IReadOnlyList<Ffl3ItemRecord> Items,
    IReadOnlyList<Ffl3WalkthroughCollectibleRecord> Collectibles,
    IReadOnlyList<Ffl3StoryLocationRecord> StoryLocations,
    IReadOnlyList<Ffl3EntityStoryAppearanceRecord> StoryAppearances);

internal sealed record Ffl3SystemData(
    IReadOnlyList<GuideMechanicRecord> Mechanics,
    IReadOnlyList<Ffl3FormulaRecord> Formulas,
    IReadOnlyList<Ffl3RobotCapsuleRecord> RobotCapsules,
    IReadOnlyList<Ffl3TalonUnitRecord> TalonUnits);