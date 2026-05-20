# Final Fantasy Legend 1 - Initial LLM-Friendly Guide

**Version**: 0.2

**Sources**: Compiled from the initial FFL1 parser sources: 21924_Monster_Inventory_FAQ.txt, 31005_Guide_and_Walkthrough.txt, 5829_Guide_and_Walkthrough.txt, 8347_Human_FAQ.txt, 8348_Mutant_FAQ.txt, and 16731_Meat_Transformations_FAQ.txt.

**Notes**: This parser-generated FFL1 reference now includes battle rules, progression notes, and stat-growth guidance alongside the structured entity and chronology data. Story links remain mention-based and are meant to be extended as more FFL1 guides are added.

## Sections

- Battle Calculations and Combat Rules
- Character Progression
- Stat and Ability Enhancement
- Game-Specific System Notes
- Story Chronology
- Characters
- Equipment
- Items
- Spells and Books
- Abilities
- Status Effects
- Monsters

## Battle Calculations and Combat Rules

- **Core stats**: Strength drives most physical damage, Agility controls dodge, turn order, and light-weapon accuracy, Defense reduces incoming physical damage, and Mana improves mutant abilities and spellbook power.
  Sources: 5829_Guide_and_Walkthrough.txt
- **Weapon proficiency**: Weapons take a few uses before a character becomes proficient. Humans and males are described as better fits for strength-based weapons, while mutants and females do better with agility-based weapons.
  Sources: 5829_Guide_and_Walkthrough.txt
- **Working damage theory**: The monster inventory FAQ proposes a working formula of roughly Damage = (Attack x 10) + user stat - target defense + a small random factor. The same theory is suggested for strength-, agility-, and mana-based attacks, but bows and guns remain partially unresolved.
  Sources: 21924_Monster_Inventory_FAQ.txt
- **Ranged and special weapons**: The FAQ maps guns to base attack bytes such as Colt = 40 and Musket = 130, but notes that support-byte behavior is still unclear. Xcalibur, Glass Sword, and Masamune also appear to use special command bytes instead of the normal weapon logic.
  Sources: 21924_Monster_Inventory_FAQ.txt

## Character Progression

- **Humans**: Humans do not grow through battles. They improve by buying potions: Strong and Agility raise their stats, while HP200 through HP800 raise permanent HP until the listed threshold is exceeded, after which the same potion only gives +1 HP.
  Sources: 5829_Guide_and_Walkthrough.txt; 8347_Human_FAQ.txt
- **Human stat scaling**: The Human FAQ states that Strength and Agility potions raise their stats by 2 each use. Displayed values cap at 99, but the guide notes that Strength and Agility can continue up to 255 and wrap back to 1 if pushed past that point.
  Sources: 8347_Human_FAQ.txt
- **Mutants**: Mutants grow through battle actions instead of shops. Heavy weapons tend to raise Strength, light weapons and firearms tend to raise Agility, spellbooks and mutant abilities tend to raise Mana, and simply surviving battles may raise HP.
  Sources: 5829_Guide_and_Walkthrough.txt; 8348_Mutant_FAQ.txt
- **Mutant ability churn**: Mutants reserve four slots for natural abilities. One slot may change after battle, so strong abilities are safer when kept near the top of the ability list and the lowest slot is treated as expendable.
  Sources: 5829_Guide_and_Walkthrough.txt; 8348_Mutant_FAQ.txt
- **Monsters**: Monsters progress by eating meat. Strong meat, especially boss meat, can jump them forward into stronger forms, while weak meat can regress them into weaker species.
  Sources: 5829_Guide_and_Walkthrough.txt

## Stat and Ability Enhancement

- **Human potion values**: Strong Potion costs 300 GP for +2 Strength, Agility Potion costs 300 GP for +2 Agility, HP200 costs 100 GP, HP400 costs 1000 GP, and HP600 costs 10000 GP. The Human FAQ recommends repeatedly buying HP200 once HP thresholds are passed because it remains the most efficient option.
  Sources: 8347_Human_FAQ.txt
- **Mutant specialization**: The Mutant FAQ recommends building Agility early so psi weapons can land reliably, then leaning into Mana-heavy growth with magic and psi weapons later. Defense gains are described as rare and especially valuable when they happen.
  Sources: 8348_Mutant_FAQ.txt
- **Endgame weapon focus**: The Human FAQ recommends projectile weapons as a fallback against high-defense enemies, then shifting into top-end strength weapons like Glass Sword and Excalibur once Strength is well developed.
  Sources: 8347_Human_FAQ.txt

## Game-Specific System Notes

- **Consumable equipment economy**: Most weapons and items have finite uses, while mutant natural abilities recharge at inns instead of disappearing permanently. This makes long-term resource planning part of party construction.
  Sources: 5829_Guide_and_Walkthrough.txt
- **Hearts and death**: Characters track a heart stock separate from HP. A dead party member can be revived while hearts remain, but once hearts are exhausted that character is effectively gone and must be replaced.
  Sources: 5829_Guide_and_Walkthrough.txt
- **Trash Can bug**: The walkthrough documents a late-game Trash Can exploit that can be used repeatedly for human stat growth, although the exact trigger behavior is described as inconsistent.
  Sources: 5829_Guide_and_Walkthrough.txt

## Story Chronology

### 1. Starting out

- **Context**: World 1, Floor 1
- **Section**: 3.01
- **Summary**: Upon starting up a new game, you will first be presented with the story: It has been said that the tower in the center of the World is connected to Paradise. Dreaming of a life in Paradise, many have challenged the secret of the
- **Characters**: Clipper; Redbull; Wererat; Zombie
- **Monsters**: Clipper; Gen-Bu; Redbull; Wererat; Zombie
- **Items**: Agility; Antidote; Eyedrop; Heart; Hp200; Potion; Revive; Strong; X-Potion
- **Equipment**: Rapier

### 2. Town of Hero

- **Section**: 3.02
- **Summary**: Now you'll find yourself outside on the world map. Here, as you walk around you'll randomly encounter enemies. So, be careful of battles and keep your eye on your health. From here, walk to the east and then north to find a bridge across the water. Then, walk south, around the mountains, and east and south. Then, enter the Town of Hero. Walk north and across the bridge, and you'll see the statue that was mentioned ea...
- **Items**: Agility; Heart; Hp200; Potion; Shocker; Strong; X-Potion
- **Equipment**: Hammer; Rapier

### 3. Castle of Sword

- **Section**: 3.03
- **Summary**: From the town of Hero, head to the west, along the edge of the mountains, until you come to a path of trees through the mountains. Go through the path, down, across a bridge, along the path and to another bridge, up through a grassy area, to the Castle of Sword. In here, you'll want to avoid talking to anyone you come across, since they're all enemies that will attack you. From the entrance, take the path on the left...

### 4. Castle of Armor

- **Section**: 3.04
- **Summary**: From the town of Hero, head northeast, through the forest, around the mountains on the top, then back to the west, up and across the bridge over the river. Go east, to the Castle of Armor. Inside of the castle are some people walking around, who tell you that the king wants to speak to you on the second floor. So, go up, through the castle, across the bridge, and up the stairs to the second floor. Follow the path aro...
- **Items**: Agility; Eyedrop; Heart; Hp200; Needle; Potion; Revive; Strong; Symbol; X-Potion
- **Equipment**: Hammer; Rapier

### 5. Castle of Shield

- **Section**: 3.05
- **Summary**: The Castle of Shield is directly to the right of the town of Hero, in the forest. If you'd came here before doing the other two castles, you would've noticed that all the guards told you to go away, and that the king and his steward weren't willing at all to give up the Shield. Go to the left and up the stairs. Walk forward, and then you'll automatically walk forward to the king's throne, where he is lying dead with...
- **Monsters**: Steward
- **Equipment**: Battle

### 6. Town of Hero/Base Town

- **Section**: 3.06
- **Summary**: If you want to, you can spend some time killing enemies with your new weapon and armor, since when you decide to move on to the next step you'll be losing them all. Now, go to the town of Hero, and unequip all of the King items (and make sure you equip other items in their place of course). Now, go to the statue in the middle of the town, stand in front of it, and select the King items from your inventory menu. As yo...
- **Monsters**: Gen-Bu

### 7. Up the Tower

- **Context**: World 1 to 2
- **Section**: 3.07
- **Summary**: You're now inside of the tower, on the 1st floor (your floor position is listed in your pause menu). Continue up the stairs and through the next door, and the 2nd floor. Walk south, and then turn west and follow the path to another door. Go up the stairs, to floor 3. Go west, and you'll see a door and some stairs up. Inside of the door, if you want to go exploring, is a small world. There's a little spot of water in...

### 8. Port Town

- **Context**: World 2, Floor 5
- **Section**: 3.08
- **Summary**: Walk east from the tower, and in the south part of the island you'll find a town. Explore the town, talk to the people, and gather information. Here, you'll find out where to go next and what you need to do to move on, as well as other useful things. Across the top of the town is the inn, a house of life, and a guild. There will be guilds you'll come across from time to time, like the one you initially created your p...
- **Items**: Agility; Eyedrop; Heart; Hp200; Hp400; Needle; Potion; Strong; X-Potion
- **Equipment**: Battle

### 9. Caves

- **Section**: 3.09
- **Summary**: From the town, walk north to find a cave entrance. Inside, head off the stairs and west. Go north to the end of the path, and then east to an intersection. At the intersection, go north to the end of the path. Go east, past the first door, to another door. Go through the door and you'll come out on land. Go to the cave on the other side of the island to enter the caves again. Here, go down the stairs and then go west...

### 10. East Island Village

