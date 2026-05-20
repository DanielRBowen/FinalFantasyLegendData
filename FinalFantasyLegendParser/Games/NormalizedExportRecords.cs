namespace FinalFantasyLegendParser.Games;

internal sealed record NormalizedMonsterRecord(
    string MonsterName,
    string Classification,
    string LevelRange,
    string Tier,
    string HP,
    string Strength,
    string Agility,
    string Mana,
    string Defense,
    string Gold,
    string Resistances,
    string Weaknesses,
    string Abilities,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedEquipmentRecord(
    string Category,
    string Name,
    string Uses,
    string Cost,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedItemRecord(
    string Category,
    string Name,
    string Uses,
    string Cost,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedSpellRecord(
    string Category,
    string Name,
    string Uses,
    string Cost,
    string MpCost,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedAbilityRecord(
    string Name,
    string AbilityType,
    string Uses,
    string Cost,
    string IndexHex,
    string Availability,
    string Targeting,
    string PrimaryEffect,
    string SecondaryEffect,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedStatusEffectRecord(
    string StatusEffect,
    string AppliedBy,
    string CuredBy,
    string RelatedElements,
    string Notes,
    string SourceGuide);

internal sealed record NormalizedCharacterRecord(
    string CharacterName,
    string CharacterType,
    string StartingClass,
    string InnateElement,
    string Description,
    string SourceGuide);