using FinalFantasyLegendParser.Games;

namespace FinalFantasyLegendParser.Games.Ffl3.Parsers;

internal sealed class Ffl3SystemParser
{
    public Ffl3SystemData Parse()
    {
        var mechanics = new List<GuideMechanicRecord>
        {
            Create(
                1,
                1,
                "Attack Properties and Damage Rules",
                "Elementals and resistances",
                "FFL3 uses Fire, Ice, Tornado, and Quake as its base elementals, with Thunder treated as the combined Ice and Tornado element. Strong resistance halves skill, while weakness doubles skill.",
                "47306_Game_Lists.txt"),
            Create(
                1,
                2,
                "Attack Properties and Damage Rules",
                "Damage property",
                "ODamage halves attacks that carry the Damage property, which affects most physical weapons and some talents. Late-game enemies use this heavily, so non-Damage properties become important.",
                "47306_Game_Lists.txt"),
            Create(
                1,
                3,
                "Attack Properties and Damage Rules",
                "Holy and Mystic",
                "Holy weapons deal double damage to undead, while Mystic weapons deal double damage to bosses and undead. These properties are part of why endgame sword choice matters more than raw power alone.",
                "47306_Game_Lists.txt"),
            Create(
                1,
                4,
                "Attack Properties and Damage Rules",
                "Formula families",
                "Melee, missile, martial arts, fixed-damage weapons, attack magic, item magic, talents, and Talon weapons each have separate damage formulas. The module exports the exact equations to a dedicated CSV for reference.",
                "47306_Game_Lists.txt"),
            Create(
                1,
                5,
                "Attack Properties and Damage Rules",
                "Group targeting",
                "For formulas that target a group, damage is divided by the number of enemies in that group. Single-target and all-target attacks keep full damage.",
                "47306_Game_Lists.txt"),
            Create(
                2,
                1,
                "Stats and Upgrades",
                "Stat meanings",
                "Attack drives most weapons and some talents, Agility affects melee damage and turn order, Magic powers spells and some talents, while Hit, Evade, M.Def., and M.Evade control accuracy and magical durability.",
                "47306_Game_Lists.txt"),
            Create(
                2,
                2,
                "Stats and Upgrades",
                "Cyborg equipment bonuses",
                "Cyborgs derive most of their growth from gear. Weapons and shields add max HP and Attack, helmets and armor add max HP and Defense, gloves and shoes add max MP and Agility, and accessory-type items add max MP and Magic.",
                "47306_Game_Lists.txt"),
            Create(
                2,
                3,
                "Stats and Upgrades",
                "Robot capsules",
                "Robot capsules permanently raise robot-only stats while in robot form. HP capsules add 24-40 max HP, Attack and Defense capsules add +3 to their stat, and Speed capsules add +3 Agility. Capsule gains cap at 999 HP and 99 for Attack, Defense, and Agility.",
                "47306_Game_Lists.txt"),
            Create(
                2,
                4,
                "Stats and Upgrades",
                "Talon units",
                "The Talon acts as both progression tool and battle platform. Engine, warp, weapon, and option units expand movement, world access, encounter control, and full-party recovery.",
                "47306_Game_Lists.txt"),
            Create(
                3,
                1,
                "Class and Progression Differences",
                "Monsters and beasts",
                "Monsters are functional without equipment and keep strong raw stats, while beasts get a mixed toolkit and 1.5x martial-arts skill. Both can use talents, which gives them flexible non-weapon offense.",
                "47306_Game_Lists.txt"),
            Create(
                3,
                2,
                "Class and Progression Differences",
                "Mutants and humans",
                "Mutants are the spell specialists with 2x attack-magic skill, while humans are the weapon specialists with 2x normal melee skill and 2x throwing skill. Humans lose some of that late-game edge once Mystic swords equalize skill across classes.",
                "47306_Game_Lists.txt"),
            Create(
                3,
                3,
                "Class and Progression Differences",
                "Cyborgs and robots",
                "Cyborgs become strong generalists when fed top equipment, while robots trade magic access for controllable, permanent capsule-driven stat growth and boosted robot-talent skill.",
                "47306_Game_Lists.txt"),
            Create(
                3,
                4,
                "Class and Progression Differences",
                "Display caps",
                "The guide explicitly notes that HP and primary stats can exceed their displayed 999 and 99 menu caps even though the UI stops showing larger values.",
                "47306_Game_Lists.txt"),
            Create(
                4,
                1,
                "Changing Class",
                "Transformation continuum",
                "Class changes follow Monster <=> Beast <=> Human/Mutant <=> Cyborg <=> Robot. Meat pushes the character left, parts push the character right, and the Flushex unit pulls classes back toward the center.",
                "47306_Game_Lists.txt"),
            Create(
                4,
                2,
                "Changing Class",
                "Species selection",
                "Intrinsic element determines which species chart entry is chosen after class changes. Earth, Water, Fire, and Air cross-map differently depending on the enemy part or meat consumed.",
                "47306_Game_Lists.txt"),
            Create(
                4,
                3,
                "Changing Class",
                "Stat retention",
                "Transformations preserve different shares of enemy base stats depending on the resulting class: monsters keep 100 percent, beasts keep full stats except half Defense, cyborgs retain mixed percentages and add equipment bonuses, and robots retain partial non-magic stats plus capsule bonuses.",
                "47306_Game_Lists.txt")
        };

        var formulas = new List<Ffl3FormulaRecord>
        {
            new("Weapons", "Melee weapons", "Damage = skill x (WP + Att. + Agi.) - Def.", "Humans use normal melee at skill 2. Mystic swords use skill 2 for every supported class. Mutants reach skill 2 with Psi knife, Psi sword, X-Fire staff, and Fast staff.", "47306_Game_Lists.txt"),
            new("Weapons", "Missile weapons", "Damage = skill x (WP + 2 x Att.) - Def.", "Humans throw at skill 2. Bows stay at skill 1 for supported classes.", "47306_Game_Lists.txt"),
            new("Weapons", "Martial arts", "Damage = 1/2 x skill x WP x Att. - Def.", "Beasts use martial arts at skill 1.5; most other supported classes use skill 1.", "47306_Game_Lists.txt"),
            new("Weapons", "Fixed-damage weapons", "Damage = skill x WP - Def.", "Group damage is divided by group size. Humans use cripplers at skill 8. Mutants add 2 x Magic when using the Psi gun and humans or mutants use the Poison gun at skill 8.", "47306_Game_Lists.txt"),
            new("Magic", "Attack magic", "Damage = skill x (SP + Mag.) - M.Def.", "Mutants cast attack magic at skill 3; monsters, beasts, humans, and cyborgs cast at skill 1.5; robots cannot cast it.", "47306_Game_Lists.txt"),
            new("Magic", "Item magic", "Damage = skill x (SP + Mag.) - M.Def.", "All classes that can use the item spell use item magic at skill 1.5.", "47306_Game_Lists.txt"),
            new("Talents", "Talents", "Damage = skill x (1/4 x TP x (Att. + maxHP/10) + base) - Def.", "Robot talents use skill 1.5 when used by robots. Counterattacking talents resolve at half power.", "47306_Game_Lists.txt"),
            new("Talon", "Cannon", "Damage = 200 - Def.", "Pre-installed Talon attack that hits all enemies.", "47306_Game_Lists.txt"),
            new("Talon", "Missile", "Damage = 400 - Def.", "Talon weapon unit found at Mount Hasbid.", "47306_Game_Lists.txt"),
            new("Talon", "Laser", "Damage = 600 - Def.", "Talon weapon unit found at Cirrus.", "47306_Game_Lists.txt"),
            new("Talon", "E-Ray", "Damage = 800 - Def.", "Talon weapon unit found at Underworld Cave.", "47306_Game_Lists.txt")
        };

        var robotCapsules = new List<Ffl3RobotCapsuleRecord>
        {
            new("Attack", 1500, "+3 Attack", "Dharm (Present); Elan (Past, Future); Cirrus, Donmac, Knaya (Pureland)", "47306_Game_Lists.txt"),
            new("Defense", 1500, "+3 Defense", "Elan (Present); Lae (Past); Viper City (Future); Knaya, Porle (Pureland)", "47306_Game_Lists.txt"),
            new("Speed", 1500, "+3 Agility", "Elan (Present); Lae (Past); Viper City (Future); Knaya, Porle (Pureland)", "47306_Game_Lists.txt"),
            new("HP", 1500, "+24-40 max HP", "Dharm (Present); Elan (Past, Future); Cirrus, Donmac, Knaya (Pureland)", "47306_Game_Lists.txt")
        };

        var talonUnits = new List<Ffl3TalonUnitRecord>
        {
            new("Engine", "Rover", "Travels over land", "South Cave (Past)", "47306_Game_Lists.txt"),
            new("Engine", "Hover", "Travels over land and water", "Castle of Chaos (Present); Talonsburg (Pureland)", "47306_Game_Lists.txt"),
            new("Engine", "Soar", "Travels over land, water, and mountains", "Eastern Ruins (Pureland)", "47306_Game_Lists.txt"),
            new("Warp", "Past", "Warps to and from the Past", "Elan (Present)", "47306_Game_Lists.txt"),
            new("Warp", "Future", "Warps to and from the Future", "Castle of Chaos (Present)", "47306_Game_Lists.txt"),
            new("Warp", "X-Plane", "Warps to Pureland (one-way travel)", "Matrieya's Tower (Floatland)", "47306_Game_Lists.txt"),
            new("Weapon", "Cannon", "Attacks all enemies: Damage = 200 - Def.", "Pre-installed", "47306_Game_Lists.txt"),
            new("Weapon", "Missile", "Attacks all enemies: Damage = 400 - Def.", "Mount Hasbid (Pureland)", "47306_Game_Lists.txt"),
            new("Weapon", "Laser", "Attacks all enemies: Damage = 600 - Def.", "Cirrus (Pureland)", "47306_Game_Lists.txt"),
            new("Weapon", "E-Ray", "Attacks all enemies: Damage = 800 - Def.", "Underworld Cave (Underworld)", "47306_Game_Lists.txt"),
            new("Weapon", "Shield", "Prevents random encounters", "Talonsburg (Pureland)", "47306_Game_Lists.txt"),
            new("Option", "Berth", "Recovers party HP, MP, and status", "Viper City (Future)", "47306_Game_Lists.txt"),
            new("Option", "Flushex", "Changes lead member to original form", "Lae (Past)", "47306_Game_Lists.txt")
        };

        return new Ffl3SystemData(mechanics, formulas, robotCapsules, talonUnits);
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