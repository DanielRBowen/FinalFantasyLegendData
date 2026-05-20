namespace FinalFantasyLegendParser.Games.Ffl1;

internal sealed record Ffl1MonsterRecord(
    string MonsterName,
    string IndexHex,
    int HP,
    int Strength,
    int Agility,
    int Mana,
    int Defense,
    int Gold,
    string Resistances,
    string Weaknesses,
    string MonsterFamily,
    string SourceGuide);

internal sealed record Ffl1EquipmentRecord(
    string Category,
    string Name,
    string Uses,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record Ffl1ItemRecord(
    string Category,
    string Name,
    string Uses,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record Ffl1AbilityRecord(
    string Name,
    string Uses,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record Ffl1StatusEffectRecord(
    string StatusEffect,
    string AppliedBy,
    string CuredBy,
    string RelatedElements,
    string Notes,
    string SourceGuide);

internal sealed record Ffl1CharacterRecord(
    string CharacterName,
    string CharacterType,
    string Description,
    string SourceGuides);

internal sealed record Ffl1StoryLocationRecord(
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

internal sealed record Ffl1EntityStoryAppearanceRecord(
    int Order,
    string SectionId,
    string LocationName,
    string EntityType,
    string EntityName,
    string MentionType,
    string SourceGuide);

internal sealed record Ffl1InventoryParseResult(
    IReadOnlyList<Ffl1MonsterRecord> Monsters,
    IReadOnlyList<Ffl1EquipmentRecord> Equipment,
    IReadOnlyList<Ffl1ItemRecord> Items,
    IReadOnlyList<Ffl1AbilityRecord> Abilities,
    IReadOnlyList<Ffl1StatusEffectRecord> StatusEffects);

internal sealed record Ffl1WalkthroughParseResult(
    IReadOnlyList<Ffl1StoryLocationRecord> StoryLocations,
    IReadOnlyList<Ffl1EntityStoryAppearanceRecord> StoryAppearances);

