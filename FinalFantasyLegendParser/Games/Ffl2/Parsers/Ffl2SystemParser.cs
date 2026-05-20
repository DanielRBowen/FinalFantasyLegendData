using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed class Ffl2SystemParser
{
    public Ffl2SystemData Parse()
    {
        var mechanics = new List<GuideMechanicRecord>
        {
            Create(
                1,
                1,
                "Combat and Damage Rules",
                "Core stats",
                "HP and max HP define survivability, Strength powers heavy weapons, Agility drives hit rate, evasion, turn order, and light-weapon damage, Defense cuts physical damage, and Mana improves spell damage and healing.",
                "29741_Robot_Guide.txt"),
            Create(
                1,
                2,
                "Combat and Damage Rules",
                "Ranged weapons",
                "Guns, bows, and explosives are described as having static attack values. Their damage does not scale with normal stats the way melee weapons do, but high enemy defense still lowers their output.",
                "29741_Robot_Guide.txt"),
            Create(
                1,
                3,
                "Combat and Damage Rules",
                "MAGI effects",
                "Stat MAGI provide hidden boosts such as Power MAGI raising Strength and Mana MAGI raising Mana. Elemental MAGI both boost matching magic and grant elemental protection, although the guide flags several buggy protection interactions.",
                "29741_Robot_Guide.txt"),
            Create(
                1,
                4,
                "Combat and Damage Rules",
                "Immunities and weaknesses",
                "O-series traits grant layered defenses such as O-Damage, O-Weapon, O-Change, and O-All. X-element traits mark weaknesses that increase incoming elemental damage and can enable instant-kill style weakness hits from matching elemental weapons.",
                "29741_Robot_Guide.txt"),
            Create(
                1,
                5,
                "Combat and Damage Rules",
                "Running and turn flow",
                "Escape odds depend on your Agility compared to the enemy. If you fail to run, the enemy gets a free round of actions.",
                "29741_Robot_Guide.txt"),
            Create(
                1,
                6,
                "Combat and Damage Rules",
                "Formula coverage",
                "The selected FFL2 guides document many combat rules and scaling behaviors, but they do not provide the same explicit closed-form damage equations that were found for FFL3. This module therefore records guide-derived mechanics rather than exact formulas.",
                "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            Create(
                2,
                1,
                "Character Progression",
                "Humans",
                "Humans grow by fighting battles. Strength, Defense, Agility, Mana, and HP all improve through combat, with stronger enemies accelerating growth. Humans can carry eight items and rely entirely on equipment and items because they have no native skills.",
                "12292_Guide_and_Walkthrough.txt"),
            Create(
                2,
                2,
                "Character Progression",
                "Mutants",
                "Mutants use the same battle-growth model as humans but at a slightly slower rate. In exchange they have higher Mana and can learn special skills if space remains in their ability list. Using more skills is explicitly recommended for building Mana.",
                "12292_Guide_and_Walkthrough.txt"),
            Create(
                2,
                3,
                "Character Progression",
                "Robots",
                "Robots do not grow from battle at all. Their HP and combat stats come from equipped weapons and armor, and every equip or unequip action halves the remaining uses on most robot-bound weapons. Inns restore depleted robot weapons to 50 percent of maximum uses.",
                "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            Create(
                2,
                4,
                "Character Progression",
                "Monsters",
                "Monsters grow through meat. Eating strong meat, especially boss meat, improves them, while weak meat can regress them. The evolution FAQ further explains that family changes are based on current family, meat modifier, class modifier, and DS level.",
                "12292_Guide_and_Walkthrough.txt; 16852_Monster_Evolution_FAQ.txt"),
            Create(
                2,
                5,
                "Character Progression",
                "Mutant skill tiers",
                "Mutant skills are tied to the defeated enemy's DS level. Late-world enemies and bosses unlock the top-tier skill pool, which is why advanced skills such as Teleport, Flare, and O-All cluster around the high-DS end of the game.",
                "16852_Monster_Evolution_FAQ.txt"),
            Create(
                3,
                1,
                "Enhancement and Class Differences",
                "Battle actions and stat focus",
                "Repeated heavy-weapon use raises Strength odds, light weapons raise Agility odds, shields help Defense growth, and books, staffs, psi blades, and mutant abilities improve Mana growth odds.",
                "29741_Robot_Guide.txt"),
            Create(
                3,
                2,
                "Enhancement and Class Differences",
                "Robot loadouts",
                "Robots can layer armor because the normal body-slot restrictions do not apply to them. The robot guide also notes that same-tier armor pieces grant the same robot protection values, making gloves the cheapest way to buy that defense tier.",
                "29741_Robot_Guide.txt"),
            Create(
                3,
                3,
                "Enhancement and Class Differences",
                "Martial arts",
                "Martial arts get stronger as they are used and do not have their uses halved when equipped on or removed from robots. They are also a cheap way to pad robot Agility even if robots should not rely on them for raw damage.",
                "29741_Robot_Guide.txt"),
            Create(
                3,
                4,
                "Enhancement and Class Differences",
                "Robot ceilings and risks",
                "Robots can push focused stats past the displayed 99 and approach 200 in practice, but the guide warns that extremely high Agility can create odd turn-order behavior. Robots are also especially vulnerable to magic and recover less HP from magical healing.",
                "29741_Robot_Guide.txt"),
            Create(
                4,
                1,
                "Extra System Notes",
                "Battle rewards",
                "Only one item drop or meat drop can be earned per fight, but each human or mutant can still gain one stat increase or one new ability from that same battle.",
                "29741_Robot_Guide.txt"),
            Create(
                4,
                2,
                "Extra System Notes",
                "Recommended robot economics",
                "The robot guide frames robots as a money sink early and a stat-efficient powerhouse later. If treasure is funneled to robots and HP-recovery tricks are used, they stop consuming money on recovery and instead convert cash directly into stronger permanent equipment states.",
                "29741_Robot_Guide.txt")
        };

        var classProgressions = new List<Ffl2ClassProgressionRecord>
        {
            new(
                "Human",
                "Battle-driven stat growth across Strength, Defense, Agility, Mana, and HP.",
                "Use weapons, armor, and books in battle; carry up to eight items.",
                "No native skills.",
                "12292_Guide_and_Walkthrough.txt"),
            new(
                "Mutant",
                "Battle-driven growth similar to humans, but slightly slower.",
                "Use learned skills and spell items to build Mana; leave room in the ability list to keep learning.",
                "Maximum of four acquired special skills inside the eight-item inventory.",
                "12292_Guide_and_Walkthrough.txt"),
            new(
                "Robot",
                "No battle growth; stats come from equipment and recharge behavior.",
                "Equip the strongest weapons and armor possible, and treat item choice as permanent stat tuning.",
                "Equipping and unequipping halves weapon uses; robots cannot use magic.",
                "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new(
                "Monster",
                "Transforms into new species by eating meat rather than leveling conventionally.",
                "Target strong and boss meat to climb families and DS tiers.",
                "Weak meat can reduce power; monsters depend on form quality more than inventory.",
                "12292_Guide_and_Walkthrough.txt; 16852_Monster_Evolution_FAQ.txt")
        };

        var mutantSkillTiers = new List<Ffl2MutantSkillTierRecord>
        {
            new("DS 1+", "Cure, Warning, Fire, O-Poison, Ice", "Base-world tier skills.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 2+", "O-Para, Thunder, O-Quake", "Early-world defensive and elemental expansion.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 3+", "Blitz, X-Fire, Steal", "Opens stronger utility and elemental coverage.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 4+", "X-Ice, StonSkin, X-Thunder, Gaze", "Midgame resist and status package.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 5+", "Surprise, StonGaze, O-Stone", "Higher-DS control and protection skills.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 6+", "Explode, Heal", "Adds strong burst and support options.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 7+", "Charm, O-Weapon, Hypnos", "Late-midgame control and physical resistance.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 8+", "Teleport, Touch, O-Damage", "High-tier mobility and broad damage resistance.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS 9+", "P-Blast, O-Change, Mirror", "Strong late-game utility and all-element resistance.", "16852_Monster_Evolution_FAQ.txt"),
            new("DS A+", "Recover, Flare, O-All", "Top-tier endgame mutant skills.", "16852_Monster_Evolution_FAQ.txt")
        };

        return new Ffl2SystemData(mechanics, classProgressions, mutantSkillTiers);
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