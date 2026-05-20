# Final Fantasy Legend 2 - Complete LLM Guide

**Version**: 0.2

**Sources**: 12292_Guide_and_Walkthrough.txt, 29741_Robot_Guide.txt, 16852_Monster_Evolution_FAQ.txt, 12084_Save_State_Hacking_Guide.txt, 29802_Translation_Differences_FAQ.txt, and selected alternate walkthrough guides.

**Notes**: This parser-generated FFL2 reference now combines system notes with structured monsters, shop-derived equipment, guide-derived MAGI and key item notes, status data, and a walkthrough chronology linked to named entities.

## Sections

- Combat and Damage Rules
- Character Progression
- Enhancement and Class Differences
- Extra System Notes
- Story Chronology
- Characters
- Equipment
- Items
- Spells and Books
- Abilities
- Status Effects
- Monsters
- Class Progression Summary
- Mutant Skill Tiers

## Combat and Damage Rules

- **Core stats**: HP and max HP define survivability, Strength powers heavy weapons, Agility drives hit rate, evasion, turn order, and light-weapon damage, Defense cuts physical damage, and Mana improves spell damage and healing.
  Sources: 29741_Robot_Guide.txt
- **Ranged weapons**: Guns, bows, and explosives are described as having static attack values. Their damage does not scale with normal stats the way melee weapons do, but high enemy defense still lowers their output.
  Sources: 29741_Robot_Guide.txt
- **MAGI effects**: Stat MAGI provide hidden boosts such as Power MAGI raising Strength and Mana MAGI raising Mana. Elemental MAGI both boost matching magic and grant elemental protection, although the guide flags several buggy protection interactions.
  Sources: 29741_Robot_Guide.txt
- **Immunities and weaknesses**: O-series traits grant layered defenses such as O-Damage, O-Weapon, O-Change, and O-All. X-element traits mark weaknesses that increase incoming elemental damage and can enable instant-kill style weakness hits from matching elemental weapons.
  Sources: 29741_Robot_Guide.txt
- **Running and turn flow**: Escape odds depend on your Agility compared to the enemy. If you fail to run, the enemy gets a free round of actions.
  Sources: 29741_Robot_Guide.txt
- **Formula coverage**: The selected FFL2 guides document many combat rules and scaling behaviors, but they do not provide the same explicit closed-form damage equations that were found for FFL3. This module therefore records guide-derived mechanics rather than exact formulas.
  Sources: 12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt

## Character Progression

- **Humans**: Humans grow by fighting battles. Strength, Defense, Agility, Mana, and HP all improve through combat, with stronger enemies accelerating growth. Humans can carry eight items and rely entirely on equipment and items because they have no native skills.
  Sources: 12292_Guide_and_Walkthrough.txt
- **Mutants**: Mutants use the same battle-growth model as humans but at a slightly slower rate. In exchange they have higher Mana and can learn special skills if space remains in their ability list. Using more skills is explicitly recommended for building Mana.
  Sources: 12292_Guide_and_Walkthrough.txt
- **Robots**: Robots do not grow from battle at all. Their HP and combat stats come from equipped weapons and armor, and every equip or unequip action halves the remaining uses on most robot-bound weapons. Inns restore depleted robot weapons to 50 percent of maximum uses.
  Sources: 12292_Guide_and_Walkthrough.txt; 29741_Robot_Guide.txt
- **Monsters**: Monsters grow through meat. Eating strong meat, especially boss meat, improves them, while weak meat can regress them. The evolution FAQ further explains that family changes are based on current family, meat modifier, class modifier, and DS level.
  Sources: 12292_Guide_and_Walkthrough.txt; 16852_Monster_Evolution_FAQ.txt
- **Mutant skill tiers**: Mutant skills are tied to the defeated enemy's DS level. Late-world enemies and bosses unlock the top-tier skill pool, which is why advanced skills such as Teleport, Flare, and O-All cluster around the high-DS end of the game.
  Sources: 16852_Monster_Evolution_FAQ.txt

## Enhancement and Class Differences

- **Battle actions and stat focus**: Repeated heavy-weapon use raises Strength odds, light weapons raise Agility odds, shields help Defense growth, and books, staffs, psi blades, and mutant abilities improve Mana growth odds.
  Sources: 29741_Robot_Guide.txt
- **Robot loadouts**: Robots can layer armor because the normal body-slot restrictions do not apply to them. The robot guide also notes that same-tier armor pieces grant the same robot protection values, making gloves the cheapest way to buy that defense tier.
  Sources: 29741_Robot_Guide.txt
- **Martial arts**: Martial arts get stronger as they are used and do not have their uses halved when equipped on or removed from robots. They are also a cheap way to pad robot Agility even if robots should not rely on them for raw damage.
  Sources: 29741_Robot_Guide.txt
- **Robot ceilings and risks**: Robots can push focused stats past the displayed 99 and approach 200 in practice, but the guide warns that extremely high Agility can create odd turn-order behavior. Robots are also especially vulnerable to magic and recover less HP from magical healing.
  Sources: 29741_Robot_Guide.txt

## Extra System Notes

- **Battle rewards**: Only one item drop or meat drop can be earned per fight, but each human or mutant can still gain one stat increase or one new ability from that same battle.
  Sources: 29741_Robot_Guide.txt
- **Recommended robot economics**: The robot guide frames robots as a money sink early and a stat-efficient powerhouse later. If treasure is funneled to robots and HP-recovery tricks are used, they stop consuming money on recovery and instead convert cash directly into stronger permanent equipment states.
  Sources: 29741_Robot_Guide.txt

## Story Chronology

### 1. Hometown

- **Section**: 1
- **Summary**: When the game begins, you are presented with the story. After the story, you will be asked to choose and name your main character. I chose a Human (m), but you can choose which ever character you like best. Name the character. There is a short cut-scene in which your father gives you the Prism Magi, and then he proceeds to exit through the window. When you can control your character, go visit the School which is at t...

### 2. The Cave of North

- **Section**: 2
- **Summary**: Exit the town with Mr. S. in your party. Go into the cave that is to the north. Mr. S.' Fire skill will be able to defeat all of the enemies in the Cave if you are too weak. Follow the path until you come to a door-like opening. Go through it and go up the stairs to get Bronze Shield and a Cure Potion. Climb down the stairs and go right then climb the next set of stairs. In the next area, climb down the stairs. Follo...
- **Monsters**: BabyWyrm
- **Items**: Cure Potion
- **Equipment**: Bronze Shield; Hammer
- **Abilities**: Bronze Shield; Cure Potion; Hammer

### 3. First Town

- **Section**: 3
- **Summary**: The people in this town speak of a Shrine which is to the west. In this town you can buy some good Weapons and Items. S-Sword A-Armor B-Book H-Helmet G-Gauntlet K-Knife Sh-Shield P-Potion x- means infinite use You should by as many weapons and items as you can afford. You should buy at least 2 Cure P. Don't equip your mutants (if you have any) with weapons because you'll be able to buy Magic for them in the next Town...
- **Characters**: Ashura
- **Monsters**: Ashura
- **Equipment**: Hammer; Punch; Rapier
- **Abilities**: Hammer; Punch
- **Status Effects**: Curse

### 4. Shrine of Isis

- **Section**: 4
- **Summary**: This is the big building to the west of the 1st town. When you're inside, head north up the stairs and talk to the lady who is standing in front of the Statue. She will heal your wounds (rejuvenate your HP), and then give you directions to the Relics of the Ancient Gods. Leave the Shrine and head SW to enter the forest and find the big rock Ki spoke of. Go 4 steps East from the rock, then go 3 steps South from your c...
- **Monsters**: Ancient

### 5. Relics of the Ancient Gods

- **Section**: 5
- **Summary**: Go north up the stairs. From here, going left and right from the split in the path lead you to the same area. Go up the stairs and then into the little door. In the next room, go up the stairs to get a Whip. After the Whip, go back down the stairs. Going left or right from here will lead you to the same area. When you reach the little door, go through it and then go down the stairs. Follow this path right, then go up...
- **Characters**: Ashura
- **Monsters**: Ashura

### 6. Return to Shrine of Isis

- **Section**: 6
- **Summary**: Go all the way inside the Shrine and talk to Ki. She will heal you and then she'll join your party because she is the only one who can enter Ashura's Base. She is very strong compared to the members of your party. Her attacks are very useful. Exit the Shrine and NW then NE to get to the second town.
- **Characters**: Ashura
- **Monsters**: Ashura

### 7. Second Town

- **Section**: 7
- **Summary**: Before you enter the Town, engage in some battles in order to get some more GP. When you feel you have enough money, enter the Town. The people in this Town talk about Ashura's Base. First off, head into the Inn to heal yourself if needed, then go visit the Shops. Buy some Magic Books for your Mutant(s). You may notice that the Heal Rod costs an amazing 17000 GP. Buy this only if you have ample GP. The Magic Book of...
- **Characters**: Ashura
- **Monsters**: Ashura
- **Items**: Elixir
- **Equipment**: Rocket; X-Cure
- **Spells**: Heal Rod; Temptat
- **Abilities**: Rocket; Temptat
- **Status Effects**: Curse

### 8. Ashura's Base

- **Section**: 8
- **Summary**: Be careful! If you touch any of the enemies you see walking around, you will be engaged in a battle! (there are still "regular battles"). Follow the path through the 1St and 2nd floors. On the 3rd floor, don't forget to get the Speed Potion in the treasure chest. Keep following the path, and on the 4th floor get the Axe in the treasure chest. On the 5th floor, follow the path and go through the door. Go talk to the e...
- **Monsters**: Rhino
- **Equipment**: Rapier
- **Abilities**: Blizzard; Explode; Touch

### 9. Ashura's World

- **Section**: 9
- **Summary**: 

### 10. Desert Town

- **Context**: Ashura's World
- **Section**: 9.a
- **Summary**: The people in this town talk about Ashura and how he came to power using the Magi. The Shops in this Town have good weapons and items, but you might want to save you money to buy things in the next town. When you are finished shopping, heal at the Inn, then head to the Café to get directions to Ashura's Tower. In order to get the right directions, you have to pay the man behind the counter 10 GP. The Tower is 7 east...
- **Characters**: Ashura
- **Monsters**: Ashura; Silver
- **Equipment**: Rapier; Stungun
- **Abilities**: Counter; StunGun
- **Status Effects**: Curse

### 11. Ashura's Town

- **Context**: Ashura's World
- **Section**: 9.b
- **Summary**: If you have some money to spend, spend it here. There are some good weapons and items for sale. If you have enough money you should buy the Heal Rod. It will be helpful. The Sabre S and Battle S are very good weapons. They will be very helpful in Ashura's Tower. Heal at the Inn, and go to the Café if you want to. When you are ready, leave town and enter Ashura's Tower.
- **Characters**: Ashura
- **Monsters**: Ashura
- **Items**: Elixir
- **Equipment**: Stungun; X-Cure
- **Spells**: Heal Rod
- **Abilities**: StunGun
- **Status Effects**: Curse

