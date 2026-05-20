using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Games.Ffl1.Parsers;

internal sealed class Ffl1MechanicsParser
{
    public IReadOnlyList<GuideMechanicRecord> Parse()
    {
        return
        [
            Create(
                1,
                1,
                "Battle Calculations and Combat Rules",
                "Core stats",
                "Strength drives most physical damage, Agility controls dodge, turn order, and light-weapon accuracy, Defense reduces incoming physical damage, and Mana improves mutant abilities and spellbook power.",
                "5829_Guide_and_Walkthrough.txt"),
            Create(
                1,
                2,
                "Battle Calculations and Combat Rules",
                "Weapon proficiency",
                "Weapons take a few uses before a character becomes proficient. Humans and males are described as better fits for strength-based weapons, while mutants and females do better with agility-based weapons.",
                "5829_Guide_and_Walkthrough.txt"),
            Create(
                1,
                3,
                "Battle Calculations and Combat Rules",
                "Working damage theory",
                "The monster inventory FAQ proposes a working formula of roughly Damage = (Attack x 10) + user stat - target defense + a small random factor. The same theory is suggested for strength-, agility-, and mana-based attacks, but bows and guns remain partially unresolved.",
                "21924_Monster_Inventory_FAQ.txt"),
            Create(
                1,
                4,
                "Battle Calculations and Combat Rules",
                "Ranged and special weapons",
                "The FAQ maps guns to base attack bytes such as Colt = 40 and Musket = 130, but notes that support-byte behavior is still unclear. Xcalibur, Glass Sword, and Masamune also appear to use special command bytes instead of the normal weapon logic.",
                "21924_Monster_Inventory_FAQ.txt"),
            Create(
                2,
                1,
                "Character Progression",
                "Humans",
                "Humans do not grow through battles. They improve by buying potions: Strong and Agility raise their stats, while HP200 through HP800 raise permanent HP until the listed threshold is exceeded, after which the same potion only gives +1 HP.",
                "5829_Guide_and_Walkthrough.txt; 8347_Human_FAQ.txt"),
            Create(
                2,
                2,
                "Character Progression",
                "Human stat scaling",
                "The Human FAQ states that Strength and Agility potions raise their stats by 2 each use. Displayed values cap at 99, but the guide notes that Strength and Agility can continue up to 255 and wrap back to 1 if pushed past that point.",
                "8347_Human_FAQ.txt"),
            Create(
                2,
                3,
                "Character Progression",
                "Mutants",
                "Mutants grow through battle actions instead of shops. Heavy weapons tend to raise Strength, light weapons and firearms tend to raise Agility, spellbooks and mutant abilities tend to raise Mana, and simply surviving battles may raise HP.",
                "5829_Guide_and_Walkthrough.txt; 8348_Mutant_FAQ.txt"),
            Create(
                2,
                4,
                "Character Progression",
                "Mutant ability churn",
                "Mutants reserve four slots for natural abilities. One slot may change after battle, so strong abilities are safer when kept near the top of the ability list and the lowest slot is treated as expendable.",
                "5829_Guide_and_Walkthrough.txt; 8348_Mutant_FAQ.txt"),
            Create(
                2,
                5,
                "Character Progression",
                "Monsters",
                "Monsters progress by eating meat. Strong meat, especially boss meat, can jump them forward into stronger forms, while weak meat can regress them into weaker species.",
                "5829_Guide_and_Walkthrough.txt"),
            Create(
                3,
                1,
                "Stat and Ability Enhancement",
                "Human potion values",
                "Strong Potion costs 300 GP for +2 Strength, Agility Potion costs 300 GP for +2 Agility, HP200 costs 100 GP, HP400 costs 1000 GP, and HP600 costs 10000 GP. The Human FAQ recommends repeatedly buying HP200 once HP thresholds are passed because it remains the most efficient option.",
                "8347_Human_FAQ.txt"),
            Create(
                3,
                2,
                "Stat and Ability Enhancement",
                "Mutant specialization",
                "The Mutant FAQ recommends building Agility early so psi weapons can land reliably, then leaning into Mana-heavy growth with magic and psi weapons later. Defense gains are described as rare and especially valuable when they happen.",
                "8348_Mutant_FAQ.txt"),
            Create(
                3,
                3,
                "Stat and Ability Enhancement",
                "Endgame weapon focus",
                "The Human FAQ recommends projectile weapons as a fallback against high-defense enemies, then shifting into top-end strength weapons like Glass Sword and Excalibur once Strength is well developed.",
                "8347_Human_FAQ.txt"),
            Create(
                4,
                1,
                "Game-Specific System Notes",
                "Consumable equipment economy",
                "Most weapons and items have finite uses, while mutant natural abilities recharge at inns instead of disappearing permanently. This makes long-term resource planning part of party construction.",
                "5829_Guide_and_Walkthrough.txt"),
            Create(
                4,
                2,
                "Game-Specific System Notes",
                "Hearts and death",
                "Characters track a heart stock separate from HP. A dead party member can be revived while hearts remain, but once hearts are exhausted that character is effectively gone and must be replaced.",
                "5829_Guide_and_Walkthrough.txt"),
            Create(
                4,
                3,
                "Game-Specific System Notes",
                "Trash Can bug",
                "The walkthrough documents a late-game Trash Can exploit that can be used repeatedly for human stat growth, although the exact trigger behavior is described as inconsistent.",
                "5829_Guide_and_Walkthrough.txt")
        ];
    }

    private static GuideMechanicRecord Create(
        int sectionOrder,
        int entryOrder,
        string sectionTitle,
        string topic,
        string details,
        string sourceGuides)
    {
        return new GuideMechanicRecord(sectionOrder, entryOrder, sectionTitle, topic, details, sourceGuides);
    }
}