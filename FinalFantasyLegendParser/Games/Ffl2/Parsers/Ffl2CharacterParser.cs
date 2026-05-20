namespace FinalFantasyLegendParser.Games.Ffl2.Parsers;

internal sealed class Ffl2CharacterParser
{
    public IReadOnlyList<Ffl2CharacterRecord> Parse()
    {
        return
        [
            new("Human", "Class", "Battle-growth class that relies on equipment and items rather than native skills.", "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new("Mutant", "Class", "Battle-growth class with higher Mana and randomly acquired special skills.", "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new("Robot", "Class", "Equipment-growth class whose stats depend on loadout instead of battle gains.", "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new("Monster", "Class", "Transformation-growth class that changes by eating meat.", "12292_Guide_and_Walkthrough.txt; 16852_Monster_Evolution_FAQ.txt"),
            new("Mr. S", "NPC Ally", "Starting fifth member who carries strong early-game abilities and leaves once the opening arc ends.", "12292_Guide_and_Walkthrough.txt"),
            new("Ki", "NPC Ally", "Priestess of Isis who joins the party and opens the route into Ashura's Base.", "12292_Guide_and_Walkthrough.txt"),
            new("Ashura", "Boss", "Early major antagonist whose power comes from the Magi.", "12292_Guide_and_Walkthrough.txt"),
            new("Apollo", "Boss", "Later major antagonist tied to the Magi and endgame escalation.", "12292_Guide_and_Walkthrough.txt"),
            new("Venus", "Boss", "World ruler and major story boss.", "12292_Guide_and_Walkthrough.txt"),
            new("Dunatis", "Boss", "Apollo-world boss tied to the underwater cave route.", "12292_Guide_and_Walkthrough.txt"),
            new("Magnate", "Boss", "Sho-Gun world ruler and key story boss.", "12292_Guide_and_Walkthrough.txt"),
            new("Sho-Gun", "Boss", "Edo-world boss and ruler of Magnate's world.", "12292_Guide_and_Walkthrough.txt"),
            new("Odin", "Boss", "Recurring figure tied to the game's death and battle-reset framing.", "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new("Isis", "Deity", "The goddess whose Magi shards power the game's progression systems.", "12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt"),
            new("Dad", "Story Character", "The protagonist's father and the major personal thread through the game's worlds.", "12292_Guide_and_Walkthrough.txt")
        ];
    }
}