### 12. Ashura's Tower

- **Context**: Ashura's World
- **Section**: 9.c
- **Summary**: When you go in the tower, go up the stairs then through the door to the 2nd floor. Go left and down around the poles, then up the stairs and through the door. Go right and open the chest to get a Sabre Sword. Head right, down, and then around up the stairs. Talk to the monster you see <>Mini-Boss: Woodman<> HP: 200-350 Weak vs.: nothing Strong vs.: nothing This enemy isn't too tough, just use your strongest weapons....
- **Characters**: Ashura
- **Monsters**: Ashura; Giant; Silver; Woodman
- **Equipment**: Battle Sword; Long Sword; Rapier; Sabre Sword; Silver Helmet; Silver Shield
- **Abilities**: Long Sword; Touch

### 13. Giant's World

- **Section**: 10
- **Summary**: Head south when you exit the Pillar to get to a Town. Enter the town and when the path splits, take the left path to get to a man. Talk to the man and he's your dad! You'll have a short conversation in which you try to convince him to come home with you, but he does not want to and he insists on continuing his quest to find the Magi. Before he leaves, he'll give you a Thunder Magi. Continue following the path and ent...
- **Monsters**: Fairy; Giant; Silver
- **Equipment**: Gold Bow; Katana S; Thunder B; X-Cure
- **Spells**: Temptat
- **Abilities**: Gold Sword; Katana; Poison; Stone; Temptat
- **Status Effects**: Curse; Poison; Stone

### 14. Inside Ki's Body

- **Section**: 11
- **Summary**: The pathways inside of Ki's body can be somewhat confusing at times, so remember where you have been, and remember where you are headed. From the entrace to Ki's body, walk down and when the path splits, take the left-most path. Follow this trail and enter the opening at the end of it. Work your way around the path and when you reach the multiple pathways, take the 2nd from the left. When you reach the round object,...
- **Characters**: Apollo
- **Monsters**: Apollo; Phagocyt
- **Abilities**: Colt Gun; Dissolve; Katana; Poison; Wind Up
- **Status Effects**: Poison

### 15. Apollo's World

- **Section**: 12
- **Summary**: Coming Soon! ******** G. Items ******** Coming Soon! ************************* H. Powering Up your Party ************************* Coming Soon! ***************

## Characters

- **Apollo** (Boss) - Later major antagonist tied to the Magi and endgame escalation.
- **Ashura** (Boss) - Early major antagonist whose power comes from the Magi.
- **Dad** (Story Character) - The protagonist's father and the major personal thread through the game's worlds.
- **Dunatis** (Boss) - Apollo-world boss tied to the underwater cave route.
- **Human** (Class) - Battle-growth class that relies on equipment and items rather than native skills.
- **Isis** (Deity) - The goddess whose Magi shards power the game's progression systems.
- **Ki** (NPC Ally) - Priestess of Isis who joins the party and opens the route into Ashura's Base.
- **Magnate** (Boss) - Sho-Gun world ruler and key story boss.
- **Monster** (Class) - Transformation-growth class that changes by eating meat.
- **Mr. S** (NPC Ally) - Starting fifth member who carries strong early-game abilities and leaves once the opening arc ends.
- **Mutant** (Class) - Battle-growth class with higher Mana and randomly acquired special skills.
- **Odin** (Boss) - Recurring figure tied to the game's death and battle-reset framing.
- **Robot** (Class) - Equipment-growth class whose stats depend on loadout instead of battle gains.
- **Sho-Gun** (Boss) - Edo-world boss and ruler of Magnate's world.
- **Venus** (Boss) - World ruler and major story boss.

## Equipment

- **Bronze Armor** [Armor] - Uses: -; Cost: 75; Availability: Desert Town; Notes: Sold in shops
- **Silver Armor** [Armor] - Uses: -; Cost: 2100; Availability: Giant's World; Notes: Sold in shops
- **Bronze Gauntlet** [Gauntlet] - Uses: -; Cost: 25; Availability: First Town; Notes: Sold in shops
- **Gold Gauntlet** [Gauntlet] - Uses: -; Cost: 3400; Availability: First Town; Giant's World; Notes: Sold in shops
- **Silver Gauntlet** [Gauntlet] - Uses: -; Cost: 700; Availability: Desert Town; Notes: Sold in shops
- **Bronze Helmet** [Helmet] - Uses: -; Cost: 50; Availability: First Town; Notes: Sold in shops
- **Silver Helmet** [Helmet] - Uses: -; Cost: 1400; Availability: Desert Town; Notes: Sold in shops
- **Bronze Shield** [Shield] - Uses: 50; Cost: 50; Availability: First Town; The Cave of North; Notes: Sold in shops; Walkthrough pickup.
- **Silver Shield** [Shield] - Uses: 50; Cost: 700; Availability: Ashura's World / Ashura's Tower; Desert Town; Notes: Sold in shops; Treasure chest pickup from the walkthrough.
- **Axe** [Weapon] - Uses: 50; Cost: 1400; Availability: Ashura's Base; Ashura's Town; Desert Town; Notes: Sold in shops; Walkthrough pickup.
- **Battle Sword** [Weapon] - Uses: 50; Cost: 3200; Availability: Ashura's Town; Giant's World; Ashura's World / Ashura's Tower; Notes: Sold in shops; Treasure chest pickup from the walkthrough.
- **Bow** [Weapon] - Uses: 50; Cost: 50; Availability: First Town; Notes: Sold in shops
- **Colt** [Weapon] - Uses: 50; Cost: 1400; Availability: Ashura's Town; Desert Town; Notes: Sold in shops
- **Gold Bow** [Weapon] - Uses: 50; Cost: 6800; Availability: Giant's World; Notes: Sold in shops
- **Hammer** [Weapon] - Uses: 50; Cost: 50; Availability: First Town; Notes: Sold in shops
- **Katana S** [Weapon] - Uses: 50; Cost: 6800; Availability: Giant's World; Notes: Sold in shops
- **Kick** [Weapon] - Uses: 50; 80; Cost: 1400; Availability: Ashura's Town; Desert Town; First Town; Notes: Sold in shops
- **Long Sword** [Weapon] - Uses: 50; Cost: 400; Availability: Desert Town; First Town; Notes: Sold in shops
- **Psi Knife** [Weapon] - Uses: 50; Cost: 1400; Availability: Ashura's Town; Desert Town; First Town; Notes: Sold in shops
- **Punch** [Weapon] - Uses: 90; Cost: 50; Availability: First Town; Notes: Sold in shops
- **Rapier** [Weapon] - Uses: 50; Cost: 400; Availability: Desert Town; First Town; Notes: Sold in shops
- **Rocket** [Weapon] - Uses: 30; Cost: 6800; Availability: Second Town; Notes: Sold in shops
- **Sabre Sword** [Weapon] - Uses: 50; Cost: 3200; Availability: Ashura's Town; Giant's World; Notes: Sold in shops
- **SMG** [Weapon] - Uses: 30; Cost: 6800; Availability: Giant's World; Second Town; Notes: Sold in shops
- **Stungun** [Weapon] - Uses: 40; Cost: 1400; Availability: Ashura's Town; Desert Town; Notes: Sold in shops
- **Thunder B** [Weapon] - Uses: 30; Cost: 6800; Availability: Giant's World; Notes: Sold in shops
- **Whip** [Weapon] - Uses: 40; Cost: 400; Availability: Desert Town; First Town; Relics of the Ancient Gods; Notes: Sold in shops; Walkthrough pickup.
- **X-Cure** [Weapon] - Uses: 4; Cost: 300; Availability: Ashura's Town; Notes: Sold in shops

## Items