- **Section**: 3.10
- **Summary**: Well, now you have the entire ocean to explore as you wish. Your first stop should probably be a village to do some item buying and such. So, go north until you come to the end of the ocean (nothing interesting there, just a wavy wall which won't let you go further). From there, go east until you come to a big island. Go to the edge and press A to get off of your floating island. On the bottom of the island is the to...
- **Equipment**: Battle; Karate; Katana; Saber; X-Kick
- **Spells**: Tempter

### 11. South Island

- **Section**: 3.11
- **Summary**: You don't really need to do this step if you don't want to, it will just give you some information that you could find out by just skipping to the next step of this walkthrough. If you want to find it out on your own follow this step. If not, just skip over to the next section. Well, that old man the guy in the previous town told you not to see, you'll be going to see him now. From the East Island Village, get back o...
- **Items**: Airseed

### 12. Airseed/Underwater Town

- **Section**: 3.12
- **Summary**: Head south, down to the very south end of the map, to an island with a number of palm trees on it. Stand next to (not on, just next to) the palm tree in the middle, and, facing it, press A. You'll get the Airseed. (You can actually keep doing that to get more, but, you only need one). Now, head back to the north, past the South Island, back up to the East Island. From the bottom of the island, head west. Eventually,...
- **Items**: Airseed
- **Equipment**: Coral; Katana; Saber

### 13. Caves/Sea Palace

- **Section**: 3.13
- **Summary**: From the town, head south to find a stairway. Go onto it to enter the caves. Go east (ignoring the path to the south of the entrance), to another path leading south. Follow this path around to come to some stairs. Then, walk east to find a number of paths leading north. Take the fourth path from the right, to a stairway leading up to the ground. From there, head south and you'll come to the Sea Palace. All of the cre...
- **Monsters**: Atomcrab; Sei-Ryu
- **Items**: Bluekey; Red Orb
- **Equipment**: Battle; Grenade

### 14. South Island/Tower

- **Section**: 3.14
- **Summary**: Head East until you come to the East Island, and then go south to the South Island. Follow the directions from Section 3.11 to get to the old man if you need help. Once you get there, he'll ask you a riddle. He'll give you some items, and ask what item you could buy for the price of the items he listed. The riddle is random, but the answer will be either a Battle(Sword), Rock or Needle. Go back to the East Island Vil...
- **Items**: Blueorb; Needle; Red Orb
- **Equipment**: Battle
- **Abilities**: Riddle

### 15. Up the Tower

- **Context**: World 2 to 3
- **Section**: 3.15
- **Summary**: Head up the stairs, to floor 6. Go east, south, then west to a door. Go up the stairs, to floor 7. Again, this sidepath isn't necessary, but it's fun. From the door, take either of the paths leading north, and you'll come to a door. Go in and you'll be on an island in the middle of the water, but, you can walk in the water. Go north, through the water, to some grass, and a row of fish statues. Stand on any of the sta...
- **Items**: X-Potion
- **Equipment**: P-Knife

### 16. Sky Town

- **Context**: World 3, Floor 10
- **Section**: 3.16
- **Summary**: When you exit the tower, you'll find yourself on a cloud surrounded by sky. Go west from the tower, and enter Sky Town. Here, as usual, heal if you need to, talk to people (there's one thing inparticular to do that I'll get to in a moment), and stop by the shops. The item shop sells: The weapon shop sells: Once you're done with anything you need to do, go to the back of the town, and enter the Pub. Go inside and talk...
- **Monsters**: Byak-Ko
- **Items**: Agility; Eyedrop; Heart; Hp400; Needle; Potion; Strong; X-Potion
- **Equipment**: E-Whip; Grenade; Katana; Musket; Saber

### 17. Hidden Town

- **Section**: 3.17
- **Summary**: From where you exit the castle, fly east until you see the tower you entered this world from. Then, fly north until you see a small island, 4 spaces big, of clouds. Fly into the bottom left square to enter a secret town. Disembark from your ship to explore the town. Go around talking to the people to get more information, and rest or use the house of life if you need to. The item shop here sells: The weapon shop sell...
- **Monsters**: Giant
- **Equipment**: Bazooka; Giant; L-Saber; Longbow; P-Knife; Saber; Vampic
- **Spells**: Flare
- **Abilities**: Flare

### 18. Resistance Base

- **Section**: 3.18
- **Summary**: From the hidden town, fly west until you see land. From there, fly south, around the trees, and a bit to the east you'll see a town in the trees. Press A to get out of your craft, and enter the base. Walk over to the bottom right corner of the room to see three monsters cornering a girl. Go over and talk to one of them. They're Byak-Ko's workers (as you supposedly are as well), and they'll tell you that they have the...
- **Monsters**: Byak-Ko

### 19. Flying Castle

- **Section**: 3.19
- **Summary**: Exit the base and get back in your craft. Go south, to the Flying Castle. Get out of your craft and walk to the castle to enter it. From the entrance, walk north up the ladder. Go east, and up the three stairways, to a door. Go into the door, down the stairs, and east across the platform, to another door. From there, go down the two stairways, to another door. Walk down and to the east, up the stairs, to another door...
- **Monsters**: Byak-Ko
- **Items**: Whitkey

### 20. Jail

- **Section**: 3.20
- **Summary**: Talk to the other people inside of your jail cell, and they'll tell you that they couldn't find a way out. Go over to the jail bars and press A, and you'll bend the bars and break your way out. Walk to the east, and in the second cell over from yours you'll see a sword sitting in front of the bars. Press A in front of it, and the sword will ask you to take it, which you do, so you get the sword Revenge. Continue alon...
- **Monsters**: Giant; Guard
- **Items**: Jailkey; Revive; X-Potion
- **Equipment**: Giant; L-Saber; Revenge; Saber

### 21. Resistance Base/Flying Castle/Tower

- **Section**: 3.21
- **Summary**: Fly north and a bit east, to the Resistance Base. You'll notice the Flying Castle right next to it. Get out of your craft and enter the Resistance Base. You'll find that Jeanne has been taken. Then, exit the Resistance Base and go enter the Flying Castle. After you enter, exit back out again. You'll notice that the castle has moved. Enter it again and you'll automatically walk forward, where you'll see a scene involv...
- **Monsters**: Byak-Ko
- **Equipment**: Battle

### 22. Up the Tower

- **Context**: World 3 to 4
- **Section**: 3.22
- **Summary**: Head up the stairs, through the door, to floor 11. In the northwest part of the room is a pool to heal you. From there, walk south, east, and down the stairs. At the split go west, and then north up some more stairs, to a door. Go through the door to some more stairs. Go up, through the door, to floor 12. Go east, to a split in the path, and south down the stairs. Not necessary, but, if you want to do some more explo...
- **Items**: Potion; Revive; X-Potion
- **Equipment**: P-Sword; Vampic

### 23. Tunnels

- **Context**: World 4, Floor 16
- **Section**: 3.23
- **Summary**: In this world, if you walk around aboveground, you'll come across Su-Zaku. You can't kill him right now, your only choice is to run away. From the tower, go to the building just to the northwest, leading underground. Go south, and at the bottom of the stairs a girl will tell you to follow her and run off to the west. Go west, and at the end of the path south down the stairs. Go west, to the end of the path, where the...
- **Monsters**: Su-Zaku
- **Equipment**: Battle

### 24. Southwest Town

- **Section**: 3.24
- **Summary**: The building on the left when you enter the town is the inn. The building straight ahead has the guild on the bottom floor, and an item shop and weapon shop on the top floor. The weapon shop sells: The item shop sells: Once you're done shopping, go to the northeast side of town. You'll see a building with a bike out front. Go inside the building and you'll automatically walk over and talk to a person at the back. Aft...
- **Monsters**: Su-Zaku
- **Items**: Agility; Eyedrop; Heart; Hp400; Hp600; Needle; Shocker; Strong; X-Potion
- **Equipment**: Balkan; Catcraw; P-Sword
- **Spells**: Staff

### 25. Library

- **Section**: 3.25
- **Summary**: Go into the tunnel to the northeast of the town. Go west and north along the path to come to some tracks. Go east on the tracks, and then north at the split and up the stairs, back above ground. Go to the tunnel to the southeast, back underground. Go east along the tracks and south down any of the paths. Continue east along the tracks, and then north up the stairs. Go east, press A to get off your bike, and enter the...

### 26. Akiba/Northeast Town

- **Section**: 3.26
- **Summary**: From the spot where the library is, go 14 spaces east and 15 spaces north. When you move on top of it, you'll automatically enter Akiba. Here, there are four buildings with treasure chests. The one you need to get is in the bottom right building, the ROM. The bottom left building has a Revive, the top right building has a Catcraw, and the top left building has an XPotion. After leaving Akiba, go north and you'll see...
- **Items**: Agility; Antidote; Eyedrop; Heart; Hp200; Hp400; Hp600; Needle; Revive; Shocker; Strong; Symbol; X-Potion
- **Equipment**: Catcraw; Hyper; P-Sword; X-Kick

### 27. Southwest Town/Tunnel

- **Section**: 3.27
- **Summary**: After finishing up in Northeast Town, make your way back to Southwest Town (to the southwest, needless to say). Go to the pub, and talk to So-Cho, who will tell you his plan, and you'll go to bed. The next day, get up and leave thr room. You'll try to leave the town by yourself, but will be stopped. After finishing that, you'll be outside the town. Go east, into the tunnel. Follow the other bike to the east, to meet...

### 28. Power Plant

- **Section**: 3.28
- **Summary**: If you walk or ride off the edge here, you'll return to the entrance. Go north, and around the path to the west, to some stairs, and up. Take the path to the north until you come to a person blocking your path. Get off your bike and talk to it to enter a battle. After winning, get back on your bike and continue along the path, to the stairs. Go along the path to the north and east, and continue south. When you get to...
- **Items**: Erase99
- **Equipment**: Battle
- **Abilities**: Poison
- **Status Effects**: Poison

### 29. Skyscraper/Tower

- **Section**: 3.29
- **Summary**: On your way to the Skyscraper, outside you'll now run into actual enemies instead of Su-Zaku. Also, the underground tunnel system doesn't work anymore. Go straight north from the town, and on the west you'll see a meteor field. Go over to it, get off your bike, and walk into the middle to find the Skyscraper. Go north, and at the path split go west, north, and east to a door. Go inside, and then step east to be broug...
- **Monsters**: Su-Zaku
- **Items**: Erase99; X-Potion
- **Equipment**: Battle; Hyper

### 30. Up the Tower

- **Context**: World 4 to Top
- **Section**: 3.30
- **Summary**: Go east, south and west. Walk over the spikes to the door. Use the Red Sphere, and enter the tower. Walk up the steps, to floor 17. Go east, past the first stairs, to the second stairs, and then north up them. Continue up the stairs, to a door, and in. Walk up the steps, through the door, to floor 18. Go east and south, to a door. If you continue west to another door, you'll find some people inside you can talk to. O...
- **Equipment**: Magnum

## Characters

- **Clipper** (Monster Archetype) - Monster starting option available during character creation; long-term growth is tied to the monster transformation system.
- **Human (F)** (Playable Archetype) - Humans improve through purchased stat items and can equip the widest range of gear.
- **Human (M)** (Playable Archetype) - Humans improve through purchased stat items and can equip the widest range of gear.
- **Mutant (F)** (Playable Archetype) - Mutants improve through battle and specialize in magic and natural abilities.
- **Mutant (M)** (Playable Archetype) - Mutants improve through battle and specialize in magic and natural abilities.
- **Redbull** (Monster Archetype) - Monster starting option available during character creation; long-term growth is tied to the monster transformation system.
- **Wererat** (Monster Archetype) - Monster starting option available during character creation; long-term growth is tied to the monster transformation system.
- **Zombie** (Monster Archetype) - Monster starting option available during character creation; long-term growth is tied to the monster transformation system.

## Equipment

- **Arthur** [Armor] - Uses: -; Effect: Defense 38; Extra: None; Notes: Resists: Stone; Para
- **Bronze** [Armor] - Uses: -; Effect: Defense 4; Extra: None; Notes: None
- **Dragon** [Armor] - Uses: -; Effect: Defense 19; Extra: None; Notes: Resists: Fire; Ice; Elem; Poison
- **Gold** [Armor] - Uses: -; Effect: Defense 8; Extra: None; Notes: None
- **King** [Armor] - Uses: -; Effect: Defense 20; Extra: None; Notes: Resists: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Quake
- **Power** [Armor] - Uses: -; Effect: Defense 70   +Str +Agi +Man; Extra: None; Notes: None
- **Silver** [Armor] - Uses: -; Effect: Defense 13; Extra: None; Notes: None
- **Suit** [Armor] - Uses: -; Effect: Defense 25; Extra: None; Notes: Resists: Weapon
- **Bow** [Bow] - Uses: 50; Effect: Bow-Dam 20; Extra: None; Notes: None
- **Great Bow** [Bow] - Uses: 50; Effect: Bow-Dam 250; Extra: None; Notes: None
- **Longbow** [Bow] - Uses: 50; Effect: Bow-Dam 120; Extra: None; Notes: None
- **Bronze** [Gauntlet] - Uses: -; Effect: Defense 1; Extra: None; Notes: None
- **Giant** [Gauntlet] - Uses: -; Effect: Defense 6   +Str; Extra: None; Notes: None
- **Gold** [Gauntlet] - Uses: -; Effect: Defense 3; Extra: None; Notes: None
- **Ninja** [Gauntlet] - Uses: -; Effect: Defense 15        +Agi; Extra: None; Notes: None
- **Silver** [Gauntlet] - Uses: -; Effect: Defense 4; Extra: None; Notes: None
- **Army** [Helmet] - Uses: -; Effect: Defense 17; Extra: None; Notes: None
- **Band** [Helmet] - Uses: -; Effect: Defense 25; Extra: None; Notes: Resists: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Quake
- **Bronze** [Helmet] - Uses: -; Effect: Defense 3; Extra: None; Notes: None
- **Dragon** [Helmet] - Uses: -; Effect: Defense 22; Extra: None; Notes: Resists: Stone; Para; Weapon; Quake
- **Gold** [Helmet] - Uses: -; Effect: Defense 5; Extra: None; Notes: None
- **Silver** [Helmet] - Uses: -; Effect: Defense 8; Extra: None; Notes: None
- **Butt** [Martial Weapon] - Uses: 66; Effect: None; Extra: Martial 7; Notes: None
- **Counter** [Martial Weapon] - Uses: 20; Effect: None; Extra: None; Notes: None
- **Judo** [Martial Weapon] - Uses: 22; Effect: None; Extra: Martial 9; Notes: None
- **Karate** [Martial Weapon] - Uses: 11; Effect: None; Extra: Martial 10; Notes: None
- **Kick** [Martial Weapon] - Uses: 20; Effect: Str-Atk 4; Extra: None; Notes: None
- **Kick** [Martial Weapon] - Uses: 88; Effect: None; Extra: Martial 6; Notes: None
- **Punch** [Martial Weapon] - Uses: 25; Effect: Str-Atk 3; Extra: None; Notes: None
- **Punch** [Martial Weapon] - Uses: 99; Effect: None; Extra: Martial 5; Notes: None
- **X-Kick** [Martial Weapon] - Uses: 44; Effect: None; Extra: Martial 8; Notes: None
- **Balkan** [Ranged Weapon] - Uses: 20; Effect: Gun-Dam 200; Extra: None; Notes: None
- **Bazooka** [Ranged Weapon] - Uses: 20; Effect: Gun-Dam 150; Extra: None; Notes: None
- **Colt** [Ranged Weapon] - Uses: 30; Effect: Gun-Dam 40; Extra: None; Notes: None
- **Grenade** [Ranged Weapon] - Uses: 20; Effect: Gun-Dam 100; Extra: None; Notes: None
- **Hyper** [Ranged Weapon] - Uses: 3; Effect: None; Extra: None; Notes: None
- **Laser** [Ranged Weapon] - Uses: 30; Effect: None; Extra: None; Notes: None
- **Magnum** [Ranged Weapon] - Uses: 30; Effect: Gun-Dam 250; Extra: None; Notes: None
- **Missile** [Ranged Weapon] - Uses: 5; Effect: None; Extra: None; Notes: None
- **Musket** [Ranged Weapon] - Uses: 30; Effect: Gun-Dam 130; Extra: None; Notes: None
- **Rock** [Ranged Weapon] - Uses: 16; Effect: Gun-Dam 100; Extra: None; Notes: None
- **Smg** [Ranged Weapon] - Uses: 20; Effect: Gun-Dam 50; Extra: None; Notes: None
- **Aezis** [Shield] - Uses: 50; Effect: Prot 100%; Extra: None; Notes: None
- **Bronze** [Shield] - Uses: 50; Effect: Prot 30%; Extra: None; Notes: None
- **Dragon** [Shield] - Uses: 50; Effect: Prot 80%; Extra: None; Notes: None
- **Flame** [Shield] - Uses: 50; Effect: Prot 60%; Extra: None; Notes: None
- **Gold** [Shield] - Uses: 50; Effect: Prot 40%; Extra: None; Notes: None
- **Ice** [Shield] - Uses: 50; Effect: Prot 60%; Extra: None; Notes: None
- **King** [Shield] - Uses: -; Effect: Prot 255%; Extra: None; Notes: None
- **Silver** [Shield] - Uses: 50; Effect: Prot 50%; Extra: None; Notes: None
- **Geta** [Shoes] - Uses: -; Effect: Defense 7   +Str; Extra: None; Notes: None
- **Hermes** [Shoes] - Uses: -; Effect: Defense 7        +Agi; Extra: None; Notes: None
- **Shoes** [Shoes] - Uses: -; Effect: Defense 10             +Man; Extra: None; Notes: None
- **Axe** [Weapon] - Uses: 10; Effect: Str-Atk 7; Extra: None; Notes: None
- **Axe** [Weapon] - Uses: 50; Effect: Str-Atk 4; Extra: None; Notes: None
- **Battle** [Weapon] - Uses: 50; Effect: Str-Atk 5; Extra: None; Notes: None
- **Catcraw** [Weapon] - Uses: 50; Effect: Agi-Atk 11; Extra: None; Notes: None
- **Coral** [Weapon] - Uses: 50; Effect: Str-Atk 8; Extra: Crit Water; Notes: None
- **Defend** [Weapon] - Uses: 50; Effect: Str-Atk 12; Extra: None; Notes: None
- **Dragon** [Weapon] - Uses: 50; Effect: Str-Atk 11; Extra: Crit Lizard; Notes: None
- **Elec** [Weapon] - Uses: 50; Effect: Str-Atk 10; Extra: None; Notes: Element: Elem
- **Flame** [Weapon] - Uses: 50; Effect: Str-Atk 10; Extra: None; Notes: Element: Fire
- **Glass** [Weapon] - Uses: 50; Effect: None; Extra: None; Notes: None
- **Hammer** [Weapon] - Uses: 50; Effect: Str-Atk 2; Extra: None; Notes: None
- **Ice** [Weapon] - Uses: 50; Effect: Str-Atk 10; Extra: None; Notes: Element: Ice
- **Katana** [Weapon] - Uses: 50; Effect: Str-Atk 6; Extra: None; Notes: None
- **King** [Weapon] - Uses: -; Effect: Str-Atk 8; Extra: None; Notes: Element: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Quake
- **L-Saber** [Weapon] - Uses: 50; Effect: Agi-Atk 9; Extra: None; Notes: None
- **Long** [Weapon] - Uses: 50; Effect: Str-Atk 3; Extra: None; Notes: None
- **Masmune** [Weapon] - Uses: 50; Effect: None; Extra: None; Notes: None
- **Ogre** [Weapon] - Uses: 50; Effect: Str-Atk 8; Extra: Crit Humanoid; Notes: None
- **P-Knife** [Weapon] - Uses: 50; Effect: Man-Atk 7; Extra: None; Notes: None
- **P-Sword** [Weapon] - Uses: 50; Effect: Man-Atk 12; Extra: None; Notes: None
- **Rapier** [Weapon] - Uses: 50; Effect: Agi-Atk 2; Extra: None; Notes: None
- **Revenge** [Weapon] - Uses: 50; Effect: None; Extra: None; Notes: None
- **Rune** [Weapon] - Uses: 50; Effect: Str-Atk 7   Mirror; Extra: None; Notes: None
- **Saber** [Weapon] - Uses: 50; Effect: Agi-Atk 6; Extra: None; Notes: None
- **Saw** [Weapon] - Uses: 20; Effect: None; Extra: None; Notes: None
- **Saw** [Weapon] - Uses: 30; Effect: None; Extra: None; Notes: None
- **Silver** [Weapon] - Uses: 50; Effect: Str-Atk 9; Extra: None; Notes: None
- **Sun** [Weapon] - Uses: 50; Effect: Str-Atk 13; Extra: Crit Undead; Notes: None
- **Vampic** [Weapon] - Uses: 50; Effect: Drain-Atk 4   Dont! Undead; Extra: None; Notes: None
- **Xcalibur** [Weapon] - Uses: 50; Effect: None; Extra: None; Notes: None
- **E-Whip** [Whip] - Uses: 50; Effect: Whp-Dam 70; Extra: None; Notes: None
- **Whip** [Whip] - Uses: 50; Effect: Whp-Dam 15; Extra: None; Notes: None

## Items

- **Agility** - Uses: 1; Effect: None; Extra: None
- **Airseed** - Uses: -; Effect: None; Extra: None
- **Antidote** - Uses: 3; Effect: Cures Poison; Extra: None
- **Arcane** - Uses: 1; Effect: None; Extra: None
- **Bell** - Uses: 3; Effect: Cures Sleep; Extra: None
- **Bluekey** - Uses: -; Effect: None; Extra: None
- **Blueorb** - Uses: -; Effect: None; Extra: None
- **Board** - Uses: -; Effect: None; Extra: None
- **Care** - Uses: 5; Effect: Cures Many; Extra: None
- **Cure** - Uses: 10; Effect: Man-Pwr 4; Extra: None
- **Door** - Uses: 3; Effect: None; Extra: None
- **Elixir** - Uses: 3; Effect: None; Extra: None
- **Erase99** - Uses: -; Effect: None; Extra: None
- **Eyedrop** - Uses: 3; Effect: Cures Blind; Extra: None
- **Heal** - Uses: 10; Effect: Man-Pwr 4; Extra: None
- **Heart** - Uses: 1; Effect: None; Extra: None
- **Honey** - Uses: 10; Effect: Heal 30; Extra: None
- **Hp200** - Uses: 1; Effect: None; Extra: None
- **Hp400** - Uses: 1; Effect: None; Extra: None
- **Hp600** - Uses: 1; Effect: None; Extra: None
- **Jailkey** - Uses: -; Effect: None; Extra: None
- **Left** - Uses: -; Effect: None; Extra: None
- **Needle** - Uses: 3; Effect: Cures Stone; Extra: None
- **Pan** - Uses: 3; Effect: Cures Confusion; Extra: None
- **Potion** - Uses: 3; Effect: Heal 30; Extra: None
- **Raise** - Uses: 3; Effect: None; Extra: None
- **Red Orb** - Uses: -; Effect: None; Extra: None
- **Revive** - Uses: 1; Effect: None; Extra: None
- **Revive** - Uses: 3; Effect: None; Extra: None
- **Right** - Uses: -; Effect: Man-Pwr 6; Extra: None
- **Rom** - Uses: -; Effect: None; Extra: None
- **Shocker** - Uses: 3; Effect: Cures Paralysis; Extra: None
- **Strong** - Uses: 1; Effect: None; Extra: None
- **Symbol** - Uses: 3; Effect: Cures Curse; Extra: None
- **Telepor** - Uses: 5; Effect: None; Extra: None
- **Whitkey** - Uses: -; Effect: None; Extra: None
- **X-Potion** - Uses: 3; Effect: Heal 90; Extra: None

## Spells and Books

- **Book** - Uses: 20; Effect: Man-Pwr 10; Extra: Hurt Undead; Notes: None
- **Cure** - Uses: 30; Effect: Man-Pwr 4; Extra: None; Notes: None
- **Death** - Uses: 20; Effect: Inflicts Death; Extra: None; Notes: Element: Para
- **Elec** - Uses: 20; Effect: Man-Pwr 6; Extra: None; Notes: Element: Elem
- **Fire** - Uses: 20; Effect: Man-Pwr 6; Extra: None; Notes: Element: Fire
- **Flare** - Uses: 20; Effect: Man-Pwr 10; Extra: None; Notes: None
- **Fog** - Uses: 20; Effect: Man-Pwr 6; Extra: None; Notes: Element: Poison
- **Ice** - Uses: 20; Effect: Man-Pwr 6; Extra: None; Notes: Element: Ice
- **Rod** - Uses: 30; Effect: Man-Pwr 5; Extra: None; Notes: None
- **Sleep** - Uses: 20; Effect: Inflicts Sleep; Extra: None; Notes: Element: Para
- **Staff** - Uses: 20; Effect: Inflicts Confusion; Extra: None; Notes: Element: Para
- **Stone** - Uses: 20; Effect: Inflicts Stone; Extra: None; Notes: Element: Stone
- **Tempter** - Uses: 30; Effect: Inflicts Confusion; Extra: None; Notes: Element: Para
- **Wand** - Uses: 30; Effect: Man-Pwr 7; Extra: None; Notes: Element: Fire

## Abilities

- **2Pincer** - Uses: 10; Effect: #Atk 2; Extra: None; Notes: None
- **2Swords** - Uses: 10; Effect: #Atk 2; Extra: None; Notes: None
- **2Tusks** - Uses: 10; Effect: #Atk 2; Extra: None; Notes: None
- **3Heads** - Uses: 10; Effect: #Atk 3; Extra: None; Notes: None
- **4Heads** - Uses: 5; Effect: #Atk 4; Extra: None; Notes: None
- **4Horns** - Uses: 10; Effect: #Atk 3; Extra: None; Notes: None
- **6Arms** - Uses: 5; Effect: #Atk 6; Extra: None; Notes: None
- **8Legs** - Uses: 5; Effect: #Atk 8; Extra: None; Notes: None
- **Acid** - Uses: 3; Effect: Man-Pwr 4; Extra: None; Notes: Element: Poison
- **Acid** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: None
- **Armor** - Uses: 3; Effect: None; Extra: Add-Def 99; Notes: None
- **Barrier** - Uses: 5; Effect: None; Extra: None; Notes: None
- **Bash** - Uses: 3; Effect: Str-Atk 9; Extra: None; Notes: None
- **Beak** - Uses: 25; Effect: Agi-Atk 4; Extra: None; Notes: None
- **Beam** - Uses: 10; Effect: None; Extra: None; Notes: None
- **Bite** - Uses: 20; Effect: Str-Atk 4; Extra: None; Notes: None
- **Blind** - Uses: 10; Effect: Inflicts Blind; Extra: None; Notes: Element: Para
- **Bone** - Uses: 25; Effect: Str-Atk 3; Extra: None; Notes: None
- **Bother** - Uses: 10; Effect: None; Extra: Reduce Agi?; Notes: None
- **Burning** - Uses: 25; Effect: Element Fire; Extra: None; Notes: Element: Fire
- **Chill** - Uses: 10; Effect: Str-Atk 8; Extra: None; Notes: Element: Ice
- **D-Beam** - Uses: 10; Effect: None; Extra: None; Notes: None
- **D-Fangs** - Uses: 5; Effect: Inflicts Death; Extra: None; Notes: Element: Para
- **Drain** - Uses: 10; Effect: None; Extra: Reduce Str?; Notes: None
- **Drink** - Uses: 10; Effect: None; Extra: None; Notes: None
- **Elec** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Elem
- **Electro** - Uses: 10; Effect: None; Extra: Reduce Agi?; Notes: None
- **Esp** - Uses: 25; Effect: Prot 30%; Extra: None; Notes: None
- **Explode** - Uses: 1; Effect: None; Extra: None; Notes: None
- **Fin** - Uses: 30; Effect: Str-Atk 2; Extra: None; Notes: None
- **Fire** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Fire
- **Flame** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Fire
- **Flare** - Uses: 3; Effect: Man-Pwr 8; Extra: None; Notes: None
- **Flash** - Uses: 10; Effect: Inflicts Blind; Extra: None; Notes: Element: Para
- **Forseen** - Uses: -; Effect: None; Extra: None; Notes: None
- **Gas** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Poison
- **Gaze** - Uses: 5; Effect: Inflicts Confusion; Extra: None; Notes: Element: Para
- **Gaze** - Uses: 5; Effect: Inflicts Stone; Extra: None; Notes: Element: Stone
- **Gaze** - Uses: 5; Effect: Inflicts Death; Extra: None; Notes: Element: Para
- **Gaze** - Uses: 10; Effect: Inflicts Curse; Extra: None; Notes: Element: Para
- **Gaze** - Uses: 10; Effect: Inflicts Paralysis; Extra: None; Notes: Element: Para
- **Hari-Te** - Uses: 5; Effect: Str-Atk 8; Extra: None; Notes: None
- **Head** - Uses: 5; Effect: Str-Atk 8; Extra: None; Notes: None
- **Horn** - Uses: 10; Effect: Str-Atk 7; Extra: None; Notes: None
- **Hypnos** - Uses: 21; Effect: Inflicts Confusion; Extra: None; Notes: Element: Para
- **Ice** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Ice
- **Ice** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Ice
- **Ink** - Uses: 10; Effect: Inflicts Blind; Extra: None; Notes: Element: Para
- **Kinesis** - Uses: 10; Effect: Inflicts Paralysis; Extra: None; Notes: Element: Para
- **Kiss** - Uses: 5; Effect: Drain-Atk 8   Dont! Undead; Extra: None; Notes: None
- **Leech** - Uses: 5; Effect: None; Extra: None; Notes: None
- **Light** - Uses: -; Effect: Inflicts Blind; Extra: None; Notes: None
- **Melt** - Uses: 10; Effect: None; Extra: None; Notes: None
- **Mirror** - Uses: 3; Effect: None; Extra: None; Notes: None
- **Mirror** - Uses: 10; Effect: None; Extra: None; Notes: None
- **N.Bomb** - Uses: 1; Effect: None; Extra: None; Notes: None
- **Nail** - Uses: 30; Effect: Str-Atk 2; Extra: None; Notes: None
- **Nose** - Uses: 15; Effect: Str-Atk 6; Extra: None; Notes: None
- **P-Blast** - Uses: 5; Effect: Man-Pwr 4; Extra: None; Notes: None
- **P-Fangs** - Uses: 20; Effect: Inflicts Paralysis; Extra: None; Notes: Element: Para
- **P-Skin** - Uses: 20; Effect: Inflicts Paralysis; Extra: None; Notes: Element: Para
- **P-Skin** - Uses: 25; Effect: Inflicts Poison; Extra: None; Notes: Element: Poison
- **Petrify** - Uses: 5; Effect: Inflicts Stone; Extra: None; Notes: Element: Stone
- **Pincer** - Uses: 20; Effect: Str-Atk 5; Extra: None; Notes: None
- **Poison** - Uses: 25; Effect: Inflicts Poison; Extra: None; Notes: Element: Poison
- **Poison** - Uses: 25; Effect: Inflicts Poison; Extra: None; Notes: Element: Poison
- **Pollen** - Uses: 20; Effect: Inflicts Poison; Extra: None; Notes: Element: Poison
- **Power** - Uses: 3; Effect: None; Extra: Add-Str 99; Notes: None
- **Quake** - Uses: 3; Effect: Man-Pwr 4; Extra: None; Notes: Element: Quake
- **Repent** - Uses: -; Effect: Inflicts Confusion; Extra: None; Notes: None
- **Riddle** - Uses: 3; Effect: Inflicts Confusion; Extra: None; Notes: None
- **Rocket** - Uses: 10; Effect: Gun-Dam 100; Extra: None; Notes: None
- **S-Skin** - Uses: 5; Effect: Inflicts Stone; Extra: None; Notes: Element: Stone
- **Sand** - Uses: 10; Effect: None; Extra: Reduce Agi?; Notes: None
- **Shell** - Uses: 25; Effect: Prot 40%; Extra: None; Notes: None
- **Shell** - Uses: 25; Effect: Prot 50%; Extra: None; Notes: None
- **Sing** - Uses: 3; Effect: Inflicts Confusion; Extra: None; Notes: None
- **Sl-Gaze** - Uses: 20; Effect: Inflicts Sleep; Extra: None; Notes: Element: Para
- **Sleep** - Uses: 10; Effect: Inflicts Sleep; Extra: None; Notes: Element: Para
- **Sleep** - Uses: 20; Effect: Inflicts Sleep; Extra: None; Notes: Element: Para
- **Sphere** - Uses: -; Effect: None; Extra: None; Notes: None
- **Squirt** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Ice
- **Steal** - Uses: 5; Effect: None; Extra: None; Notes: None
- **Stealth** - Uses: -; Effect: None; Extra: None; Notes: None
- **Stench** - Uses: 10; Effect: None; Extra: Reduce Str?; Notes: None
- **Stone** - Uses: 5; Effect: Inflicts Stone; Extra: None; Notes: Element: Stone
- **Stop** - Uses: 5; Effect: Inflicts Death; Extra: None; Notes: Element: Para
- **Strict** - Uses: 20; Effect: Inflicts Paralysis; Extra: None; Notes: Element: Para
- **Sword** - Uses: 15; Effect: Str-Atk 6; Extra: None; Notes: None
- **Tail** - Uses: 10; Effect: Agi-Atk 6; Extra: None; Notes: None
- **Tentacl** - Uses: 25; Effect: Agi-Atk 5; Extra: None; Notes: None
- **Thunder** - Uses: 10; Effect: Man-Pwr 4; Extra: None; Notes: Element: Elem
- **Tornado** - Uses: 3; Effect: Man-Pwr 4; Extra: None; Notes: Element: Ice
- **Touch** - Uses: 5; Effect: Drain-Atk 5   Dont! Undead; Extra: None; Notes: None
- **Tremble** - Uses: 10; Effect: None; Extra: Reduce Agi?; Notes: None
- **Tusk** - Uses: 10; Effect: Str-Atk 6; Extra: None; Notes: None
- **Uncurse** - Uses: 10; Effect: Man-Pwr 10; Extra: Hurt Undead; Notes: None
- **Warning** - Uses: -; Effect: None; Extra: None; Notes: None
- **Web** - Uses: 10; Effect: None; Extra: Reduce Agi?; Notes: None
- **Whirl** - Uses: 3; Effect: Man-Pwr 4; Extra: None; Notes: None

## Status Effects

- **Blind** - Applied by: Blind; Flash; Ink; Light; Cured by: Eyedrop; Related elements: Para
- **Confusion** - Applied by: Gaze; Hypnos; Repent; Riddle; Sing; Staff; Tempter; Cured by: Pan; Related elements: Para
- **Curse** - Applied by: Gaze; Cured by: Symbol; Related elements: Para
- **Death** - Applied by: D-Fangs; Death; Gaze; Stop; Cured by: None; Related elements: Para
- **Many** - Applied by: None; Cured by: Care; Related elements: None
- **Paralysis** - Applied by: Gaze; Kinesis; P-Fangs; P-Skin; Strict; Cured by: Shocker; Related elements: Para
- **Poison** - Applied by: P-Skin; Poison; Pollen; Cured by: Antidote; Related elements: Poison
- **Sleep** - Applied by: Sl-Gaze; Sleep; Cured by: Bell; Related elements: Para
- **Stone** - Applied by: Gaze; Petrify; S-Skin; Stone; Cured by: Needle; Related elements: Stone

## Monsters

- **Albatros** - HP: 20; STR: 6; AGL: 3; MAN: 9; DEF: 4; Gold: 40; Resistances: Quake; Weaknesses: None; Family: None
- **Ammonite** - HP: 409; STR: 51; AGL: 49; MAN: 50; DEF: 35; Gold: 1600; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Amoeba** - HP: 295; STR: 34; AGL: 32; MAN: 33; DEF: 22; Gold: 900; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Anaconda** - HP: 231; STR: 30; AGL: 39; MAN: 28; DEF: 19; Gold: 600; Resistances: None; Weaknesses: Ice; Family: Lizard
- **Ant Lion** - HP: 231; STR: 22; AGL: 45; MAN: 43; DEF: 33; Gold: 900; Resistances: None; Weaknesses: Ice; Family: None
- **Anubis** - HP: 729; STR: 99; AGL: 62; MAN: 80; DEF: 82; Gold: 2000; Resistances: None; Weaknesses: None; Family: None
- **Armor** - HP: 729; STR: 95; AGL: 94; MAN: 56; DEF: 55; Gold: 2400; Resistances: Para; Weaknesses: None; Family: None
- **Ashura** - HP: 2000; STR: 90; AGL: 90; MAN: 90; DEF: 90; Gold: 9999; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Weaknesses: None; Family: Undead
- **Asigaru** - HP: 20; STR: 5; AGL: 6; MAN: 8; DEF: 3; Gold: 40; Resistances: None; Weaknesses: None; Family: Humanoid
- **Athtalot** - HP: 729; STR: 82; AGL: 79; MAN: 80; DEF: 83; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Quake; Weaknesses: None; Family: Undead
- **Atom Ant** - HP: 295; STR: 28; AGL: 55; MAN: 53; DEF: 41; Gold: 1200; Resistances: Fire; Weaknesses: Ice; Family: None
- **Atomcrab** - HP: 150; STR: 18; AGL: 32; MAN: 12; DEF: 10; Gold: 400; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Baku** - HP: 666; STR: 88; AGL: 71; MAN: 69; DEF: 52; Gold: 2000; Resistances: None; Weaknesses: Ice; Family: None
- **Barracud** - HP: 60; STR: 9; AGL: 6; MAN: 11; DEF: 5; Gold: 120; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Basilisk** - HP: 795; STR: 81; AGL: 99; MAN: 63; DEF: 61; Gold: 2000; Resistances: Stone; Para; Weapon; Weaknesses: None; Family: Lizard
- **Beetle** - HP: 202; STR: 19; AGL: 40; MAN: 38; DEF: 29; Gold: 600; Resistances: Quake; Weaknesses: Ice; Family: None
- **Behemoth** - HP: 409; STR: 60; AGL: 47; MAN: 45; DEF: 32; Gold: 1200; Resistances: None; Weaknesses: Ice; Family: None
- **Beholder** - HP: 666; STR: 63; AGL: 81; MAN: 61; DEF: 99; Gold: 2400; Resistances: Quake; Weaknesses: None; Family: None
- **Big Eye** - HP: 82; STR: 8; AGL: 12; MAN: 6; DEF: 22; Gold: 240; Resistances: Quake; Weaknesses: None; Family: None
- **Blackcat** - HP: 606; STR: 89; AGL: 70; MAN: 87; DEF: 52; Gold: 2000; Resistances: None; Weaknesses: None; Family: None
- **Boneking** - HP: 666; STR: 75; AGL: 55; MAN: 57; DEF: 94; Gold: 2400; Resistances: Stone; Para; Weapon; Weaknesses: Fire; Family: Undead
- **Buruburu** - HP: 295; STR: 28; AGL: 27; MAN: 54; DEF: 55; Gold: 1200; Resistances: Ice; Stone; Para; Weapon; Quake; Weaknesses: Fire; Family: Undead
- **Byak-Ko** - HP: 1000; STR: 50; AGL: 45; MAN: 50; DEF: 50; Gold: 5500; Resistances: Ice; Para; Weaknesses: None; Family: None
- **Byak-Ko2** - HP: 2000; STR: 100; AGL: 90; MAN: 100; DEF: 100; Gold: 0; Resistances: Fire; Ice; Elem; Poison; Para; Weaknesses: None; Family: Undead
- **Cactus** - HP: 150; STR: 15; AGL: 16; MAN: 8; DEF: 9; Gold: 240; Resistances: None; Weaknesses: None; Family: None
- **Catwoman** - HP: 175; STR: 30; AGL: 14; MAN: 21; DEF: 23; Gold: 400; Resistances: Weapon; Weaknesses: None; Family: None
- **Chimera** - HP: 262; STR: 37; AGL: 36; MAN: 49; DEF: 50; Gold: 900; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Cicada** - HP: 551; STR: 70; AGL: 88; MAN: 89; DEF: 69; Gold: 2000; Resistances: Quake; Weaknesses: Ice; Family: None
- **Clam** - HP: 231; STR: 26; AGL: 24; MAN: 25; DEF: 16; Gold: 600; Resistances: None; Weaknesses: Elem; Family: Water
- **Clayman** - HP: 295; STR: 50; AGL: 37; MAN: 25; DEF: 48; Gold: 900; Resistances: Para; Weaknesses: Ice; Family: None
- **Clipper** - HP: 20; STR: 4; AGL: 9; MAN: 7; DEF: 6; Gold: 40; Resistances: None; Weaknesses: Ice; Family: None
- **Cocatris** - HP: 501; STR: 66; AGL: 47; MAN: 99; DEF: 64; Gold: 2000; Resistances: Quake; Weaknesses: None; Family: None
- **Condor** - HP: 82; STR: 11; AGL: 6; MAN: 14; DEF: 9; Gold: 120; Resistances: Quake; Weaknesses: None; Family: None
- **Conjurer** - HP: 150; STR: 15; AGL: 13; MAN: 30; DEF: 38; Gold: 400; Resistances: None; Weaknesses: None; Family: Humanoid
- **Crab** - HP: 295; STR: 37; AGL: 61; MAN: 26; DEF: 24; Gold: 900; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Crawler** - HP: 330; STR: 38; AGL: 25; MAN: 24; DEF: 37; Gold: 900; Resistances: None; Weaknesses: Ice; Family: None
- **Creator** - HP: 5000; STR: 99; AGL: 200; MAN: 99; DEF: 90; Gold: 0; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Quake; Weaknesses: None; Family: None
- **Dagon** - HP: 729; STR: 81; AGL: 99; MAN: 63; DEF: 61; Gold: 2000; Resistances: Fire; Poison; Stone; Weaknesses: None; Family: Water
- **Darkrose** - HP: 795; STR: 81; AGL: 82; MAN: 61; DEF: 62; Gold: 2000; Resistances: Ice; Poison; Para; Weaknesses: None; Family: None
- **Demoking** - HP: 666; STR: 76; AGL: 73; MAN: 74; DEF: 77; Gold: 2400; Resistances: Fire; Quake; Weaknesses: None; Family: Undead
- **Demolord** - HP: 501; STR: 61; AGL: 58; MAN: 59; DEF: 62; Gold: 2000; Resistances: Fire; Quake; Weaknesses: None; Family: Undead
- **Demon** - HP: 454; STR: 56; AGL: 53; MAN: 54; DEF: 57; Gold: 1600; Resistances: Fire; Quake; Weaknesses: None; Family: Undead
- **Dinosaur** - HP: 501; STR: 55; AGL: 71; MAN: 40; DEF: 38; Gold: 1600; Resistances: Weapon; Weaknesses: Ice; Family: Lizard
- **Dokuro** - HP: 368; STR: 46; AGL: 31; MAN: 33; DEF: 60; Gold: 1200; Resistances: Para; Weapon; Weaknesses: Fire; Family: Undead
- **Dragon 1** - HP: 202; STR: 30; AGL: 28; MAN: 19; DEF: 39; Gold: 600; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Dragon 2** - HP: 262; STR: 38; AGL: 36; MAN: 25; DEF: 49; Gold: 900; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Dragon 3** - HP: 368; STR: 51; AGL: 49; MAN: 35; DEF: 65; Gold: 1600; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Dragon 4** - HP: 501; STR: 66; AGL: 64; MAN: 47; DEF: 83; Gold: 2000; Resistances: Fire; Quake; Weaknesses: None; Family: Lizard
- **Dragon 5** - HP: 606; STR: 76; AGL: 74; MAN: 56; DEF: 94; Gold: 2400; Resistances: Fire; Quake; Weaknesses: None; Family: Lizard
- **Drgonfly** - HP: 82; STR: 12; AGL: 17; MAN: 18; DEF: 11; Gold: 240; Resistances: Quake; Weaknesses: Ice; Family: None
- **Eagle** - HP: 150; STR: 23; AGL: 14; MAN: 38; DEF: 21; Gold: 400; Resistances: Quake; Weaknesses: None; Family: None
- **Elec Eel** - HP: 606; STR: 71; AGL: 69; MAN: 88; DEF: 52; Gold: 2000; Resistances: Fire; Elem; Weaknesses: None; Family: Water
- **Evil Eye** - HP: 606; STR: 57; AGL: 75; MAN: 55; DEF: 99; Gold: 2400; Resistances: Quake; Weaknesses: None; Family: None
- **F-Flower** - HP: 666; STR: 70; AGL: 71; MAN: 51; DEF: 52; Gold: 2000; Resistances: Fire; Weaknesses: Ice; Family: None
- **Fenswolf** - HP: 729; STR: 99; AGL: 81; MAN: 99; DEF: 62; Gold: 2000; Resistances: Fire; Poison; Weaknesses: None; Family: None
- **Fireman** - HP: 666; STR: 95; AGL: 75; MAN: 56; DEF: 93; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Weaknesses: None; Family: None
- **Fly** - HP: 20; STR: 6; AGL: 8; MAN: 9; DEF: 5; Gold: 40; Resistances: Quake; Weaknesses: Ice; Family: None
- **Ganesha** - HP: 795; STR: 99; AGL: 82; MAN: 80; DEF: 62; Gold: 2000; Resistances: Para; Weapon; Weaknesses: None; Family: None
- **Gang** - HP: 729; STR: 88; AGL: 53; MAN: 70; DEF: 51; Gold: 2400; Resistances: None; Weaknesses: None; Family: Humanoid
- **Gargoyle** - HP: 82; STR: 11; AGL: 8; MAN: 9; DEF: 12; Gold: 120; Resistances: None; Weaknesses: None; Family: Undead
- **Garlic** - HP: 231; STR: 25; AGL: 26; MAN: 15; DEF: 16; Gold: 600; Resistances: None; Weaknesses: None; Family: None
- **Garuda** - HP: 606; STR: 71; AGL: 52; MAN: 88; DEF: 69; Gold: 2000; Resistances: Quake; Weaknesses: None; Family: None
- **Gazer** - HP: 202; STR: 20; AGL: 29; MAN: 18; DEF: 49; Gold: 600; Resistances: Quake; Weaknesses: None; Family: None
- **Gecko** - HP: 103; STR: 12; AGL: 14; MAN: 7; DEF: 5; Gold: 120; Resistances: None; Weaknesses: Ice; Family: Lizard
- **Gen-Bu** - HP: 250; STR: 12; AGL: 11; MAN: 12; DEF: 12; Gold: 900; Resistances: Poison; Para; Weaknesses: None; Family: None
- **Gen-Bu2** - HP: 1500; STR: 90; AGL: 100; MAN: 90; DEF: 90; Gold: 0; Resistances: Stone; Para; Weapon; Weaknesses: None; Family: Undead
- **Ghast** - HP: 729; STR: 95; AGL: 56; MAN: 55; DEF: 75; Gold: 2400; Resistances: Ice; Para; Weaknesses: Fire; Family: Undead
- **Ghost** - HP: 666; STR: 63; AGL: 61; MAN: 99; DEF: 99; Gold: 2400; Resistances: Stone; Para; Weapon; Quake; Weaknesses: None; Family: Undead
- **Ghoul** - HP: 103; STR: 15; AGL: 6; MAN: 5; DEF: 10; Gold: 120; Resistances: Para; Weaknesses: Fire; Family: Undead
- **Giant** - HP: 454; STR: 87; AGL: 56; MAN: 54; DEF: 39; Gold: 1600; Resistances: None; Weaknesses: None; Family: Humanoid
- **Gigaworm** - HP: 795; STR: 82; AGL: 62; MAN: 61; DEF: 81; Gold: 2000; Resistances: Fire; Quake; Weaknesses: None; Family: None
- **Goblin** - HP: 20; STR: 9; AGL: 6; MAN: 4; DEF: 3; Gold: 40; Resistances: None; Weaknesses: None; Family: Humanoid
- **Griffin** - HP: 103; STR: 15; AGL: 14; MAN: 21; DEF: 22; Gold: 240; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Guard** - HP: 150; STR: 22; AGL: 21; MAN: 9; DEF: 8; Gold: 240; Resistances: None; Weaknesses: None; Family: None
- **Gummy** - HP: 551; STR: 44; AGL: 43; MAN: 42; DEF: 77; Gold: 2000; Resistances: Para; Weapon; Quake; Weaknesses: Fire; Family: None
- **Gunfish** - HP: 330; STR: 42; AGL: 40; MAN: 54; DEF: 28; Gold: 1200; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Harpy** - HP: 231; STR: 30; AGL: 19; MAN: 39; DEF: 28; Gold: 600; Resistances: Quake; Weaknesses: None; Family: None
- **Hi-Slime** - HP: 795; STR: 63; AGL: 62; MAN: 61; DEF: 99; Gold: 2400; Resistances: Para; Weapon; Quake; Weaknesses: None; Family: None
- **Hornet** - HP: 126; STR: 18; AGL: 25; MAN: 26; DEF: 17; Gold: 400; Resistances: Quake; Weaknesses: Ice; Family: None
- **Human  F** - HP: 40; STR: 3; AGL: 0; MAN: 7; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  F** - HP: 60; STR: 4; AGL: 1; MAN: 8; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  F** - HP: 262; STR: 19; AGL: 0; MAN: 39; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  F** - HP: 368; STR: 28; AGL: 0; MAN: 54; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  M** - HP: 40; STR: 7; AGL: 0; MAN: 3; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  M** - HP: 60; STR: 8; AGL: 1; MAN: 4; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  M** - HP: 262; STR: 39; AGL: 0; MAN: 19; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Human  M** - HP: 368; STR: 54; AGL: 0; MAN: 28; DEF: 0; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Hunter** - HP: 295; STR: 45; AGL: 44; MAN: 22; DEF: 21; Gold: 900; Resistances: Para; Weaknesses: None; Family: None
- **Hydra** - HP: 409; STR: 51; AGL: 65; MAN: 49; DEF: 35; Gold: 1600; Resistances: Weapon; Weaknesses: Fire; Family: Lizard
- **Ice Crab** - HP: 330; STR: 41; AGL: 67; MAN: 29; DEF: 27; Gold: 1200; Resistances: Ice; Weaknesses: Elem; Family: Water
- **Imp** - HP: 202; STR: 26; AGL: 23; MAN: 24; DEF: 27; Gold: 600; Resistances: Quake; Weaknesses: None; Family: Undead
- **Ironman** - HP: 551; STR: 84; AGL: 65; MAN: 47; DEF: 82; Gold: 2000; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Weaknesses: None; Family: None
- **Jaguar** - HP: 103; STR: 18; AGL: 12; MAN: 16; DEF: 7; Gold: 240; Resistances: None; Weaknesses: None; Family: None
- **Jelly** - HP: 295; STR: 23; AGL: 22; MAN: 21; DEF: 44; Gold: 40; Resistances: Para; Weapon; Quake; Weaknesses: Fire; Family: None
- **Jorgandr** - HP: 729; STR: 82; AGL: 99; MAN: 80; DEF: 62; Gold: 2000; Resistances: Stone; Para; Weapon; Quake; Weaknesses: None; Family: Lizard
- **Karateka** - HP: 60; STR: 7; AGL: 4; MAN: 5; DEF: 2; Gold: 40; Resistances: None; Weaknesses: None; Family: Humanoid
- **Keller** - HP: 501; STR: 65; AGL: 36; MAN: 50; DEF: 34; Gold: 1600; Resistances: None; Weaknesses: None; Family: Humanoid
- **Ki-Rin** - HP: 666; STR: 82; AGL: 80; MAN: 99; DEF: 99; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Weaknesses: None; Family: Lizard
- **Kingcrab** - HP: 606; STR: 70; AGL: 99; MAN: 53; DEF: 51; Gold: 2000; Resistances: Fire; Stone; Weaknesses: Elem; Family: Water
- **Kingswrd** - HP: 103; STR: 12; AGL: 12; MAN: 12; DEF: 12; Gold: 240; Resistances: None; Weaknesses: None; Family: Humanoid
- **Ko-Run** - HP: 606; STR: 71; AGL: 88; MAN: 69; DEF: 52; Gold: 2000; Resistances: Poison; Weapon; Weaknesses: None; Family: Lizard
- **Kraken** - HP: 729; STR: 82; AGL: 80; MAN: 81; DEF: 62; Gold: 2000; Resistances: Fire; Weaknesses: None; Family: Water
- **Lamia** - HP: 409; STR: 39; AGL: 54; MAN: 56; DEF: 71; Gold: 1600; Resistances: None; Weaknesses: None; Family: Lizard
- **Lavaworm** - HP: 454; STR: 51; AGL: 35; MAN: 34; DEF: 50; Gold: 1600; Resistances: Fire; Weaknesses: Ice; Family: None
- **Leviathn** - HP: 729; STR: 82; AGL: 80; MAN: 99; DEF: 62; Gold: 2000; Resistances: Fire; Quake; Weaknesses: None; Family: Water
- **Lich** - HP: 729; STR: 81; AGL: 61; MAN: 63; DEF: 99; Gold: 2400; Resistances: Ice; Stone; Para; Weapon; Weaknesses: None; Family: Undead
- **Lilith** - HP: 666; STR: 62; AGL: 80; MAN: 82; DEF: 99; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Weaknesses: None; Family: Lizard
- **Lizard** - HP: 40; STR: 5; AGL: 7; MAN: 4; DEF: 2; Gold: 40; Resistances: None; Weaknesses: Ice; Family: Lizard
- **Machine** - HP: 1000; STR: 70; AGL: 70; MAN: 70; DEF: 0; Gold: 0; Resistances: Stone; Para; Weapon; Weaknesses: None; Family: None
- **Magician** - HP: 103; STR: 10; AGL: 8; MAN: 21; DEF: 27; Gold: 240; Resistances: None; Weaknesses: None; Family: Humanoid
- **Mantcore** - HP: 150; STR: 22; AGL: 21; MAN: 30; DEF: 31; Gold: 400; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Mantis** - HP: 666; STR: 82; AGL: 99; MAN: 99; DEF: 80; Gold: 2000; Resistances: Poison; Quake; Weaknesses: None; Family: None
- **Mazin** - HP: 729; STR: 99; AGL: 81; MAN: 62; DEF: 99; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Weaknesses: None; Family: None
- **Medusa** - HP: 126; STR: 11; AGL: 17; MAN: 19; DEF: 25; Gold: 400; Resistances: None; Weaknesses: None; Family: Lizard
- **Minotaur** - HP: 454; STR: 71; AGL: 39; MAN: 54; DEF: 56; Gold: 1600; Resistances: Weapon; Weaknesses: None; Family: None
- **Mosquito** - HP: 150; STR: 22; AGL: 30; MAN: 31; DEF: 21; Gold: 400; Resistances: Quake; Weaknesses: Ice; Family: None
- **Mou-Jya** - HP: 330; STR: 50; AGL: 25; MAN: 24; DEF: 37; Gold: 900; Resistances: Para; Weaknesses: Fire; Family: Undead
- **Musasi** - HP: 666; STR: 75; AGL: 93; MAN: 95; DEF: 56; Gold: 2400; Resistances: None; Weaknesses: None; Family: Humanoid
- **Mutant F** - HP: 20; STR: 3; AGL: 0; MAN: 7; DEF: 5; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant F** - HP: 40; STR: 4; AGL: 0; MAN: 8; DEF: 6; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant F** - HP: 231; STR: 19; AGL: 4; MAN: 39; DEF: 29; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant F** - HP: 330; STR: 28; AGL: 14; MAN: 54; DEF: 41; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant M** - HP: 20; STR: 7; AGL: 0; MAN: 3; DEF: 5; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant M** - HP: 40; STR: 8; AGL: 0; MAN: 4; DEF: 6; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant M** - HP: 231; STR: 39; AGL: 4; MAN: 19; DEF: 29; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Mutant M** - HP: 330; STR: 54; AGL: 16; MAN: 28; DEF: 41; Gold: 0; Resistances: None; Weaknesses: None; Family: None
- **Naga** - HP: 454; STR: 43; AGL: 59; MAN: 61; DEF: 77; Gold: 2000; Resistances: None; Weaknesses: None; Family: Lizard
- **Nike** - HP: 729; STR: 82; AGL: 62; MAN: 99; DEF: 80; Gold: 2000; Resistances: Quake; Weaknesses: None; Family: None
- **Ninja** - HP: 262; STR: 33; AGL: 43; MAN: 45; DEF: 22; Gold: 900; Resistances: None; Weaknesses: None; Family: Humanoid
- **Nue** - HP: 409; STR: 55; AGL: 54; MAN: 71; DEF: 72; Gold: 1600; Resistances: Quake; Weaknesses: None; Family: Lizard
- **O-Bake** - HP: 20; STR: 4; AGL: 3; MAN: 8; DEF: 9; Gold: 40; Resistances: Para; Weaknesses: Fire; Family: Undead
- **Octopus** - HP: 126; STR: 13; AGL: 11; MAN: 12; DEF: 7; Gold: 240; Resistances: None; Weaknesses: Elem; Family: Water
- **Ogre** - HP: 262; STR: 55; AGL: 34; MAN: 32; DEF: 22; Gold: 900; Resistances: None; Weaknesses: None; Family: Humanoid
- **Oni** - HP: 60; STR: 14; AGL: 9; MAN: 7; DEF: 5; Gold: 120; Resistances: None; Weaknesses: None; Family: Humanoid
- **P-Flower** - HP: 175; STR: 18; AGL: 19; MAN: 10; DEF: 11; Gold: 400; Resistances: None; Weaknesses: None; Family: None
- **P-Frog** - HP: 82; STR: 8; AGL: 11; MAN: 6; DEF: 4; Gold: 120; Resistances: None; Weaknesses: Ice; Family: Lizard
- **P-Worm** - HP: 231; STR: 26; AGL: 16; MAN: 15; DEF: 25; Gold: 600; Resistances: None; Weaknesses: Ice; Family: None
- **Phantom** - HP: 82; STR: 6; AGL: 5; MAN: 14; DEF: 15; Gold: 120; Resistances: Stone; Para; Weapon; Quake; Weaknesses: Fire; Family: Undead
- **Phoenix** - HP: 666; STR: 82; AGL: 62; MAN: 99; DEF: 80; Gold: 2400; Resistances: Fire; Quake; Weaknesses: None; Family: None
- **Piranha** - HP: 82; STR: 11; AGL: 9; MAN: 14; DEF: 6; Gold: 120; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Pirate** - HP: 126; STR: 14; AGL: 7; MAN: 10; DEF: 5; Gold: 40; Resistances: None; Weaknesses: None; Family: Humanoid
- **Pudding** - HP: 729; STR: 57; AGL: 56; MAN: 55; DEF: 94; Gold: 2400; Resistances: Para; Weapon; Quake; Weaknesses: None; Family: None
- **Rakshasa** - HP: 606; STR: 88; AGL: 52; MAN: 69; DEF: 71; Gold: 2000; Resistances: Weapon; Weaknesses: None; Family: None
- **Raven** - HP: 150; STR: 19; AGL: 11; MAN: 25; DEF: 17; Gold: 400; Resistances: Quake; Weaknesses: None; Family: None
- **Red Bone** - HP: 103; STR: 12; AGL: 6; MAN: 8; DEF: 17; Gold: 240; Resistances: Para; Weapon; Weaknesses: Fire; Family: Undead
- **Redbull** - HP: 60; STR: 8; AGL: 7; MAN: 5; DEF: 4; Gold: 40; Resistances: None; Weaknesses: Ice; Family: None
- **Revnant** - HP: 795; STR: 99; AGL: 62; MAN: 61; DEF: 82; Gold: 2400; Resistances: Ice; Para; Weaknesses: None; Family: Undead
- **Rhino** - HP: 150; STR: 21; AGL: 16; MAN: 14; DEF: 9; Gold: 240; Resistances: None; Weaknesses: Ice; Family: None
- **Robot** - HP: 454; STR: 66; AGL: 65; MAN: 35; DEF: 34; Gold: 1600; Resistances: Para; Weapon; Weaknesses: None; Family: None
- **Rock** - HP: 606; STR: 76; AGL: 56; MAN: 99; DEF: 74; Gold: 2400; Resistances: Quake; Weaknesses: None; Family: None
- **Sabercat** - HP: 202; STR: 35; AGL: 25; MAN: 33; DEF: 16; Gold: 600; Resistances: None; Weaknesses: None; Family: None
- **Salamand** - HP: 666; STR: 70; AGL: 88; MAN: 53; DEF: 51; Gold: 2000; Resistances: Fire; Weaknesses: Ice; Family: Lizard
- **Samurai** - HP: 202; STR: 25; AGL: 33; MAN: 35; DEF: 16; Gold: 600; Resistances: None; Weaknesses: None; Family: Humanoid
- **Sandworm** - HP: 666; STR: 71; AGL: 52; MAN: 51; DEF: 70; Gold: 2000; Resistances: Quake; Weaknesses: Ice; Family: None
- **Scarab** - HP: 666; STR: 62; AGL: 99; MAN: 99; DEF: 81; Gold: 2000; Resistances: Poison; Quake; Weaknesses: None; Family: None
- **Scorpion** - HP: 551; STR: 52; AGL: 89; MAN: 87; DEF: 70; Gold: 2000; Resistances: None; Weaknesses: Ice; Family: None
- **Scylla** - HP: 606; STR: 56; AGL: 74; MAN: 76; DEF: 94; Gold: 2400; Resistances: None; Weaknesses: None; Family: Lizard
- **Seeker** - HP: 295; STR: 29; AGL: 41; MAN: 27; DEF: 67; Gold: 1200; Resistances: Quake; Weaknesses: None; Family: None
- **Sei-Ryu** - HP: 600; STR: 27; AGL: 25; MAN: 27; DEF: 27; Gold: 4800; Resistances: Elem; Para; Weaknesses: None; Family: None
- **Sei-Ryu2** - HP: 1750; STR: 100; AGL: 90; MAN: 90; DEF: 100; Gold: 0; Resistances: Fire; Ice; Elem; Poison; Para; Weaknesses: None; Family: Undead
- **Serpent** - HP: 126; STR: 16; AGL: 21; MAN: 14; DEF: 9; Gold: 240; Resistances: None; Weaknesses: Ice; Family: Lizard
- **Shark** - HP: 175; STR: 23; AGL: 21; MAN: 30; DEF: 14; Gold: 400; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Shrimp** - HP: 103; STR: 13; AGL: 22; MAN: 8; DEF: 6; Gold: 240; Resistances: Fire; Weaknesses: Elem; Family: Water
- **Siren** - HP: 150; STR: 14; AGL: 21; MAN: 23; DEF: 30; Gold: 400; Resistances: None; Weaknesses: None; Family: Lizard
- **Skeleton** - HP: 20; STR: 5; AGL: 2; MAN: 4; DEF: 7; Gold: 40; Resistances: Para; Weapon; Weaknesses: Fire; Family: Undead
- **Slime** - HP: 60; STR: 5; AGL: 4; MAN: 3; DEF: 8; Gold: 40; Resistances: Para; Weapon; Weaknesses: Fire; Family: None
- **Snake** - HP: 60; STR: 9; AGL: 11; MAN: 7; DEF: 5; Gold: 120; Resistances: None; Weaknesses: Ice; Family: Lizard
- **Snowcat** - HP: 368; STR: 61; AGL: 46; MAN: 59; DEF: 32; Gold: 1200; Resistances: Ice; Weaknesses: Fire; Family: None
- **Soldier** - HP: 501; STR: 60; AGL: 76; MAN: 78; DEF: 43; Gold: 2000; Resistances: None; Weaknesses: None; Family: Humanoid
- **Sorcerer** - HP: 330; STR: 33; AGL: 31; MAN: 60; DEF: 74; Gold: 1200; Resistances: None; Weaknesses: None; Family: Humanoid
- **Spector** - HP: 606; STR: 56; AGL: 55; MAN: 94; DEF: 95; Gold: 2400; Resistances: Stone; Para; Weapon; Quake; Weaknesses: None; Family: Undead
- **Sphinx** - HP: 606; STR: 75; AGL: 74; MAN: 94; DEF: 95; Gold: 2400; Resistances: Quake; Weaknesses: None; Family: Lizard
- **Squid** - HP: 606; STR: 71; AGL: 69; MAN: 70; DEF: 52; Gold: 2000; Resistances: Fire; Weaknesses: None; Family: Water
- **Steward** - HP: 20; STR: 1; AGL: 1; MAN: 1; DEF: 1; Gold: 400; Resistances: None; Weaknesses: None; Family: Humanoid
- **Stoneman** - HP: 330; STR: 55; AGL: 41; MAN: 28; DEF: 53; Gold: 1200; Resistances: Stone; Para; Weapon; Weaknesses: None; Family: None
- **Su-Zaku** - HP: 1500; STR: 85; AGL: 77; MAN: 85; DEF: 85; Gold: 6500; Resistances: Fire; Para; Weaknesses: None; Family: None
- **Su-Zaku** - HP: 5000; STR: 85; AGL: 255; MAN: 85; DEF: 85; Gold: 0; Resistances: Fire; Ice; Elem; Poison; Stone; Para; Weapon; Quake; Weaknesses: None; Family: None
- **Su-Zaku2** - HP: 2500; STR: 100; AGL: 100; MAN: 100; DEF: 100; Gold: 0; Resistances: Fire; Ice; Elem; Poison; Para; Weaknesses: None; Family: Undead
- **Susano-O** - HP: 729; STR: 99; AGL: 82; MAN: 80; DEF: 62; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Weaknesses: None; Family: Humanoid
- **Ten-Gu** - HP: 368; STR: 47; AGL: 32; MAN: 60; DEF: 45; Gold: 1200; Resistances: Quake; Weaknesses: None; Family: None
- **Thorn** - HP: 368; STR: 41; AGL: 42; MAN: 27; DEF: 28; Gold: 1200; Resistances: Poison; Weaknesses: None; Family: None
- **Thunder** - HP: 330; STR: 47; AGL: 32; MAN: 74; DEF: 45; Gold: 1200; Resistances: Quake; Weaknesses: None; Family: None
- **Tiamat** - HP: 666; STR: 99; AGL: 80; MAN: 62; DEF: 99; Gold: 2400; Resistances: Fire; Ice; Elem; Poison; Quake; Weaknesses: None; Family: Lizard
- **Titan** - HP: 666; STR: 99; AGL: 76; MAN: 74; DEF: 56; Gold: 2400; Resistances: None; Weaknesses: None; Family: Humanoid
- **Tororo** - HP: 454; STR: 36; AGL: 35; MAN: 34; DEF: 65; Gold: 900; Resistances: Para; Weapon; Quake; Weaknesses: Fire; Family: None
- **Triceras** - HP: 295; STR: 49; AGL: 38; MAN: 36; DEF: 25; Gold: 900; Resistances: None; Weaknesses: Ice; Family: None
- **Trooper** - HP: 606; STR: 84; AGL: 83; MAN: 47; DEF: 46; Gold: 2000; Resistances: Weapon; Weaknesses: None; Family: None
- **Vampire** - HP: 606; STR: 57; AGL: 55; MAN: 94; DEF: 99; Gold: 2400; Resistances: Ice; Weapon; Weaknesses: Fire; Family: Undead
- **Warrior** - HP: 501; STR: 60; AGL: 42; MAN: 44; DEF: 77; Gold: 2000; Resistances: Para; Weapon; Weaknesses: Fire; Family: Undead
- **Watcher** - HP: 454; STR: 44; AGL: 60; MAN: 42; DEF: 94; Gold: 2000; Resistances: Quake; Weaknesses: None; Family: None
- **Wererat** - HP: 40; STR: 8; AGL: 4; MAN: 5; DEF: 7; Gold: 40; Resistances: None; Weaknesses: None; Family: None
- **Werewolf** - HP: 103; STR: 17; AGL: 7; MAN: 11; DEF: 13; Gold: 240; Resistances: Weapon; Weaknesses: None; Family: None
- **Wight** - HP: 606; STR: 84; AGL: 47; MAN: 46; DEF: 65; Gold: 2000; Resistances: Ice; Para; Weaknesses: Fire; Family: Undead
- **Wizard** - HP: 454; STR: 44; AGL: 42; MAN: 77; DEF: 94; Gold: 2000; Resistances: None; Weaknesses: None; Family: Humanoid
- **Wolf** - HP: 60; STR: 12; AGL: 8; MAN: 10; DEF: 5; Gold: 120; Resistances: None; Weaknesses: None; Family: None
- **Woodman** - HP: 150; STR: 26; AGL: 18; MAN: 11; DEF: 24; Gold: 400; Resistances: None; Weaknesses: Fire; Family: None
- **Worm** - HP: 82; STR: 9; AGL: 5; MAN: 4; DEF: 8; Gold: 120; Resistances: None; Weaknesses: Ice; Family: None
- **Wraith** - HP: 501; STR: 47; AGL: 46; MAN: 83; DEF: 84; Gold: 2000; Resistances: Stone; Para; Weapon; Quake; Weaknesses: None; Family: Undead
- **Wrestler** - HP: 295; STR: 39; AGL: 20; MAN: 29; DEF: 18; Gold: 600; Resistances: None; Weaknesses: None; Family: Humanoid
- **Zombie** - HP: 60; STR: 9; AGL: 4; MAN: 3; DEF: 6; Gold: 40; Resistances: Para; Weaknesses: Fire; Family: Undead
