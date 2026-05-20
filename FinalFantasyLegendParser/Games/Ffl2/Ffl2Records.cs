using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Games.Ffl2;

internal sealed record Ffl2ClassProgressionRecord(
    string ClassName,
    string GrowthModel,
    string EnhancementMethods,
    string Constraints,
    string SourceGuides);

internal sealed record Ffl2MutantSkillTierRecord(
    string DsTier,
    string Abilities,
    string Notes,
    string SourceGuide);

internal sealed record Ffl2MonsterRecord(
    string MonsterName,
    int Tier,
    int HP,
    int Strength,
    int Agility,
    int Mana,
    int Defense,
    string Abilities,
    string SourceGuide);

internal sealed record Ffl2EquipmentRecord(
    string Category,
    string Name,
    string Uses,
    string Cost,
    string Availability,
    string Notes,
    string SourceGuides);

internal sealed record Ffl2ItemRecord(
    string Category,
    string Name,
    string Uses,
    string Cost,
    string Availability,
    string PrimaryEffect,
    string Notes,
    string SourceGuides);

internal sealed record Ffl2AbilityRecord(
    string Name,
    string AbilityType,
    string Availability,
    string Notes,
    string SourceGuides);

internal sealed record Ffl2StatusEffectRecord(
    string StatusEffect,
    string AppliedBy,
    string CuredBy,
    string Notes,
    string SourceGuides);

internal sealed record Ffl2CharacterRecord(
    string CharacterName,
    string CharacterType,
    string Description,
    string SourceGuides);

internal sealed record Ffl2StoryLocationRecord(
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

internal sealed record Ffl2EntityStoryAppearanceRecord(
    int Order,
    string SectionId,
    string LocationName,
    string EntityType,
    string EntityName,
    string MentionType,
    string SourceGuide);

internal sealed record Ffl2MonsterParseResult(
    IReadOnlyList<Ffl2MonsterRecord> Monsters,
    IReadOnlyList<string> AbilityNames);

internal sealed record Ffl2ShopParseResult(
    IReadOnlyList<Ffl2EquipmentRecord> Equipment,
    IReadOnlyList<Ffl2ItemRecord> Items,
    IReadOnlyList<Ffl2ItemRecord> Spells);

internal sealed record Ffl2WalkthroughParseResult(
    IReadOnlyList<Ffl2StoryLocationRecord> StoryLocations,
    IReadOnlyList<Ffl2EntityStoryAppearanceRecord> StoryAppearances);

internal sealed record Ffl2SystemData(
    IReadOnlyList<GuideMechanicRecord> Mechanics,
    IReadOnlyList<Ffl2ClassProgressionRecord> ClassProgressions,
    IReadOnlyList<Ffl2MutantSkillTierRecord> MutantSkillTiers);