- **Aegis Magi** [Key Item] - Uses: None; Cost: None; Availability: Venus battle reward; Effect: Special MAGI that can be equipped and used as a battle item.; Notes: Alternate translation: Aegis Shield.; Alternate walkthrough includes Aegis as part of the Venus MAGI reward bundle.; Listed in the save-state hacking guide item table.
- **Cure Potion** [Item] - Uses: 4; Cost: 50; Availability: Ashura's Town; Desert Town; First Town; Giant's World; Second Town; The Cave of North; Effect: None; Notes: Sold in shops; Walkthrough pickup.
- **Curse Potion** [Item] - Uses: 4; Cost: 300; 50; Availability: Ashura's Town; Desert Town; First Town; Giant's World; Second Town; Effect: None; Notes: Sold in shops
- **Defense Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's Base; Ashura's World / Ashura's Tower; Inside Ki's Body; Effect: Hidden defensive boost when equipped.; Notes: Alternate translation: Defense Magi.; NPC reward or story gift from the walkthrough.; Walkthrough pickup.
- **Elixir** [Item] - Uses: 1; Cost: 5000; Availability: Ashura's Town; Second Town; Effect: None; Notes: Sold in shops
- **Eye Drop Potion** [Item] - Uses: 4; Cost: 200; Availability: Ashura's Town; Desert Town; First Town; Giant's World; Second Town; Effect: None; Notes: Sold in shops
- **Fire Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's Base; Ashura's World / Ashura's Tower; Inside Ki's Body; Venus battle reward; Volcano; Effect: Elemental MAGI tied to fire protection and attack boosts.; Notes: Alternate translation: Flame Magi.; Robot guide notes that elemental MAGI behavior is buggy in some situations.; Boss reward or progression pickup from the walkthrough.; NPC reward or story gift from the walkthrough.; Walkthrough pickup.
- **Heart Magi** [Key Item] - Uses: None; Cost: None; Availability: Death Machine chest; Effect: Special MAGI that can be equipped and used as a battle item.; Notes: Alternate walkthrough identifies Heart Magi as the Death Machine chest reward.; Listed in the save-state hacking guide item table.
- **Ice Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's Base; Ashura's World / Ashura's Tower; Inside Ki's Body; Venus battle reward; Effect: Elemental MAGI tied to ice protection and attack boosts.; Notes: Alternate translation: Ice Magi.; Robot guide notes that elemental MAGI behavior is buggy in some situations.; Boss reward or progression pickup from the walkthrough.; Walkthrough pickup.
- **Magic Potion** [Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Effect: None; Notes: Treasure chest pickup from the walkthrough.
- **Mana Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Inside Ki's Body; Venus battle reward; Effect: Hidden MAN boost when equipped.; Notes: Alternate translation: Magic Magi.; Boss reward or progression pickup from the walkthrough.; Walkthrough pickup.
- **Masamune Magi** [Key Item] - Uses: None; Cost: None; Availability: None; Effect: Special MAGI documented in the item reference guides.; Notes: Listed in the save-state hacking guide item table.
- **Micron Potion** [Key Item] - Uses: None; Cost: None; Availability: Giant's World; Effect: None; Notes: Walkthrough pickup.
- **Pegasus Magi** [Key Item] - Uses: None; Cost: None; Availability: Nasty Dungeon; Effect: Teleports the party to visited towns and other main locations.; Notes: Alternate walkthrough identifies Pegasus Magi as the only MAGI in Nasty Dungeon.; Listed in the save-state hacking guide item table.
- **Poison Magi** [Key Item] - Uses: None; Cost: None; Availability: Giant's World; Inside Ki's Body; Venus battle reward; Volcano; Effect: Elemental MAGI tied to poison protection and attack boosts.; Notes: Alternate translation: Poison Magi.; Robot guide notes that elemental MAGI behavior is buggy in some situations.; Walkthrough pickup.
- **Power Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Giant's World; Venus battle reward; Effect: Hidden STR boost when equipped.; Notes: Alternate translation: Power Magi.; Boss reward or progression pickup from the walkthrough.; Walkthrough pickup.
- **Power Potion** [Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Effect: None; Notes: Treasure chest pickup from the walkthrough.
- **Prism Magi** [Key Item] - Uses: None; Cost: None; Availability: Hometown; Effect: Shows how many MAGI remain in the current world when used from the MAGI menu.; Notes: Alternate translation: Spirit Mirror.; NPC reward or story gift from the walkthrough.
- **Soft Potion** [Item] - Uses: 4; Cost: 1000; Availability: Ashura's Town; Desert Town; First Town; Giant's World; Second Town; Effect: None; Notes: Sold in shops
- **Speed Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Venus battle reward; Effect: Hidden AGL boost when equipped.; Notes: Alternate translation: Agility Magi.; Boss reward or progression pickup from the walkthrough.
- **Speed Potion** [Item] - Uses: None; Cost: None; Availability: Ashura's Base; Effect: None; Notes: Treasure chest pickup from the walkthrough.
- **Thunder Magi** [Key Item] - Uses: None; Cost: None; Availability: Ashura's World / Ashura's Tower; Giant's World; Inside Ki's Body; Venus battle reward; Effect: Elemental MAGI tied to thunder protection and attack boosts.; Notes: Alternate translation: Thunder Magi.; Robot guide notes that elemental MAGI behavior is buggy in some situations.; Boss reward or progression pickup from the walkthrough.; NPC reward or story gift from the walkthrough.; Walkthrough pickup.
- **True Eye Magi** [Key Item] - Uses: None; Cost: None; Availability: Volcano; Effect: Works automatically in special dungeons to reveal otherwise obscured areas.; Notes: Alternate translation: Eye of Truth.; Alternate walkthrough places TrueEye in the volcano alongside Fire and Poison MAGI.; Listed in the save-state hacking guide item table.
- **X-Cure Potion** [Item] - Uses: 4; Cost: 300; Availability: Giant's World; Second Town; Effect: None; Notes: Sold in shops

## Spells and Books

- **Cure Book** - Uses: 30; Cost: 6800; Availability: Ashura's Town; Giant's World; Second Town; Notes: Sold in shops
- **Fog Book** - Uses: 30; Cost: 6800; Availability: Second Town; Notes: Sold in shops
- **Heal Rod** - Uses: 15; Cost: 17000; Availability: Ashura's Town; Second Town; Notes: Sold in shops
- **Ice Book** - Uses: 30; Cost: 6800; Availability: Giant's World; Second Town; Notes: Sold in shops
- **Prayer Book** - Uses: 30; Cost: 6800; Availability: Second Town; Notes: Sold in shops
- **Sleep Book** - Uses: 30; Cost: 6800; Availability: Second Town; Notes: Sold in shops
- **Temptat** - Uses: 30; Cost: 6800; Availability: Giant's World; Second Town; Notes: Sold in shops
- **Thunder** - Uses: 30; Cost: 6800; Availability: Ashura's World / Ashura's Tower; Giant's World; Inside Ki's Body; Second Town; Notes: Boss reward or progression pickup from the walkthrough.; NPC reward or story gift from the walkthrough.; Walkthrough pickup.; Sold in shops

## Abilities

- **2-Swords** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **2-Tusks** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **3-Heads** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **3-Horns** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **4-Heads** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **6-Arms** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **8-Legs** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Abacus** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Absorb** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Acid** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Aegis Magi** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Army Armor** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Axe** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bash** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Battle Armor** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bazooka** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Beak** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Beam** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Blind** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Blitz** [Mutant Skill] - Availability: DS 3+; Notes: Opens stronger utility and elemental coverage.
- **Blitz** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Blitz Whip** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Blizzard** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bow** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Branch** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Breath** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bronze Armor** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bronze Glove** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bronze Helm** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bronze Helm Bronze Glove** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Bronze Shield** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Burning** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **ChainSaw** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Charm** [Mutant Skill] - Availability: DS 7+; Notes: Late-midgame control and physical resistance.
- **Charm** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Cobweb** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Coin** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Colt Gun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **ComVirus** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Counter** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Critical** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Cure** [Mutant Skill] - Availability: DS 1+; Notes: Base-world tier skills.
- **Cure** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Cure Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Cure Potion** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **CursSong** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **D-Beam** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Death Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Defend Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Defense** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Dispel** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Dissolve** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **DNA** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Dragon Helm** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Dragon Shield** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Dragon Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Drain** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Elixier** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Erase** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Explode** [Mutant Skill] - Availability: DS 6+; Notes: Adds strong burst and support options.
- **Explode** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **FatalGas** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Fin** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Fire** [Mutant Skill] - Availability: DS 1+; Notes: Base-world tier skills.
- **Fire** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Fire Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Fire Gun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flame** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flame Shield** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flame Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flare** [Mutant Skill] - Availability: DS A+; Notes: Top-tier endgame mutant skills.
- **Flare** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flare Book Heal Staff** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Flash** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Fog Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Gas** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Gaze** [Mutant Skill] - Availability: DS 4+; Notes: Midgame resist and status package.
- **Gaze** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Gold Shield** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Gold Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Grenade** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Gungnir** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Hammer** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Headbut** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Heal** [Mutant Skill] - Availability: DS 6+; Notes: Adds strong burst and support options.
- **Heal** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Heal Staff** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Heart Magi** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Heat** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Honey** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Horn** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Hypnos** [Mutant Skill] - Availability: DS 7+; Notes: Late-midgame control and physical resistance.
- **Hypnos** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ice** [Mutant Skill] - Availability: DS 1+; Notes: Base-world tier skills.
- **Ice** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ice Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ice Shield** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ice Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ink** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Jyudo** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Karate** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Katana** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Kick** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Kimono Armor** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Laser Gun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Laser Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Life** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Lightng** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Long Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **MadSong** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Mage Staff** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Magnum** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Masmune Magi** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Mirror** [Mutant Skill] - Availability: DS 9+; Notes: Strong late-game utility and all-element resistance.
- **Mirror** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Missile Cannon** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Multiply** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Muramas Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Musket Gun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Nail** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ninja Glove** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Ninja Glove Dragon Armor** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **NukeBomb** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-All** [Mutant Skill] - Availability: DS A+; Notes: Top-tier endgame mutant skills.
- **O-All** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-All Recover** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Change** [Mutant Skill] - Availability: DS 9+; Notes: Strong late-game utility and all-element resistance.
- **O-Change** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Damage** [Mutant Skill] - Availability: DS 8+; Notes: High-tier mobility and broad damage resistance.
- **O-Damage** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Fire** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Ice** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Pa/Po** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Para** [Mutant Skill] - Availability: DS 2+; Notes: Early-world defensive and elemental expansion.
- **O-Para** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Poison** [Mutant Skill] - Availability: DS 1+; Notes: Base-world tier skills.
- **O-Poison** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Quake** [Mutant Skill] - Availability: DS 2+; Notes: Early-world defensive and elemental expansion.
- **O-Quake** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Stone** [Mutant Skill] - Availability: DS 5+; Notes: Higher-DS control and protection skills.
- **O-Stone** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **O-Weapon** [Mutant Skill] - Availability: DS 7+; Notes: Late-midgame control and physical resistance.
- **O-Weapon** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **P-Blast** [Mutant Skill] - Availability: DS 9+; Notes: Strong late-game utility and all-element resistance.
- **P-Blast** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **P-Skin** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **ParaNail** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **ParaSkin** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Pegasus Magi** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Petrify** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Pincer** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Poison** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Psi Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Punch** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Quake** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Rapier Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Recover** [Mutant Skill] - Availability: DS A+; Notes: Top-tier endgame mutant skills.
- **Recover** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Riddle** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Rocket** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Samurai Bow** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sand** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Saw** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Selfix** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Selfix O-Pa/Po** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Seven Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Shell** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Silver Helm** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sleep** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sleep Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **SleepGas** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Smasher** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **SMG Gun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Squirt** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Stab** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Steal** [Mutant Skill] - Availability: DS 3+; Notes: Opens stronger utility and elemental coverage.
- **Steal** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Stench** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Stone** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Stone Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **StoneGas** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **StonGaze** [Mutant Skill] - Availability: DS 5+; Notes: Higher-DS control and protection skills.
- **StonGaze** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **StonSkin** [Mutant Skill] - Availability: DS 4+; Notes: Midgame resist and status package.
- **StonSkin** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **StunGun** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Stunner** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sun Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **SunBurst** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Surprise** [Mutant Skill] - Availability: DS 5+; Notes: Higher-DS control and protection skills.
- **Surprise** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Sypha** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tail** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tank Cannon X-Cure Potion** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Teleport** [Mutant Skill] - Availability: DS 8+; Notes: High-tier mobility and broad damage resistance.
- **Teleport** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Temptat** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tentacle** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Thorn** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Thunder** [Mutant Skill] - Availability: DS 2+; Notes: Early-world defensive and elemental expansion.
- **Thunder** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Thunder Book** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Thunder Sword** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tie Up** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tongue** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tornado** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Touch** [Mutant Skill] - Availability: DS 8+; Notes: High-tier mobility and broad damage resistance.
- **Touch** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **TrueEye** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Tusk** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Vulcan Cannon** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **W-Attack** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **W-Kick** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **W-Pincer** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Warning** [Mutant Skill] - Availability: DS 1+; Notes: Base-world tier skills.
- **Warning** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Whirl** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Wind Up** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **Wizard Staff** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Cure Potion** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Fire** [Mutant Skill] - Availability: DS 3+; Notes: Opens stronger utility and elemental coverage.
- **X-Fire** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Gaze** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Ice** [Mutant Skill] - Availability: DS 4+; Notes: Midgame resist and status package.
- **X-Ice** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Kick** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None
- **X-Thunder** [Mutant Skill] - Availability: DS 4+; Notes: Midgame resist and status package.
- **X-Thunder** [Monster Ability/Trait] - Availability: Monster stats guide; Notes: None

## Status Effects

- **Blindness** - Cured by: None; Notes: You lose sight and have difficulty attacking. (cure with
- **Confused** - Cured by: None; Notes: You are confused and unable to distinguish friend from foe.
- **Curse** - Cured by: Curse Potion; Notes: You are unable to move
- **Paralyze** - Cured by: None; Notes: Your body is numb and you can't control it. (cure with
- **Poison** - Cured by: Elixir; Notes: HP decreases each turn
- **Sleep** - Cured by: None; Notes: You are asleep and can't do anything.  (you will automatically
- **Stone** - Cured by: Soft; Notes: You are turned to stone and do not recover
- **Stunned** - Cured by: None; Notes: All your HP is lost

## Monsters

- **Adamant** - Tier: 25; HP: 507; STR: 51; AGL: 42; MAN: 45; DEF: 61; Abilities: Bash, Gas, Shell, Tusk, O-Poison, X-Ice
- **Ammonite** - Tier: 25; HP: 358; STR: 36; AGL: 31; MAN: 32; DEF: 27; Abilities: Ink, 8-Legs, Tusk, Shell, O-Fire, X-Thunder
- **Amoeba** - Tier: 22; HP: 148; STR: 15; AGL: 12; MAN: 12; DEF: 9; Abilities: Dissolve, Acid, X-Thunder
- **Anaconda** - Tier: 25; HP: 411; STR: 43; AGL: 41; MAN: 34; DEF: 43; Abilities: Tusk, Poison, Gas, Tie Up, O-Poison, X-Ice
- **Ancient** - Tier: 27; HP: 999; STR: 99; AGL: 99; MAN: 99; DEF: 99; Abilities: Masmune Magi, Aegis Magi, Heart Magi, TrueEye, Pegasus Magi, Flare, O-All Recover
- **Answerer** - Tier: 25; HP: 465; STR: 51; AGL: 53; MAN: 55; DEF: 49; Abilities: W-Attack, Counter, Defense, Stab, O-Damage, O-Change
- **Ant Lion** - Tier: 24; HP: 324; STR: 26; AGL: 36; MAN: 32; DEF: 36; Abilities: Pincer, Sand, Blind, Surprise, X-Ice
- **Anubis** - Tier: 27; HP: 912; STR: 91; AGL: 86; MAN: 80; DEF: 80; Abilities: Nail, Tusk, Ice, Mirror, Dispel, Heal, Cure, Recover
- **Apollo** - Tier: 1; HP: 25000; STR: 99; AGL: 99; MAN: 80; DEF: 99; Abilities: Flare, O-All
- **Arachne** - Tier: 27; HP: 858; STR: 86; AGL: 86; MAN: 86; DEF: 86; Abilities: Tusk, Poison, ParaNail, Cobweb, Gas, Tornado, Warning, O-Quake
- **Arsenal** - Tier: 31; HP: 10000; STR: 99; AGL: 99; MAN: 120; DEF: 99; Abilities: Smasher, O-Change
- **Ashura** - Tier: 24; HP: 900; STR: 18; AGL: 18; MAN: 17; DEF: 18; Abilities: 6-Arms, Flame, Sleep, Axe, O-Damage
- **Asigaru** - Tier: 0; HP: 120; STR: 5; AGL: 5; MAN: 2; DEF: 6; Abilities: Long Sword
- **Athtalot** - Tier: 27; HP: 804; STR: 86; AGL: 86; MAN: 91; DEF: 86; Abilities: Sword, Gaze, Flare, Erase, Cure, Teleport, O-Damage, O-Quake
- **Baby-D** - Tier: 23; HP: 248; STR: 26; AGL: 20; MAN: 26; DEF: 25; Abilities: Nail, Tusk, Flame, O-Quake
- **Baby-D** - Tier: 22; HP: 45; STR: 5; AGL: 2; MAN: 6; DEF: 5; Abilities: Nail, Flame, O-Quake
- **BabyWyrm** - Tier: 21; HP: 81; STR: 10; AGL: 9; MAN: 5; DEF: 8; Abilities: Beak, O-Quake
- **Barracud** - Tier: 21; HP: 99; STR: 6; AGL: 10; MAN: 8; DEF: 6; Abilities: Gas, Whirl, O-Fire, Tusk, X-Thunder
- **Basilisk** - Tier: 27; HP: 912; STR: 91; AGL: 75; MAN: 86; DEF: 86; Abilities: Nail, Tusk, Poison, ParaSkin, Gas, StonGaze, Warning, O-Change
- **Beetle** - Tier: 21; HP: 81; STR: 4; AGL: 10; MAN: 8; DEF: 10; Abilities: Horn, X-Ice
- **Behemoth** - Tier: 27; HP: 966; STR: 99; AGL: 75; MAN: 72; DEF: 86; Abilities: Nail, Tusk, Headbut, Bash, Quake, Recover, O-Weapon, O-Poison
- **Beholder** - Tier: 27; HP: 858; STR: 83; AGL: 78; MAN: 97; DEF: 86; Abilities: Beam, D-Beam, Gaze, StonGaze, X-Gaze, Warning, Explode, O-Quake
- **Big Eye** - Tier: 22; HP: 182; STR: 17; AGL: 14; MAN: 23; DEF: 18; Abilities: Gaze, Warning, O-Quake
- **Bl. Belt** - Tier: 6; HP: 731; STR: 73; AGL: 81; MAN: 68; DEF: 71; Abilities: Punch, Kick, Headbut, X-Kick, Jyudo, Karate, Samurai Bow
- **BlackCat** - Tier: 25; HP: 731; STR: 78; AGL: 73; MAN: 68; DEF: 73; Abilities: Nail, Tusk, Gaze, Erase, Surprise, Warning
- **BoneKing** - Tier: 26; HP: 756; STR: 71; AGL: 73; MAN: 81; DEF: 66; Abilities: Sword, Thunder, Ice, Erase, O-Ice, O-Weapon, O-Pa/Po
- **Boulder** - Tier: 24; HP: 430; STR: 39; AGL: 32; MAN: 39; DEF: 51; Abilities: Bash, StoneGas, Sand, Surprise, O-Change
- **Byak-Ko** - Tier: 27; HP: 858; STR: 91; AGL: 86; MAN: 80; DEF: 86; Abilities: Tusk, Sword, Blizzard, Flash, Tornado, Teleport, Recover, O-Damage
- **C-Fisher** - Tier: 26; HP: 731; STR: 63; AGL: 78; MAN: 66; DEF: 78; Abilities: Tusk, Pincer, Flame, Gas, Mirror, Teleport, O-Quake
- **Cameleon** - Tier: 22; HP: 208; STR: 21; AGL: 13; MAN: 18; DEF: 18; Abilities: Tongue, Warning, X-Ice
- **Cancer** - Tier: 26; HP: 681; STR: 78; AGL: 73; MAN: 73; DEF: 73; Abilities: Wind Up, Dissolve, Surprise, Warning, Recover, O-Weapon, X-Ice
- **CatWoman** - Tier: 25; HP: 549; STR: 55; AGL: 51; MAN: 47; DEF: 47; Abilities: Tusk, Nail, Charm, Poison, Surprise, Recover
- **Chafer** - Tier: 23; HP: 248; STR: 19; AGL: 28; MAN: 25; DEF: 28; Abilities: Bash, Steal, O-Quake, X-Ice
- **Champgno** - Tier: 24; HP: 324; STR: 32; AGL: 29; MAN: 32; DEF: 36; Abilities: Punch, Poison, SleepGas, Blind, O-Para
- **Chimera** - Tier: 25; HP: 591; STR: 68; AGL: 61; MAN: 52; DEF: 61; Abilities: Tusk, Nail, Flame, 3-Heads, Warning, O-Quake
- **Cicada** - Tier: 27; HP: 706; STR: 71; AGL: 81; MAN: 71; DEF: 73; Abilities: Sword, Tusk, Absorb, Thunder, MadSong, CursSong, O-Quake, X-Ice
- **Clayman** - Tier: 23; HP: 278; STR: 25; AGL: 19; MAN: 25; DEF: 28; Abilities: Punch, Kick, Wind Up, O-Pa/Po
- **Cleric** - Tier: 7; HP: 80; STR: 8; AGL: 13; MAN: 14; DEF: 11; Abilities: Hammer, Bronze Shield, Thunder Book, Cure Book, Bronze Armor, Bronze Helm Bronze Glove
- **Cobble** - Tier: 22; HP: 137; STR: 12; AGL: 7; MAN: 13; DEF: 18; Abilities: Bash, Sand, O-Change
- **Cocatris** - Tier: 25; HP: 522; STR: 61; AGL: 73; MAN: 66; DEF: 55; Abilities: Petrify, StonSkin, Nail, Surprise, Warning, O-Quake
- **Commando** - Tier: 5; HP: 410; STR: 43; AGL: 43; MAN: 33; DEF: 41; Abilities: X-Kick, Fire Gun, Bazooka, Magnum, Army Armor, Surprise
- **Conjurer** - Tier: 1; HP: 123; STR: 8; AGL: 16; MAN: 17; DEF: 9; Abilities: Sleep Book, Cure Book
- **Corpuscl** - Tier: 25; HP: 290; STR: 36; AGL: 32; MAN: 32; DEF: 32; Abilities: Wind Up, Dissolve, Multiply, Recover, O-Weapon, X-Ice
- **Crab** - Tier: 21; HP: 115; STR: 10; AGL: 12; MAN: 13; DEF: 17; Abilities: W-Pincer, X-Thunder
- **D-Turtle** - Tier: 26; HP: 731; STR: 73; AGL: 63; MAN: 64; DEF: 86; Abilities: Tusk, Bash, Gas, Shell, O-Poison, X-Ice
- **Dagon** - Tier: 27; HP: 831; STR: 80; AGL: 83; MAN: 86; DEF: 97; Abilities: W-Pincer, Tusk, ParaNail, Thunder, Whirl, O-Poison, O-Stone, O-Fire
- **DarkRose** - Tier: 27; HP: 858; STR: 86; AGL: 80; MAN: 91; DEF: 86; Abilities: Thorn, Absorb, Charm, Poison, SleepGas, Blind, FatalGas, O-Pa/Po
- **DemoLoad** - Tier: 26; HP: 681; STR: 73; AGL: 73; MAN: 78; DEF: 73; Abilities: Nail, Sleep, Fire, Stone, Teleport, O-Fire, O-Quake
- **Demon** - Tier: 25; HP: 465; STR: 51; AGL: 51; MAN: 55; DEF: 51; Abilities: Sleep, Fire, Nail, Hammer, O-Fire, O-Quake
- **Detectiv** - Tier: 7; HP: 473; STR: 46; AGL: 62; MAN: 39; DEF: 49; Abilities: Sypha, Coin, Kimono Armor, Temptat
- **Dinosaur** - Tier: 25; HP: 591; STR: 61; AGL: 42; MAN: 40; DEF: 51; Abilities: Tusk, Nail, Tail, Bash, O-Poison, X-Ice
- **Dolphin** - Tier: 27; HP: 5000; STR: 60; AGL: 60; MAN: 60; DEF: 60; Abilities: Blitz, Fin, Whirl, Tusk, Thunder, Tail, O-Quake, O-Fire
- **Dragon** - Tier: 25; HP: 614; STR: 64; AGL: 55; MAN: 60; DEF: 61; Abilities: Tusk, Flame, Nail, Tie Up, O-Fire, O-Quake
- **Dunatis** - Tier: 33; HP: 300; STR: 30; AGL: 30; MAN: 0; DEF: 29; Abilities: SMG Gun, ChainSaw, Blitz Whip, O-Pa/Po
- **Eagle** - Tier: 21; HP: 45; STR: 8; AGL: 13; MAN: 10; DEF: 5; Abilities: Beak, O-Quake
- **Earth** - Tier: 27; HP: 885; STR: 83; AGL: 72; MAN: 86; DEF: 99; Abilities: Bash, StoneGas, Quake, Sand, Recover, Warning, Surprise, O-Change
- **EchigoYa** - Tier: 2; HP: 443; STR: 43; AGL: 43; MAN: 36; DEF: 41; Abilities: Abacus, Vulcan Cannon, Psi Sword
- **Evil Eye** - Tier: 26; HP: 731; STR: 71; AGL: 66; MAN: 83; DEF: 73; Abilities: Flash, Beam, Gaze, Gaze, StonGaze, Warning, O-Quake
- **EvilPine** - Tier: 24; HP: 430; STR: 41; AGL: 35; MAN: 41; DEF: 45; Abilities: Bash, Branch, Wind Up, O-Para, X-Fire
- **F-Flower** - Tier: 25; HP: 614; STR: 61; AGL: 57; MAN: 66; DEF: 61; Abilities: Thorn, Poison, SleepGas, SunBurst, O-Pa/Po, X-Ice
- **F-Spider** - Tier: 26; HP: 731; STR: 73; AGL: 73; MAN: 66; DEF: 73; Abilities: Tusk, Poison, ParaNail, Cobweb, Gas, Flame, Warning
- **Fairy** - Tier: 24; HP: 373; STR: 32; AGL: 49; MAN: 51; DEF: 37; Abilities: Sleep, Thunder, Ice, Cure, O-Quake
- **Falcon** - Tier: 35; HP: 614; STR: 68; AGL: 61; MAN: 0; DEF: 68; Abilities: Defense, D-Beam, Vulcan Cannon, Beam, Warning, O-Pa/Po
- **FengLung** - Tier: 27; HP: 858; STR: 91; AGL: 89; MAN: 78; DEF: 86; Abilities: Nail, Tusk, Poison, Blind, Lightng, Tornado, O-Quake, O-Damage
- **Fenrir** - Tier: 24; HP: 2500; STR: 86; AGL: 80; MAN: 80; DEF: 94; Abilities: Tornado, Tusk, Blizzard, Recover, O-All
- **Fiend** - Tier: 21; HP: 104; STR: 13; AGL: 13; MAN: 15; DEF: 13; Abilities: Nail, Sleep
- **FireMoth** - Tier: 25; HP: 507; STR: 42; AGL: 57; MAN: 52; DEF: 47; Abilities: Stunner, Flame, Poison, Burning, Warning, O-Quake
- **Flower** - Tier: 21; HP: 81; STR: 8; AGL: 6; MAN: 10; DEF: 8; Abilities: Tusk, X-Ice
- **Fly** - Tier: 22; HP: 38; STR: 4; AGL: 7; MAN: 4; DEF: 5; Abilities: Nail, O-Quake, X-Ice
- **Fungus** - Tier: 20; HP: 45; STR: 5; AGL: 3; MAN: 5; DEF: 6; Abilities: Punch
- **G-7** - Tier: 36; HP: 756; STR: 78; AGL: 78; MAN: 0; DEF: 76; Abilities: Rocket, Laser Gun, Vulcan Cannon, Laser Sword, Missile Cannon, Selfix O-Pa/Po
- **Gae Bolg** - Tier: 24; HP: 373; STR: 41; AGL: 43; MAN: 45; DEF: 39; Abilities: Stab, W-Attack, Defense, O-Damage,
- **Gang** - Tier: 0; HP: 45; STR: 5; AGL: 7; MAN: 3; DEF: 4; Abilities: Punch
- **Garuda** - Tier: 26; HP: 656; STR: 71; AGL: 81; MAN: 71; DEF: 71; Abilities: Nail, Beak, Thunder, Blind, Tornado, Warning, O-Quake
- **Gazer** - Tier: 24; HP: 411; STR: 39; AGL: 35; MAN: 49; DEF: 41; Abilities: Flash, Beam, Gaze, Warning, O-Quake
- **Gen-Bu** - Tier: 27; HP: 858; STR: 86; AGL: 75; MAN: 83; DEF: 99; Abilities: Tusk, Bash, Gas, Shell, Cure, Recover, O-Poison, O-Para
- **Ghast** - Tier: 26; HP: 591; STR: 59; AGL: 42; MAN: 51; DEF: 42; Abilities: Tusk, ParaNail, Stench, P-Skin, O-Ice, O-Pa/Po, X-Fire
- **Ghost** - Tier: 27; HP: 885; STR: 78; AGL: 94; MAN: 94; DEF: 75; Abilities: Drain, Gaze, Erase, Touch, Cure, O-Weapon, O-Change, O-Quake
- **Ghoul** - Tier: 23; HP: 234; STR: 23; AGL: 13; MAN: 18; DEF: 13; Abilities: Tusk, ParaNail, O-Pa/Po, X-Fire
- **Giant** - Tier: 26; HP: 681; STR: 81; AGL: 71; MAN: 73; DEF: 73; Abilities: Punch, Kick, Bash, Sleep, Ice, Cure, Teleport
- **GianToad** - Tier: 26; HP: 756; STR: 73; AGL: 78; MAN: 62; DEF: 71; Abilities: Tongue, Kick, Tie Up, Gas, CursSong, Warning, O-Poison
- **GigaWorm** - Tier: 27; HP: 858; STR: 91; AGL: 78; MAN: 91; DEF: 83; Abilities: Tusk, Tail, Tie Up, Fire, Tornado, Teleport, O-Quake, O-Fire
- **Girl** - Tier: 7; HP: 100; STR: 16; AGL: 25; MAN: 21; DEF: 0; Abilities: Punch, Kick
- **Girl** - Tier: 7; HP: 247; STR: 23; AGL: 33; MAN: 28; DEF: 21; Abilities: Headbut, X-Kick
- **Gloom** - Tier: 26; HP: 731; STR: 63; AGL: 81; MAN: 81; DEF: 68; Abilities: Absorb, Poison, Stunner, FatalGas, Charm, Warning, O-Quake
- **Goblin** - Tier: 20; HP: 31; STR: 7; AGL: 4; MAN: 5; DEF: 5; Abilities: Punch
- **Great-D** - Tier: 26; HP: 731; STR: 76; AGL: 66; MAN: 71; DEF: 73; Abilities: Nail, Tusk, Flame, Blizzard, Tie Up, O-Fire, O-Quake
- **Griffon** - Tier: 22; HP: 169; STR: 22; AGL: 18; MAN: 16; DEF: 18; Abilities: Nail, Beak, O-Quake
- **Grippe** - Tier: 21; HP: 71; STR: 12; AGL: 15; MAN: 14; DEF: 16; Abilities: Poison, X-Fire
- **Guard** - Tier: 2; HP: 263; STR: 25; AGL: 22; MAN: 22; DEF: 29; Abilities: Gold Sword, Gold Shield, Cure Potion
- **Guardian** - Tier: 7; HP: 321; STR: 35; AGL: 35; MAN: 29; DEF: 15; Abilities: Gold Sword, SMG Gun, Blitz Whip, Army Armor, Cure Book
- **Guardian** - Tier: 7; HP: 700; STR: 70; AGL: 80; MAN: 60; DEF: 70; Abilities: Defend Sword, Vulcan Cannon, Magnum, Battle Armor, Heal Staff, Cure Book
- **Gunfish** - Tier: 26; HP: 781; STR: 68; AGL: 78; MAN: 73; DEF: 68; Abilities: Fin, Tusk, Tail, Blitz, Squirt, O-Quake, O-Fire
- **Haniwa** - Tier: 25; HP: 10000; STR: 90; AGL: 90; MAN: 90; DEF: 90; Abilities: Bash, Quake, Flare, Seven Sword, O-All, Recover
- **Harpy** - Tier: 23; HP: 203; STR: 23; AGL: 29; MAN: 28; DEF: 23; Abilities: Nail, Tusk, MadSong, O-Quake
- **Hatamoto** - Tier: 5; HP: 400; STR: 43; AGL: 43; MAN: 33; DEF: 44; Abilities: Katana, Bazooka, X-Cure Potion, Magnum
- **Hawk** - Tier: 33; HP: 324; STR: 38; AGL: 32; MAN: 0; DEF: 38; Abilities: Grenade, Fire Gun, Warning, O-Pa/Po
- **Hermit** - Tier: 24; HP: 392; STR: 37; AGL: 39; MAN: 41; DEF: 49; Abilities: W-Pincer, Shell, ParaNail, O-Fire, X-Thunder
- **Hofud** - Tier: 22; HP: 156; STR: 18; AGL: 20; MAN: 21; DEF: 17; Abilities: Stab, Defense, O-Change
- **Hornet** - Tier: 24; HP: 233; STR: 23; AGL: 29; MAN: 23; DEF: 25; Abilities: Tusk, Poison, Honey, O-Quake, X-Ice
- **HugeToad** - Tier: 25; HP: 637; STR: 61; AGL: 66; MAN: 52; DEF: 59; Abilities: Tongue, Kick, Gas, Tie Up, CursSong, O-Poison
- **Human  F** - Tier: 1; HP: 52; STR: 5; AGL: 6; MAN: 4; DEF: 3; Abilities: Rapier Sword, Bronze Armor
- **Human  M** - Tier: 1; HP: 59; STR: 6; AGL: 5; MAN: 3; DEF: 3; Abilities: Long Sword, Bronze Armor
- **Hydra** - Tier: 26; HP: 731; STR: 76; AGL: 73; MAN: 62; DEF: 76; Abilities: Tusk, Tie Up, 4-Heads, Gas, Recover, O-Poison, X-Fire
- **Ice Crab** - Tier: 25; HP: 591; STR: 57; AGL: 59; MAN: 55; DEF: 71; Abilities: W-Pincer, Blizzard, ParaSkin, Tusk, O-Ice, X-Thunder
- **Imp** - Tier: 21; HP: 31; STR: 5; AGL: 5; MAN: 6; DEF: 5; Abilities: Nail, Sleep
- **Intrcept** - Tier: 36; HP: 731; STR: 81; AGL: 73; MAN: 0; DEF: 81; Abilities: D-Beam, Vulcan Cannon, Beam, Missile Cannon, Warning, Selfix, O-Pa/Po
- **Ironman** - Tier: 26; HP: 781; STR: 73; AGL: 63; MAN: 66; DEF: 78; Abilities: Kick, Bash, Gas, Flame, Quake, O-Damage, O-Change
- **Jaguar** - Tier: 20; HP: 45; STR: 6; AGL: 5; MAN: 3; DEF: 5; Abilities: Tusk
- **Jelly** - Tier: 22; HP: 195; STR: 18; AGL: 14; MAN: 21; DEF: 18; Abilities: Dissolve, Wind Up, X-Fire
- **Jorgandr** - Tier: 27; HP: 858; STR: 89; AGL: 86; MAN: 80; DEF: 89; Abilities: Tusk, Tie Up, Gas, Quake, Teleport, Recover, O-Change, O-Quake
- **Kelpie** - Tier: 22; HP: 182; STR: 20; AGL: 20; MAN: 16; DEF: 18; Abilities: Tusk, Kick, Breath
- **Killer** - Tier: 5; HP: 507; STR: 51; AGL: 57; MAN: 47; DEF: 49; Abilities: Axe, ChainSaw, StunGun, Poison, Blitz Whip, Surprise
- **KingCrab** - Tier: 26; HP: 706; STR: 68; AGL: 71; MAN: 73; DEF: 83; Abilities: W-Pincer, Tusk, ParaNail, Thunder, O-Stone, O-Fire, X-Thunder
- **KingToad** - Tier: 27; HP: 885; STR: 86; AGL: 91; MAN: 80; DEF: 83; Abilities: Tongue, Kick, Tie Up, Gas, MadSong, CursSong, Warning, O-Poison
- **Kirin** - Tier: 27; HP: 831; STR: 94; AGL: 86; MAN: 80; DEF: 86; Abilities: Horn, Thunder, Cure, Tornado, Teleport, Recover, O-Quake, O-Damage
- **Knight** - Tier: 5; HP: 390; STR: 41; AGL: 37; MAN: 37; DEF: 47; Abilities: Flame Sword, Ice Sword, Thunder Sword, Flame Shield, Ice Shield, X-Cure Potion
- **Komodo** - Tier: 24; HP: 358; STR: 36; AGL: 26; MAN: 32; DEF: 32; Abilities: Tusk, Nail, Tail, Bash, X-Ice
- **Kraken** - Tier: 27; HP: 912; STR: 91; AGL: 83; MAN: 86; DEF: 78; Abilities: Tusk, 8-Legs, Ink, Tie Up, Thunder
- **Kusanagi** - Tier: 27; HP: 804; STR: 86; AGL: 89; MAN: 91; DEF: 83; Abilities: Absorb, Stab, W-Attack, Defense, Counter, Critical, O-Damage, O-Change
- **Lamia** - Tier: 24; HP: 507; STR: 49; AGL: 51; MAN: 57; DEF: 47; Abilities: Tail, Poison, Ice, Fire, Charm
- **LavaWorm** - Tier: 25; HP: 507; STR: 55; AGL: 44; MAN: 50; DEF: 49; Abilities: Tusk, Flame, Tail, Burning, O-Fire, X-Ice
- **Leviathn** - Tier: 27; HP: 912; STR: 80; AGL: 91; MAN: 86; DEF: 80; Abilities: Fin, Tusk, Tail, Blitz, Thunder, Whirl, O-Quake, O-Fire
- **Lich** - Tier: 27; HP: 885; STR: 83; AGL: 86; MAN: 94; DEF: 78; Abilities: Thunder, Ice, Erase, Flare, Teleport, O-Ice, O-Weapon, O-Pa/Po
- **Lilith** - Tier: 27; HP: 858; STR: 83; AGL: 86; MAN: 94; DEF: 80; Abilities: Tail, 6-Arms, Tie Up, Thunder, Flame, Charm, Quake, O-Damage
- **LiveOrk** - Tier: 23; HP: 263; STR: 25; AGL: 20; MAN: 25; DEF: 28; Abilities: Branch, Bash, O-Para, X-Fire
- **Lizard** - Tier: 21; HP: 59; STR: 6; AGL: 2; MAN: 5; DEF: 5; Abilities: Tusk, X-Ice
- **Madame** - Tier: 27; HP: 858; STR: 75; AGL: 94; MAN: 94; DEF: 80; Abilities: Absorb, Poison, Stunner, FatalGas, Heal, Charm, Warning, O-Quake
- **MadCedar** - Tier: 26; HP: 756; STR: 73; AGL: 66; MAN: 73; DEF: 78; Abilities: Branch, Bash, Wind Up, Riddle, Warning, O-Change, X-Fire
- **Magician** - Tier: 3; HP: 324; STR: 26; AGL: 38; MAN: 39; DEF: 27; Abilities: Fire Book, Ice Book, Sleep Book, Cure Book
- **Magnate** - Tier: 5; HP: 6000; STR: 63; AGL: 63; MAN: 63; DEF: 63; Abilities: Katana, Thunder, Tornado, Vulcan Cannon, Stone, O-Change
- **Mantcore** - Tier: 24; HP: 307; STR: 38; AGL: 32; MAN: 29; DEF: 32; Abilities: Nail, Tusk, Poison, Warning, O-Quake
- **Mantis** - Tier: 27; HP: 831; STR: 83; AGL: 94; MAN: 83; DEF: 86; Abilities: Tusk, 2-Swords, Drain, Thunder, Teleport, Surprise, O-Poison, O-Quake
- **MapleMan** - Tier: 22; HP: 195; STR: 18; AGL: 14; MAN: 18; DEF: 21; Abilities: Branch, Bash, X-Fire
- **Mazin** - Tier: 27; HP: 912; STR: 86; AGL: 75; MAN: 86; DEF: 91; Abilities: Sword, Branch, Flame, Beam, Tornado, Warning, O-Damage, O-Change
- **MechBug** - Tier: 32; HP: 248; STR: 29; AGL: 25; MAN: 0; DEF: 29; Abilities: SMG Gun, Blitz Whip, O-Pa/Po
- **Medusa** - Tier: 22; HP: 182; STR: 17; AGL: 18; MAN: 22; DEF: 16; Abilities: Tail, Poison, StonGaze
- **Mephisto** - Tier: 24; HP: 373; STR: 41; AGL: 41; MAN: 45; DEF: 41; Abilities: Nail, Sleep, Fire, O-Fire, O-Quake
- **Mercenar** - Tier: 3; HP: 358; STR: 34; AGL: 34; MAN: 26; DEF: 32; Abilities: Musket Gun, Grenade, SMG Gun, Cure Potion
- **Minion** - Tier: 24; HP: 5000; STR: 63; AGL: 63; MAN: 57; DEF: 63; Abilities: Flame, Gas, Tornado, Blizzard, Lightng
- **Moaner** - Tier: 26; HP: 681; STR: 73; AGL: 76; MAN: 78; DEF: 71; Abilities: Absorb, Stab, W-Attack, Defense, Counter, O-Damage, O-Change
- **Mosquito** - Tier: 25; HP: 392; STR: 39; AGL: 47; MAN: 39; DEF: 41; Abilities: Tusk, Absorb, Sword, Surprise, O-Quake, X-Ice
- **Moth** - Tier: 22; HP: 182; STR: 13; AGL: 22; MAN: 22; DEF: 16; Abilities: Bash, Poison, O-Quake
- **Musashi** - Tier: 6; HP: 2000; STR: 76; AGL: 76; MAN: 63; DEF: 78; Abilities: Stab, Defense, Counter, 2-Swords, Critical, Warning, Elixier
- **Mushroom** - Tier: 23; HP: 248; STR: 25; AGL: 22; MAN: 25; DEF: 28; Abilities: Punch, Poison, SleepGas, O-Para
- **Mutant F** - Tier: 12; HP: 45; STR: 4; AGL: 5; MAN: 6; DEF: 3; Abilities: Bow, Flame, Bronze Armor
- **Mutant M** - Tier: 12; HP: 52; STR: 5; AGL: 4; MAN: 6; DEF: 3; Abilities: Hammer, Blizzard, Bronze Armor
- **Naga** - Tier: 25; HP: 614; STR: 59; AGL: 61; MAN: 68; DEF: 57; Abilities: Poison, Ice, Tail, Fire, Cure, Charm
- **Nike** - Tier: 27; HP: 777; STR: 83; AGL: 94; MAN: 91; DEF: 83; Abilities: Sword, Thunder, Blind, Mirror, Charm, Tornado, Warning, O-Quake
- **Ninja** - Tier: 5; HP: 700; STR: 43; AGL: 43; MAN: 33; DEF: 45; Abilities: Katana, Blind, Mirror, Ice Sword, Surprise, Warning
- **Nitemare** - Tier: 25; HP: 507; STR: 53; AGL: 53; MAN: 43; DEF: 51; Abilities: Sword, Breath, Flame, Kick, Gaze, O-Fire
- **Nymph** - Tier: 25; HP: 568; STR: 50; AGL: 71; MAN: 66; DEF: 57; Abilities: Thunder, Sleep, Whirl, Ice, Cure, O-Quake
- **O-Bake** - Tier: 23; HP: 263; STR: 20; AGL: 29; MAN: 29; DEF: 19; Abilities: Sleep, Touch, O-Quake, X-Fire
- **Octopus** - Tier: 22; HP: 99; STR: 10; AGL: 7; MAN: 8; DEF: 5; Abilities: Tentacle, Ink, X-Thunder
- **Odin** - Tier: 4; HP: 3700; STR: 75; AGL: 75; MAN: 68; DEF: 75; Abilities: Gungnir, Lightng, Ice, Cure, O-Change
- **OdinCrow** - Tier: 26; HP: 669; STR: 75; AGL: 85; MAN: 79; DEF: 69; Abilities: Nail, Beak, Blind, Tornado, Surprise, Warning, O-Quake
- **Ogre** - Tier: 24; HP: 290; STR: 38; AGL: 31; MAN: 32; DEF: 32; Abilities: Kick, Punch, Bash, Sleep, Ice
- **Oni** - Tier: 21; HP: 104; STR: 16; AGL: 12; MAN: 13; DEF: 13; Abilities: Punch, Horn
- **P-Flower** - Tier: 24; HP: 324; STR: 32; AGL: 29; MAN: 36; DEF: 32; Abilities: Thorn, Poison, SleepGas, O-Pa/Po, X-Ice
- **P-Spider** - Tier: 22; HP: 182; STR: 18; AGL: 18; MAN: 18; DEF: 18; Abilities: Tusk, Poison, Cobweb
- **P-Toad** - Tier: 24; HP: 263; STR: 25; AGL: 28; MAN: 20; DEF: 23; Abilities: Tongue, P-Skin, Gas, O-Poison, X-Ice
- **P-Worm** - Tier: 23; HP: 248; STR: 28; AGL: 20; MAN: 28; DEF: 23; Abilities: Poison, Tie Up, P-Skin, O-Quake
- **Paladin** - Tier: 6; HP: 756; STR: 73; AGL: 68; MAN: 68; DEF: 81; Abilities: Sun Sword, Dragon Sword, Defend Sword, Dragon Shield, Dragon Helm, Ninja Glove Dragon Armor
- **Pathogen** - Tier: 24; HP: 316; STR: 39; AGL: 45; MAN: 43; DEF: 47; Abilities: Multiply, Poison, Heat, ParaSkin, X-Fire
- **Pebble** - Tier: 21; HP: 90; STR: 7; AGL: 4; MAN: 8; DEF: 13; Abilities: Bash, O-Change
- **Phagocyt** - Tier: 22; HP: 156; STR: 21; AGL: 18; MAN: 18; DEF: 18; Abilities: Wind Up, Dissolve, X-Ice
- **Phantom** - Tier: 24; HP: 430; STR: 35; AGL: 47; MAN: 47; DEF: 33; Abilities: Ice, Sleep, Touch, O-Quake, X-Fire
- **Piranha** - Tier: 24; HP: 358; STR: 29; AGL: 36; MAN: 32; DEF: 29; Abilities: Fin, Tusk, Tail, O-Fire, X-Thunder
- **Plague** - Tier: 26; HP: 606; STR: 71; AGL: 78; MAN: 76; DEF: 81; Abilities: Poison, Heat, ComVirus, Surprise, Multiply, DNA, X-Fire
- **Plasma** - Tier: 21; HP: 104; STR: 15; AGL: 13; MAN: 13; DEF: 13; Abilities: Dissolve, X-Ice
- **Pudding** - Tier: 26; HP: 756; STR: 73; AGL: 66; MAN: 71; DEF: 73; Abilities: Dissolve, Wind Up, P-Skin, Gas, Surprise, O-Weapon, O-Quake
- **Rakshasa** - Tier: 26; HP: 781; STR: 78; AGL: 73; MAN: 68; DEF: 68; Abilities: Tusk, Fire, Ice, Cure, Mirror, Surprise, Recover
- **Raven** - Tier: 22; HP: 143; STR: 17; AGL: 22; MAN: 21; DEF: 17; Abilities: Nail, Beak, O-Quake
- **Red Bone** - Tier: 23; HP: 90; STR: 7; AGL: 8; MAN: 11; DEF: 5; Abilities: Punch, Poison, O-Weapon, X-Fire
- **Revenant** - Tier: 27; HP: 966; STR: 97; AGL: 75; MAN: 86; DEF: 75; Abilities: Nail, Poison, Stench, ParaSkin, Touch, Recover, O-Ice, O-Pa/Po
- **Rhino** - Tier: 21; HP: 170; STR: 18; AGL: 8; MAN: 7; DEF: 13; Abilities: Tusk, X-Ice
- **Ridean** - Tier: 35; HP: 637; STR: 66; AGL: 66; MAN: 0; DEF: 64; Abilities: Rocket, Laser Gun, Vulcan Cannon, Laser Sword, Blitz, O-Pa/Po
- **ROBO-28** - Tier: 31; HP: 137; STR: 15; AGL: 15; MAN: 0; DEF: 14; Abilities: Rocket, O-Pa/Po
- **ROBO-Z** - Tier: 33; HP: 263; STR: 28; AGL: 28; MAN: 0; DEF: 26; Abilities: Rocket, Flame, Beam, O-Pa/Po
- **Robot** - Tier: 31; HP: 60; STR: 6; AGL: 5; MAN: 0; DEF: 6; Abilities: Colt Gun, O-Pa/Po
- **Roc** - Tier: 26; HP: 631; STR: 73; AGL: 86; MAN: 71; DEF: 66; Abilities: Nail, Beak, Blind, Tornado, Surprise, Warning, O-Quake
- **Rock** - Tier: 26; HP: 756; STR: 71; AGL: 61; MAN: 66; DEF: 86; Abilities: Bash, StoneGas, Quake, Sand, Warning, Surprise, O-Change
- **SabreCat** - Tier: 22; HP: 182; STR: 21; AGL: 18; MAN: 16; DEF: 18; Abilities: Nail, 2-Tusks, Surprise
- **Salamand** - Tier: 26; HP: 781; STR: 78; AGL: 63; MAN: 66; DEF: 73; Abilities: Nail, Tusk, Burning, Flame, Fire, O-Fire, X-Ice
- **Samurai** - Tier: 1; HP: 320; STR: 14; AGL: 14; MAN: 8; DEF: 15; Abilities: Long Sword, Silver Helm
- **Samurai** - Tier: 7; HP: 551; STR: 63; AGL: 60; MAN: 45; DEF: 56; Abilities: Muramas Sword, Katana, Ninja Glove, Kimono Armor, Samurai Bow, Cure Book
- **SandWorm** - Tier: 26; HP: 731; STR: 78; AGL: 66; MAN: 71; DEF: 71; Abilities: Tusk, Tail, Tie Up, Sand, Quake, Surprise, O-Quake
- **Scarab** - Tier: 27; HP: 881; STR: 75; AGL: 91; MAN: 86; DEF: 91; Abilities: Tusk, Gas, Bash, Stench, Cure, Teleport, O-Poison, O-Quake
- **Scylla** - Tier: 26; HP: 731; STR: 71; AGL: 73; MAN: 73; DEF: 68; Abilities: Tail, 4-Heads, Poison, Ice, Fire, Whirl, Charm
- **Sei-Ryu** - Tier: 27; HP: 858; STR: 89; AGL: 78; MAN: 91; DEF: 86; Abilities: Nail, Tusk, Tie Up, Lightng, Gas, Whirl, O-Quake, O-Damage
- **Serpent** - Tier: 24; HP: 324; STR: 34; AGL: 32; MAN: 29; DEF: 34; Abilities: Tusk, Poison, Tie Up, Surprise, X-Ice
- **Shark** - Tier: 25; HP: 549; STR: 47; AGL: 55; MAN: 51; DEF: 47; Abilities: Headbut, Tusk, Tail, Warning, O-Fire, X-Thunder
- **Shiitake** - Tier: 26; HP: 731; STR: 73; AGL: 68; MAN: 73; DEF: 78; Abilities: Punch, Bash, Poison, SleepGas, Blind, FatalGas, O-Para
- **Sho-gun** - Tier: 4; HP: 2000; STR: 41; AGL: 41; MAN: 41; DEF: 41; Abilities: Riddle, Poison, SleepGas, Katana, O-Change
- **Silver** - Tier: 21; HP: 126; STR: 14; AGL: 14; MAN: 10; DEF: 13; Abilities: Kick, Breath
- **Skelton** - Tier: 22; HP: 52; STR: 4; AGL: 5; MAN: 7; DEF: 2; Abilities: Punch, O-Weapon, X-Fire
- **Sleipnir** - Tier: 26; HP: 731; STR: 76; AGL: 76; MAN: 62; DEF: 73; Abilities: Tusk, W-Kick, Bash, Breath, Flame, Warning, O-Change
- **Slime** - Tier: 21; HP: 90; STR: 8; AGL: 5; MAN: 10; DEF: 8; Abilities: Dissolve, X-Fire
- **Slime** - Tier: 21; HP: 52; STR: 5; AGL: 2; MAN: 6; DEF: 5; Abilities: Dissolve, X-Fire
- **SlimeGod** - Tier: 27; HP: 885; STR: 86; AGL: 78; MAN: 91; DEF: 86; Abilities: Dissolve, Wind Up, P-Blast, Hypnos, Gas, Surprise, O-Weapon, O-Quake
- **Snake** - Tier: 21; HP: 81; STR: 9; AGL: 8; MAN: 6; DEF: 9; Abilities: Tusk, X-Ice
- **SnowCat** - Tier: 25; HP: 507; STR: 55; AGL: 51; MAN: 43; DEF: 51; Abilities: Tusk, Nail, Blizzard, Surprise, X-Fire
- **Sorcerer** - Tier: 5; HP: 614; STR: 52; AGL: 68; MAN: 64; DEF: 55; Abilities: Thunder Book, Stone Book, Mage Staff, Death Book, Ice Book, Cure Book
- **Spector** - Tier: 26; HP: 756; STR: 66; AGL: 81; MAN: 81; DEF: 63; Abilities: Ice, Stone, Touch, Cure, O-Weapon, O-Change, O-Quake
- **Sphinx** - Tier: 26; HP: 706; STR: 81; AGL: 73; MAN: 68; DEF: 73; Abilities: Nail, Tusk, Fire, Cure, Riddle, Warning, O-Quake
- **Spider** - Tier: 20; HP: 45; STR: 5; AGL: 5; MAN: 5; DEF: 5; Abilities: Tusk
- **Sprite** - Tier: 23; HP: 218; STR: 17; AGL: 31; MAN: 32; DEF: 22; Abilities: Sleep, Thunder, Cure, O-Quake
- **Squid** - Tier: 26; HP: 781; STR: 78; AGL: 71; MAN: 66; DEF: 66; Abilities: Tusk, 8-Legs, Ink, Tie Up, Thunder, Gas, O-Fire
- **SS** - Tier: 6; HP: 781; STR: 76; AGL: 76; MAN: 63; DEF: 73; Abilities: Laser Sword, Vulcan Cannon, Fire Gun, Missile Cannon, Tank Cannon X-Cure Potion, Army Armor
- **Stoneman** - Tier: 24; HP: 449; STR: 41; AGL: 33; MAN: 37; DEF: 45; Abilities: Bash, Punch, Gas, Sand, O-Change
- **Su-Zaku** - Tier: 27; HP: 750; STR: 86; AGL: 99; MAN: 91; DEF: 78; Abilities: Beak, Flame, Tornado, Blind, Recover, Warning, O-Quake, O-Damage
- **SunPlant** - Tier: 26; HP: 731; STR: 73; AGL: 68; MAN: 71; DEF: 73; Abilities: Thorn, Poison, SleepGas, Flame, O-Fire, O-Pa/Po, X-Ice
- **Susano-O** - Tier: 27; HP: 804; STR: 94; AGL: 83; MAN: 86; DEF: 86; Abilities: Sword, Bash, Thunder, Ice, Tornado, Teleport, O-Damage, Recover
- **Swallow** - Tier: 24; HP: 324; STR: 26; AGL: 38; MAN: 38; DEF: 29; Abilities: Absorb, Poison, Stunner, Warning, O-Quake
- **Sylph** - Tier: 26; HP: 681; STR: 61; AGL: 83; MAN: 78; DEF: 68; Abilities: Sleep, Thunder, Ice, Tornado, Cure, Teleport, O-Quake
- **T Rex** - Tier: 26; HP: 831; STR: 86; AGL: 63; MAN: 61; DEF: 73; Abilities: Nail, Tusk, Headbut, Bash, O-Weapon, O-Poison, X-Ice
- **Tarantla** - Tier: 24; HP: 411; STR: 41; AGL: 41; MAN: 41; DEF: 41; Abilities: Tusk, Poison, ParaNail, Cobweb, Warning
- **Teacher** - Tier: 27; HP: 185; STR: 18; AGL: 15; MAN: 19; DEF: 18; Abilities: Dissolve, Fire, Cure
- **Ten-Gu** - Tier: 25; HP: 545; STR: 59; AGL: 68; MAN: 60; DEF: 59; Abilities: Beak, Thunder, Nail, Tornado, Blind, O-Quake
- **Terorist** - Tier: 1; HP: 148; STR: 14; AGL: 14; MAN: 8; DEF: 13; Abilities: Colt Gun, Kick
- **Thunder** - Tier: 23; HP: 188; STR: 25; AGL: 32; MAN: 28; DEF: 20; Abilities: Beak, Thunder, Warning, O-Quake
- **TianLung** - Tier: 24; HP: 2000; STR: 86; AGL: 94; MAN: 80; DEF: 83; Abilities: Tornado, Tusk, Lightng, Gas, O-All
- **Titania** - Tier: 27; HP: 804; STR: 72; AGL: 97; MAN: 99; DEF: 80; Abilities: Fire, Thunder, Ice, Flare, Cure, Erase, Teleport, O-Quake
- **Toad** - Tier: 21; HP: 52; STR: 5; AGL: 6; MAN: 3; DEF: 4; Abilities: Tongue, X-Ice
- **Toadstol** - Tier: 27; HP: 858; STR: 86; AGL: 80; MAN: 86; DEF: 91; Abilities: Punch, Bash, Poison, SleepGas, Blind, FatalGas, Recover, O-Para
- **Tororo** - Tier: 24; HP: 341; STR: 32; AGL: 27; MAN: 36; DEF: 32; Abilities: Dissolve, Wind Up, Surprise, O-Weapon, X-Fire
- **Tortoise** - Tier: 22; HP: 182; STR: 18; AGL: 13; MAN: 17; DEF: 25; Abilities: Tusk, Shell, X-Ice
- **Treant** - Tier: 27; HP: 885; STR: 86; AGL: 78; MAN: 86; DEF: 91; Abilities: Branch, Bash, Wind Up, Heal, Life, Recover, Warning, O-Change
- **Triceras** - Tier: 24; HP: 392; STR: 41; AGL: 26; MAN: 24; DEF: 32; Abilities: Nail, Tusk, 3-Horns, Bash, X-Ice
- **Trooper** - Tier: 1; HP: 90; STR: 8; AGL: 6; MAN: 6; DEF: 11; Abilities: Long Sword, Bronze Shield
- **Turtle** - Tier: 23; HP: 248; STR: 25; AGL: 19; MAN: 23; DEF: 32; Abilities: Tusk, Bash, Shell, X-Ice
- **Unicorn** - Tier: 27; HP: 858; STR: 89; AGL: 89; MAN: 80; DEF: 86; Abilities: Kick, Horn, Charm, Cure, Heal, Teleport, Warning, O-Change
- **Unknown** - Tier: 27; HP: 321; STR: 35; AGL: 29; MAN: 35; DEF: 2; Abilities: Bronze Glove
- **Unknown** - Tier: 7; HP: 321; STR: 35; AGL: 29; MAN: 35; DEF: 11; Abilities: Hammer, Bronze Shield, Bronze Armor, Bronze Helm, Bronze Glove
- **Venus** - Tier: 4; HP: 2500; STR: 52; AGL: 52; MAN: 52; DEF: 52; Abilities: Charm, Blitz Whip, Flame, Erase, O-Damage
- **Virus** - Tier: 22; HP: 117; STR: 17; AGL: 21; MAN: 20; DEF: 22; Abilities: Poison, Heat, X-Fire
- **WarMach** - Tier: 34; HP: 10000; STR: 120; AGL: 60; MAN: 0; DEF: 90; Abilities: Missile Cannon, NukeBomb, Bash, ParaNail, O-Pa/Po
- **Warrior** - Tier: 25; HP: 347; STR: 31; AGL: 32; MAN: 38; DEF: 27; Abilities: Sword, Saw, Axe, O-Weapon, O-Pa/Po, X-Fire
- **Watcher** - Tier: 25; HP: 614; STR: 59; AGL: 55; MAN: 71; DEF: 61; Abilities: Flash, Beam, Gaze, StonGaze, Warning, O-Quake
- **WereRat** - Tier: 21; HP: 99; STR: 10; AGL: 8; MAN: 6; DEF: 6; Abilities: Nail, Recover
- **WereWolf** - Tier: 23; HP: 278; STR: 28; AGL: 25; MAN: 22; DEF: 22; Abilities: Nail, Tusk, Surprise, Recover
- **Wh. Belt** - Tier: 2; HP: 248; STR: 25; AGL: 29; MAN: 22; DEF: 23; Abilities: Punch, Kick, Headbut
- **Wight** - Tier: 26; HP: 831; STR: 83; AGL: 63; MAN: 73; DEF: 63; Abilities: Tusk, ParaNail, Stench, ParaSkin, Touch, O-Ice, O-Pa/Po
- **Wizard** - Tier: 6; HP: 731; STR: 63; AGL: 81; MAN: 75; DEF: 66; Abilities: Thunder Book, Fog Book, Stone Book, Mage Staff, Wizard Staff, Flare Book Heal Staff
- **Woodman** - Tier: 21; HP: 148; STR: 13; AGL: 8; MAN: 13; DEF: 15; Abilities: Punch, X-Fire
- **Worm** - Tier: 21; HP: 126; STR: 15; AGL: 9; MAN: 15; DEF: 12; Abilities: Tail, O-Quake
- **Wraith** - Tier: 25; HP: 528; STR: 44; AGL: 57; MAN: 57; DEF: 42; Abilities: Touch, Ice, Sleep, O-Change, O-Quake, X-Fire
- **Wyrm** - Tier: 26; HP: 731; STR: 78; AGL: 76; MAN: 60; DEF: 73; Abilities: Nail, Tusk, Tail, Poison, Blind, Lightng, O-Quake
- **Wyrm Kid** - Tier: 22; HP: 182; STR: 21; AGL: 20; MAN: 14; DEF: 18; Abilities: Beak, Blind, O-Quake
- **Wyvern** - Tier: 24; HP: 411; STR: 45; AGL: 43; MAN: 35; DEF: 41; Abilities: Tusk, Nail, Poison, Blind, O-Quake
- **Young-D** - Tier: 24; HP: 507; STR: 53; AGL: 44; MAN: 50; DEF: 51; Abilities: Nail, Tusk, Flame, Tie Up, O-Quake
- **Zombie** - Tier: 22; HP: 117; STR: 12; AGL: 4; MAN: 8; DEF: 4; Abilities: Nail, Tusk, X-Fire
- **{NULL}** - Tier: 0; HP: 858; STR: 75; AGL: 94; MAN: 97; DEF: 78; Abilities: Rocket, O-Pa/Po
- **{NULL}** - Tier: 30; HP: 858; STR: 94; AGL: 86; MAN: 0; DEF: 94; Abilities: SMG Gun, ChainSaw, Blitz Whip, O-Pa/Po
- **{NULL}** - Tier: 20; HP: 804; STR: 91; AGL: 86; MAN: 86; DEF: 86; Abilities: Poison, X-Fire
- **{Null}** - Tier: 20; HP: 723; STR: 83; AGL: 91; MAN: 89; DEF: 94; Abilities: Dissolve, Fire, Cure

## Class Progression Summary

- **Human** - Growth: Battle-driven stat growth across Strength, Defense, Agility, Mana, and HP. Enhancement: Use weapons, armor, and books in battle; carry up to eight items. Constraints: No native skills.
- **Mutant** - Growth: Battle-driven growth similar to humans, but slightly slower. Enhancement: Use learned skills and spell items to build Mana; leave room in the ability list to keep learning. Constraints: Maximum of four acquired special skills inside the eight-item inventory.
- **Robot** - Growth: No battle growth; stats come from equipment and recharge behavior. Enhancement: Equip the strongest weapons and armor possible, and treat item choice as permanent stat tuning. Constraints: Equipping and unequipping halves weapon uses; robots cannot use magic.
- **Monster** - Growth: Transforms into new species by eating meat rather than leveling conventionally. Enhancement: Target strong and boss meat to climb families and DS tiers. Constraints: Weak meat can reduce power; monsters depend on form quality more than inventory.

## Mutant Skill Tiers

- **DS 1+** - Cure, Warning, Fire, O-Poison, Ice (Base-world tier skills.)
- **DS 2+** - O-Para, Thunder, O-Quake (Early-world defensive and elemental expansion.)
- **DS 3+** - Blitz, X-Fire, Steal (Opens stronger utility and elemental coverage.)
- **DS 4+** - X-Ice, StonSkin, X-Thunder, Gaze (Midgame resist and status package.)
- **DS 5+** - Surprise, StonGaze, O-Stone (Higher-DS control and protection skills.)
- **DS 6+** - Explode, Heal (Adds strong burst and support options.)
- **DS 7+** - Charm, O-Weapon, Hypnos (Late-midgame control and physical resistance.)
- **DS 8+** - Teleport, Touch, O-Damage (High-tier mobility and broad damage resistance.)
- **DS 9+** - P-Blast, O-Change, Mirror (Strong late-game utility and all-element resistance.)
- **DS A+** - Recover, Flare, O-All (Top-tier endgame mutant skills.)
