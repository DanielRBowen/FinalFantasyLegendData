# Final Fantasy Legend 3 - Complete LLM Guide

**Version**: 0.2

**Sources**: 47306_Game_Lists.txt and 80317_Glitchless_Walkthrough.txt.

**Notes**: This parser-generated FFL3 reference combines formula and system notes with structured equipment, spells, talents, status conditions, species tables, walkthrough-derived route items plus equipment and spell acquisitions, and chronology-linked story mentions.

## Sections

- Attack Properties and Damage Rules
- Stats and Upgrades
- Class and Progression Differences
- Changing Class
- Story Chronology
- Characters
- Equipment
- Items
- Spells
- Abilities
- Status Effects
- Monster and Species Tables
- Formula Reference
- Robot Capsules
- Talon Units

## Attack Properties and Damage Rules

- **Elementals and resistances**: FFL3 uses Fire, Ice, Tornado, and Quake as its base elementals, with Thunder treated as the combined Ice and Tornado element. Strong resistance halves skill, while weakness doubles skill.
  Sources: 47306_Game_Lists.txt
- **Damage property**: ODamage halves attacks that carry the Damage property, which affects most physical weapons and some talents. Late-game enemies use this heavily, so non-Damage properties become important.
  Sources: 47306_Game_Lists.txt
- **Holy and Mystic**: Holy weapons deal double damage to undead, while Mystic weapons deal double damage to bosses and undead. These properties are part of why endgame sword choice matters more than raw power alone.
  Sources: 47306_Game_Lists.txt
- **Formula families**: Melee, missile, martial arts, fixed-damage weapons, attack magic, item magic, talents, and Talon weapons each have separate damage formulas. The module exports the exact equations to a dedicated CSV for reference.
  Sources: 47306_Game_Lists.txt
- **Group targeting**: For formulas that target a group, damage is divided by the number of enemies in that group. Single-target and all-target attacks keep full damage.
  Sources: 47306_Game_Lists.txt

## Stats and Upgrades

- **Stat meanings**: Attack drives most weapons and some talents, Agility affects melee damage and turn order, Magic powers spells and some talents, while Hit, Evade, M.Def., and M.Evade control accuracy and magical durability.
  Sources: 47306_Game_Lists.txt
- **Cyborg equipment bonuses**: Cyborgs derive most of their growth from gear. Weapons and shields add max HP and Attack, helmets and armor add max HP and Defense, gloves and shoes add max MP and Agility, and accessory-type items add max MP and Magic.
  Sources: 47306_Game_Lists.txt
- **Robot capsules**: Robot capsules permanently raise robot-only stats while in robot form. HP capsules add 24-40 max HP, Attack and Defense capsules add +3 to their stat, and Speed capsules add +3 Agility. Capsule gains cap at 999 HP and 99 for Attack, Defense, and Agility.
  Sources: 47306_Game_Lists.txt
- **Talon units**: The Talon acts as both progression tool and battle platform. Engine, warp, weapon, and option units expand movement, world access, encounter control, and full-party recovery.
  Sources: 47306_Game_Lists.txt

## Class and Progression Differences

- **Monsters and beasts**: Monsters are functional without equipment and keep strong raw stats, while beasts get a mixed toolkit and 1.5x martial-arts skill. Both can use talents, which gives them flexible non-weapon offense.
  Sources: 47306_Game_Lists.txt
- **Mutants and humans**: Mutants are the spell specialists with 2x attack-magic skill, while humans are the weapon specialists with 2x normal melee skill and 2x throwing skill. Humans lose some of that late-game edge once Mystic swords equalize skill across classes.
  Sources: 47306_Game_Lists.txt
- **Cyborgs and robots**: Cyborgs become strong generalists when fed top equipment, while robots trade magic access for controllable, permanent capsule-driven stat growth and boosted robot-talent skill.
  Sources: 47306_Game_Lists.txt
- **Display caps**: The guide explicitly notes that HP and primary stats can exceed their displayed 999 and 99 menu caps even though the UI stops showing larger values.
  Sources: 47306_Game_Lists.txt

## Changing Class

- **Transformation continuum**: Class changes follow Monster <=> Beast <=> Human/Mutant <=> Cyborg <=> Robot. Meat pushes the character left, parts push the character right, and the Flushex unit pulls classes back toward the center.
  Sources: 47306_Game_Lists.txt
- **Species selection**: Intrinsic element determines which species chart entry is chosen after class changes. Earth, Water, Fire, and Air cross-map differently depending on the enemy part or meat consumed.
  Sources: 47306_Game_Lists.txt
- **Stat retention**: Transformations preserve different shares of enemy base stats depending on the resulting class: monsters keep 100 percent, beasts keep full stats except half Defense, cyborgs retain mixed percentages and add equipment bonuses, and robots retain partial non-magic stats plus capsule bonuses.
  Sources: 47306_Game_Lists.txt

## Story Chronology

### 1. SIMULATOR BATTLE

- **Section**: S01
- **World**: None
- **Summary**: TURN 1: Arthur/Curtis Attack Divner1, Gloria uses Ice1 on Diviner2, Myron attacks Sprite1. TURN 2: All Attack Sprite2.
- **Characters**: Arthur; Curtis; Gloria
- **Spells**: Ice 1

### 2. DHARM CITY

- **Section**: S02
- **World**: None
- **Summary**: Walk from Talon Shrine to Dharm City, enter magic shop and get Ice1 for Curtis. Enter battle simulator until all level 3, buy 2 Leather Armor(females), 2 Leather Shoes(males), 3 Leather Helm(all but Sharon), 7 Belt(all but Gloria), use Inn before leaving town.
- **Characters**: Curtis; Gloria; Sharon
- **Equipment**: Battle; Leather
- **Spells**: Ice 1

### 3. LEAVING DHARM/NORTH TOWER

- **Section**: S03
- **World**: None
- **Summary**: Go to North Tower get Leather Glove and equip to Gloria, get Float Spell, fall down hole then walk down stars and leave North Tower. Give Float Spell to Arthur.
- **Characters**: Arthur; Gloria
- **Equipment**: Leather

### 4. ELAN CITY

- **Section**: S04
- **World**: None
- **Summary**: Fly Southwest To Elan, buy 4 Plume and 4 Psi Daggers, Equip 1 each to all party members, talk to Chronos in southern house to get Past Unit, use Inn on way out if needed.
- **Characters**: Chronos
- **Items**: Past Unit

### 5. BACK TO TALON SHRINE/WATER HAG BOSS FIGHT

- **Section**: S05
- **World**: None
- **Summary**: Fly East to Water Hag boss, fully cure party with Myron before fight, SAVE before fight to avoid Unexpected Attack. Ideally level 4-5. Arthur/Sharon use Psi Daggers, Curtis/Gloria use Ice1, Myron Attacks. Try to keep all 4 alive for EXP bonus post fight. Cure party with Myron before entering Whirlgate inside Talon Shrine.
- **Characters**: Arthur; Curtis; Gloria; Sharon; Water Hag
- **Spells**: Ice 1

### 6. TO THE PAST

- **Section**: S06
- **World**: None
- **Summary**: Equip Talon with Past Unit by checking viewer screen. Warp to Past, then fly southwest to Lae City. Buy max Cure1 Potions and get Flushex Unit. Buy 2 Fire1 Spells, give to Curtis/Gloria. Use remaining GP to buy Silver Armors but save enough GP to use Inn before leaving. Walk outside Lae City and grind to level 7 for party, using Inn to restore MP when required. By level 7 should have enough GP for 4 Silver Helm, 4 Br...
- **Characters**: Curtis; Gloria
- **Monsters**: Silver
- **Items**: Flushex Unit; Past Unit
- **Equipment**: Bronze; Silver
- **Spells**: Cure1; Fire1

### 7. TO SOUTHERN CAVE

- **Section**: S07
- **World**: None
- **Summary**: Take encounters on the path to Southern Cave. Fly South around mountains to get there. Heal/Save before entering cave. Use Maps to navigate direct path to Lara, skipping treasures. If encountering the Thoth/Jerrit enemy formation, battle them as you have a chance at getting a Pendant drop. If you get 1 or more, equip to Gloria/Curtis/Sharon/Arthur in that order of priority and replace the Belt they currently have equ...
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Monsters**: Jerrit
- **Equipment**: Battle; Pendant
- **Spells**: Cure1

### 8. LARA BOSS FIGHT

- **Section**: S08
- **World**: None
- **Summary**: Heal/Save before engaging Lara to avoid Unexpected Attack. Use Psi Daggers with Arthur/Sharon and Fire1 with Curtis/Gloria. Lara has resistance to Fire but it does more damage than Ice. All 4 must survive to maximize EXP bonus and Leveling. Heal/Save after defeating Lara using her Cure1 Spell.
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Spells**: Cure1; Fire1

### 9. DOGRA BOSS FIGHT

- **Section**: S09
- **World**: None
- **Summary**: This is a difficult battle, use Psi Daggers and Ice1 Spells to take out the Witches first, do not use Fire1 against Witches as they have resistance to Fire. Have Lara use Lit1 against Dogra. Try to keep HP high with remaining Cure1 Potions, ideally all 4 party members must survive but 3 is okay. When the Witches are gone use Fire1 with Curtis/Gloria against Dogra. Heal/Save after battle and get the Rover unit. Take e...
- **Characters**: Curtis; Gloria
- **Items**: Rover Unit
- **Equipment**: Battle
- **Spells**: Cure1; Fire1; Ice 1; Lit 1

### 10. BACK TO ELAN CITY

- **Section**: S10
- **World**: None
- **Summary**: Use Inn and talk to Granny in southern house to get the Dive Spell. Leave Elan and go east to coast, then use Dive Spell. Go underwater and move north along coast and then west to find the underwater city of Muu.
- **Characters**: Granny

### 11. MUU CITY (PAST)

- **Section**: S11
- **World**: Past
- **Summary**: Go to western part of town to find a soft potion in the right chest, skip the left chest containing the Ifram seed as it is not required. Sell any extra armor and then buy as many Pendants, Gold Gloves and Iron Boots as you can in that order of priority, ideally 4 of each and equip to party, then sell remaining armor. Equip Pendants in place of Belts. Go to Item Shop and buy at least 1 Elixir, then as many Cure2 Poti...
- **Items**: Elixir
- **Spells**: Cure2

### 12. RETURN TO PRESENT

- **Section**: S12
- **World**: None
- **Summary**: Move east and then south from Muu to return to the Talon Shrine and warp to the Present. Upon leaving the shrine in the present an auto scene will be triggered back in Dharm. Use Inn if required before leaving Dharm.

### 13. RETURN TO ELAN CITY (PRESENT)

- **Section**: S13
- **World**: Present
- **Summary**: Fly west to Elan, talk to Cronos to get Tower Key, use Inn if required before leaving Elan City. Leave and use Float to travel south and east around mountains to South Tower, Heal/Save before entering Tower.
- **Items**: Tower Key

### 14. SOUTH TOWER

- **Section**: S14
- **World**: None
- **Summary**: Get B-jack and air crystal on way to Ashura, taking encounters, equip B-jack on Arthur as soon as you find it. Use Maps to navigate direct path. Heal/Save before fighting Ashura to avoid Unexpected Attack.
- **Characters**: Arthur; Ashura
- **Items**: Air Crystal; B-jack

### 15. ASHURA BOSS FIGHT

- **Section**: S15
- **World**: None
- **Summary**: This can also be a difficult battle but usually not as tough as Dogra. Ideally you want to be at least level 10-11 for this fight. If you have enough GP, you can route diverge to Muu after Elan to pick up Lit1 spells for Curtis/Gloria, which can help a lot but is not required. Use B-jack/Psi Dagger and Fire1/Lit1 to take out the Warriors first. Ashura has resistance to Fire, so use Ice1 or Lit1 if you have it on Curt...
- **Characters**: Ashura; Curtis; Gloria
- **Items**: B-jack
- **Equipment**: Battle
- **Spells**: Cure2; Fire1; Ice 1; Lit 1

### 16. RETURN TO MUU (PRESENT)

- **Section**: S16
- **World**: Present
- **Summary**: Go north to the coast and use Dive. Return to Muu but be sure to check the sunken ship to the east of there for the Teargas/Air Crystal first. Use the Inn as it will most likely be needed when you get to Muu. Buy 2 Lit1 Spells if you do not already have them for Curtis/Gloria, and buy Cure2 Spells for everyone. Go to the Armor Shop and buy 4 Dragon Glove, then 3 Silver Shield, prioritizing the Dragon Gloves first. Se...
- **Characters**: Arthur; Curtis; Gloria
- **Monsters**: Silver
- **Items**: Air Crystal; B-jack; Teargas; Water Crystal
- **Equipment**: Dragon; Silver; TearGas
- **Spells**: Cure2; Lit 1

### 17. PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR

- **Section**: S17
- **World**: None
- **Summary**: Use maps to plunder the 2 remaining sunken ships taking direct routes to each. Continue to take encounters as you do. Return to Muu once you have done so and pick up any remaining Armor that you did not get earlier, IE Gold Helmets and Gold Boots. Use the Inn to restore your HP/MP. Sell the Thunder Staff you plundered and the Iron Boots and remaining armor then go to the Item Shop. Buy max Cure2 Potions and Softs, th...
- **Monsters**: Evil Eye
- **Equipment**: Thunder staff
- **Spells**: Cure2
- **Abilities**: Thunder

### 18. CASTLE OF CHAOS

- **Section**: S18
- **World**: None
- **Summary**: Do NOT enter Chaos Castle until you are at least level 12. This gives you a good chance and running away from the Dual Mask enemies, which can be a real problem. Use Maps to get all the boxes on the way to Chaos except the Soft Potion which you should already have enough of. Take encounters on the way except for the aforementioned Dual Masks. The Horus/Fiend formation is very good and can drop Para spells to sell for...
- **Characters**: Curtis; Gloria

### 19. CHAOS BOSS BATTLE

- **Section**: S19
- **World**: None
- **Summary**: This is widely regarded as one of the most difficult boss battles in the game. Ideally you want to be level 12-13 for this fight. Make sure to Heal/Save and equip the 2 TNT and Teargas weapons to Arthur/Sharon before you fight Chaos, and avoid the Unexpected Attack. Use the Teargas and TNT, then re equip your B-jack and Psi Dagger in battle once they are gone, and have Curtis/Gloria use Lit1. If Chaos uses Quake, mak...
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Items**: B-jack; Teargas
- **Equipment**: Battle; TearGas
- **Spells**: Cure2; Lit 1

### 20. LEAVING CHAOS CASTLE

- **Section**: S20
- **World**: None
- **Summary**: Heal/Save after the battle and pick up the Future and Hover units. Continue to take encounters on the way out except for the Dual Masks. If you are lucky you might get Para Spells or Dragon Gloves to drop on the way out.
- **Items**: Future Unit; Hover Unit
- **Equipment**: Battle; Dragon

### 21. THE FUTURE AWAITS

- **Section**: S21
- **World**: None
- **Summary**: Return to Muu, use the Inn and restock your Elixirs to full. Sell any extra armor or item drops you got. Fly east to Talon Shrine, warp to the future. Fly west to Elan City, beware of enemy encounters as they are stronger now in the future. Go to the Inn in Elan City and talk to Granny in the bed to get the Morph Spell.
- **Characters**: Granny

### 22. RETURN TO MUU (FUTURE)

- **Section**: S22
- **World**: Future
- **Summary**: Leave Elan City and go west to the coastline, use Dive and go north to Muu. First priority is to buy Quake Spells for everyone, then Ice2 Spells for Curtis/Gloria. Be sure to use the Morph Spell to avoid fighting WaterHags. There will be random encounters in Muu now so this is a good spot to grind out some more levels and GP, being close to an Inn. Suggested grind is to level 15, have everyone use Quake to maximize d...
- **Characters**: Curtis; Gloria
- **Equipment**: Shades
- **Spells**: Ice 2

### 23. PLUNDERING SUNKEN SHIPS (FUTURE)

- **Section**: S23
- **World**: Future
- **Summary**: There are 3 more sunken ships to be found in the future, use maps to plot a direct route to each one, each has 2 boxes within them. Take encounters as you go, using Quake.

### 24. TO NEW DHARM/VIPER CITY

- **Section**: S24
- **World**: None
- **Summary**: Surface, go east to New Dharm, buy elixirs, use inn, get password from Myron leave and go north to Viper, buy 4 Geta Boots, sell extras found from the sunken ships. Enter the main base, get items on right, equip the Laser Sword to Sharon, heal at Dr. Belksi, recruit Dion, get the Rocket, then leave and use Dive on the east coast, go north to Dr. Pulcers undersea base and get the Radio. Then leave and go southwest to...
- **Characters**: Sharon
- **Items**: Rocket
- **Equipment**: Laser sword
- **Abilities**: Rocket

### 25. FLOATLAND ARRIVAL

- **Section**: S25
- **World**: None
- **Summary**: First Priority Buy 4 Speed Armors, 2 X-Plane Shields for Arthur/Sharon and 3 Earring. Sell extra armor afterward. Use the Inn then go north to the Floatland Ruins.
- **Characters**: Arthur; Sharon
- **Equipment**: Earring; X-Plane

### 26. FLOATLAND RUINS

- **Section**: S26
- **World**: None
- **Summary**: There are a lot of hidden passages in here, so use maps to take efficient routes and make sure you do not skip any boxes, continue to take encounters along the way. Quake is still your best option.

### 27. PATH TO MAITREYA

- **Section**: S27
- **World**: None
- **Summary**: Use maps to navigate from the Floatland Ruins to Floatland Mountain, be sure not to miss the Ice Shield found on the mountain as it is very important later. Equip it to Gloria. When you reach the Tower, follow the maps to get all the boxes and be sure to check the top floor before backtracking to the hidden passage to Maitreya, continue taking encounters to build EXP and GP, Quake remains the best option. Make sure t...
- **Characters**: Curtis; Gloria; Maitreya

### 28. MAITREYA BOSS FIGHT

- **Section**: S28
- **World**: None
- **Summary**: Heal/Save before the battle to avoid the Unexpected Attack. Equip the Battle Armor to Sharon. Take out the Lamias first with Quake Spells and physical attacks. Use Ice2 and physical attacks on Maitreya, be sure to keep your HP high and do not hesitate to heal after getting hit with Cyclone. Recommended level is 16-17. Get the X-Plane unit after the fight and use Curtis to exit out. Use the Radio to contact Dr. Pulcer...
- **Characters**: Curtis; Maitreya; Sharon
- **Items**: Remote; X-Plane Unit
- **Equipment**: Battle; X-Plane
- **Spells**: Ice 2
- **Abilities**: Cyclone

### 29. PURELAND ARRIVAL

- **Section**: S29
- **World**: Pureland
- **Summary**: Use Berth before exiting the Talon, which functions as a Inn, it can be found on the lower left part of the Talon. Go north to Darius City. Find the Firestar and Heal spell, then buy 4 Diamond Shields from the armor shop, which are very important! Buy 2 Fire2 Spells for Curtis/Gloria and buy Cure3 Spells for everyone, then 2 Dragon Swords for Arthur/Sharon, and the 1 remaining Earring for whoever did not get it earli...
- **Characters**: Arthur; Curtis; Darius; Gloria; Sharon
- **Items**: Firestar
- **Equipment**: Diamond; Dragon; Earring
- **Spells**: Cure3; Fire2

### 30. TO EITAR VILLAGE

- **Section**: S30
- **World**: None
- **Summary**: Call the Talon using the Remote and fly west to Eitar, there will be a single tree next to the village to identify it. The Talon will now attack enemy formations with the Cannon so be sure to take advantage of this and continue to take encounters. In the village, go to the fenced area on the left and look for the broken fence, you can pass through this and then go north to get the Catnip by checking the trees there.
- **Items**: Catnip; Remote

### 31. TO EITAR PRISON

- **Section**: S31
- **World**: None
- **Summary**: Call the Talon using the Remote and fly north to the Eitar Prison. Faye is being held captive here. Once inside, use the Catnip to freeze the cat mummies in place, you can now push them out of the way. Use maps to navigate and be sure to get the Wizard Armor and Fur Armor here. Keep taking encounters but consider running from the Soarx enemies as they are resistant to Quake, which is still your best option for offens...
- **Monsters**: Wizard
- **Items**: Catnip; Remote
- **Equipment**: Wizard
- **Abilities**: Freeze

### 32. FENRIR BOSS FIGHT

- **Section**: S32
- **World**: None
- **Summary**: Heal/Save before Fenrir. The chances of avoiding the Unexpected Attack here are very low, so you are better off just taking it. The Diamond Shields you bought earlier will protect you from his Lit2 and Flood attacks. Use physical attacks and Fire2 spells against Fenrir and keep HP high, in an attempt to keep everyone alive to get the EXP after the fight. Get the Prison Key after the fight and proceed down and right t...
- **Characters**: Fenrir
- **Items**: Prison Key
- **Equipment**: Diamond
- **Spells**: Fire2; Lit 2

### 33. RETURN TO EITAR VILLAGE/DARIUS

- **Section**: S33
- **World**: None
- **Summary**: Use the Remote to call the Talon, use Berth if needed and return to Eitar Village, get the Dark Crystal and speak with Juba, then return to Darius to take boat to Knaya.
- **Characters**: Darius
- **Items**: Dark Crystal; Remote

### 34. KNAYA CITY, THE CENTER OF TRADE

- **Section**: S34
- **World**: None
- **Summary**: There are a lot of shops to check in Knaya, but the only one you should check is the Magic Shop, which is on the far right 3 towers. Buy CureA Spells for everyone, Lit2 Spells for Curtis/Gloria, and if you have enough GP left, buy the Weak Spell for Curtis/Gloria. Leave and call the Talon, use Berth if needed, then fly south and west to Mt. Hasid. Continue taking encounters to level up and gain more GP. Quake is stil...
- **Characters**: Curtis; Gloria
- **Spells**: Lit 2

### 35. MOUNT HASID

- **Section**: S35
- **World**: None
- **Summary**: Use maps to get the Light Crystal, Cool Bracelet and Missile unit here. Make sure to Heal/Save on the stairs leading to Guha as you will automatically encounter him once you step off the stairs. Equip the Ice Shield to Sharon and the Cool Bracelet to Arthur, they will function as your healers and revive downed characters for this fight.
- **Characters**: Arthur; Sharon
- **Items**: Light Crystal; Missile Unit
- **Equipment**: Missile

### 36. GUHA BOSS FIGHT

- **Section**: S36
- **World**: None
- **Summary**: This is another difficult battle. Recommended level is 19-21. Save to avoid the Unexpected Attack, but it is costly on time as there is dialogue before the battle. Use Lit2 and physical attacks against Guha, keep HP high and try to survive to get the EXP at the end of the fight. Guha will use the FireX spell a lot and you will be healing with CureA Spells and reviving with Elixirs undoubtedly. If you can try to get i...
- **Characters**: Sharon
- **Equipment**: Battle; Durend sword
- **Spells**: Lit 2

### 37. TO SOUTHWEST RUINS

- **Section**: S37
- **World**: None
- **Summary**: Use Berth in the Talon, restock your Elixirs at Buzi's shop, then fly west to the Southwest Ruins. Save before Dahak and avoid the Unexpected Attack.

### 38. DAHAK BOSS FIGHT

- **Section**: S38
- **World**: None
- **Summary**: Another difficult battle, Dahak will often use Shake and land mighty blows on your party. Recommended level is 20-22. Use Lit2 Spells and physical attacks against Dahak. If he uses Shake consecutively you can be in big trouble, try to keep everyone alive and make use of Faye's Cure3 Spell. Sharon and the Durend Sword is your best offensive option and if you get lucky you can land a mighty blow. After the fight, get t...
- **Characters**: Sharon
- **Items**: Tablet
- **Equipment**: Battle; Durend sword
- **Spells**: Cure3; Lit 2

### 39. SOUTHWEST RUINS

- **Section**: S39
- **World**: None
- **Summary**: Use maps to navigate here and make sure to get all the boxes, the Fire Crystal is critical so make sure not to miss it. There are puzzles here which require you to push stones to block the flow of water, be sure not to make a mistake with moving the stones or you will have to reset the room and lose time. Make sure you have collected all the items before finishing the last puzzle as you will automatically be warped o...
- **Items**: Fire Crystal

### 40. TO THE FROST CAPE

- **Section**: S40
- **World**: None
- **Summary**: Reboard the Talon and use Berth to heal and restock Elixirs. Then fly east and north, making sure to avoid going into the western desert or you will be pulled into the sandstorm. Take the Tablet to find Shar at the Frost Cape and speak with him until he says he needs more time to examine it. Then fly to the desert in west, but make sure you SAVE FIRST.
- **Items**: Tablet

### 41. JORGANDR BOSS FIGHT

- **Section**: S41
- **World**: None
- **Summary**: Jorgandr has resistance to everything except your Durend Sword. If you were able to get the Weak Spell it can do minor damage. Focus on Sharon using Durend and Faye using Rune Axe as these are your best attacks, everyone else should be supporting or healing. Jorgandr does not have much HP but can hit very hard. Try to keep everyone alive as usual to maximize the EXP after the battle. Recommended level is 21-22. After...
- **Characters**: Jorgandr; Sharon
- **Equipment**: Battle; Durend sword; Rune axe

### 42. TALONSBURG

- **Section**: S42
- **World**: None
- **Summary**: Go north and then west to find Talonsburg. There are important items here such as the Shield unit, so do not miss them and check maps if needed. Dr. Quacer will unveil the Talon2 and you will now be able to fly over the waters with it.
- **Items**: Shield Unit

### 43. RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR

- **Section**: S43
- **World**: None
- **Summary**: Equip the Shield unit to the Talon2 right away, this will allow you to fly on the overworld without enemy encounters! First priority is to return to the Frost Cape and talk with Shar and Buzi, they will both join the Talon2. Then you want to locate the Cave near Eitar and pick up the items in there, most notably the Fire Crystal. With 2 of them now, you can talk to Shar and mix them to make the strongest spell in the...
- **Characters**: Arthur; Gloria; Sharon
- **Items**: Fire Crystal; Light Crystal; Shield Unit; Water Crystal
- **Equipment**: Durend sword

### 44. PLUNDERING CAVES

- **Section**: S44
- **World**: None
- **Summary**: There are 2 more caves on the overworld to check, use maps to find them. Inside are important items such as Dark and Light Crystals and Light Armor. Take battles in the caves, with Quake and Flare Spells now available, you should have minimal problems.
- **Items**: Dark Crystal; Light Crystal

### 45. TO CIRRUS THE CLOUD CITY

- **Section**: S45
- **World**: None
- **Summary**: Recruit Juba in Cirrus Castle and get the Laser unit on the box to the left and Pass from King Clamin.
- **Items**: Laser Unit

### 46. SPEED SHIELDS AND CURE B SPELLS

- **Section**: S46
- **World**: None
- **Summary**: By now you should have enough Dark and Light Crystals to mix 2 Speed Shields from Juba, equip them to Curtis and Gloria. At this point you should also have enough GP to buy 1-2 CureB Spells from Shar. Give the CureB Spells to Curtis and then Arthur in that order of priority. Also make sure to equip the Laser unit to the Talon2 as at this point you will be doing a lengthy grinding session.
- **Characters**: Arthur; Curtis; Gloria
- **Items**: Dark Crystal; Laser Unit; Light Crystal

### 47. PREPARING FOR THE UNDERWORLD

- **Section**: S47
- **World**: Underworld
- **Summary**: While you can go straight to Porle City and enter the whirlgate to the underworld, it is not advised to do so until you are at least level 27-28. Most likely at this time you will only be level 22, and have a long way to go to get to those levels. You are also going to need a LOT of GP, to get more CureB Spells for your party, and to buy top tier armor in the underworld. Another reason to level up here is you have th...
- **Characters**: Gloria
- **Monsters**: Tattler
- **Items**: Laser Unit
- **Equipment**: Battle
- **Spells**: Cure3

### 48. BEFORE GOING INTO THE UNDERWORLD

- **Section**: S48
- **World**: Underworld
- **Summary**: When you finally reach the aforementioned levels, you should have 350000-400000 GP, trust that ALL of this will be needed. With any luck you will also have gotten a few Warm Bracelets from enemy drops. Go to Juba and buy 4 Power Gloves and 4 Bangle Bracelets, equip the Bangles in place of the Pendants and equip the Power Gloves, then sell the remaining armor. Make CERTAIN that everyone in the party has CureB Spells,...
- **Characters**: Arthur; Sharon
- **Equipment**: Bangle

### 49. INTO THE UNDERWORLD

- **Section**: S49
- **World**: Underworld
- **Summary**: Once you have made certain you are level 27 or higher, and have all the aforementioned Equipment and Spells, go to Porle and enter the whirlgate to the Underworld. Dion will join and Faye will leave the party.

### 50. OPTIONAL SIDE QUESTING

- **Section**: S50
- **World**: None
- **Summary**: Once in the Underworld, you can elect to plunder the Mushroom areas, and caves, in addition to the Twin Towers. There is some good treasure to be found, including the items needed to make the Masamune and Emperor Mystic Swords and Aegis Shield, more Dark and Light Crystals to make another Speed Shield, and the E-Ray unit for the Talon2. Use maps to find all of these items if you have chosen to obtain them, but know t...
- **Monsters**: Mushroom
- **Items**: Dark Crystal; Light Crystal

### 51. DWELG TOWN

- **Section**: S51
- **World**: None
- **Summary**: Use the Morph Spell when entering the Dwelg Town to avoid fighting the Dwelgs, who are quite annoying and hit very hard. In the Armor Shop you will find some of the best armor in the entire game. Optimally you want to buy 4 Power Armors, 5 Hecate Helmets and 5 Hermes Shoes, this is going to take a TON of GP however so hope you have been taking encounters since the lengthy grind to level 27 in the Talon2. The reason y...
- **Equipment**: Hecate; Hermes

### 52. BARRIER MACHINE CAVE

- **Section**: S52
- **World**: None
- **Summary**: When you have left the underworld, be sure to heal up and save. Then head east and south to find the Barrier Machine Cave. Use maps to get the items here, including more Light/Dark Crystals, a Scarf Accessory and a Magic Potion. If you are doing a Speedrun you should elect to skip all of these however and proceed straight to Agron. Be sure to keep taking encounters however as you will need all the EXP you can get at...
- **Items**: Dark Crystal; Light Crystal
- **Abilities**: Barrier

### 53. AGRON BOSS FIGHT

- **Section**: S53
- **World**: None
- **Summary**: Make sure to Heal/Save on the tile before the ornate floor in front of the Barrier Machine and Agron, as you will automatically encounter him once you step on the ornate tile. Recommended level is 28-30. Try to avoid the Unexpected Attack if possible, but there is another series of dialogue before the fight and it can cost time. Agron will use White most of the time, and this will deal upwards of 300 damage to the pa...
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Items**: Elixir
- **Abilities**: Barrier

### 54. FINAL PREP BEFORE MOUNT GOHT

- **Section**: S54
- **World**: None
- **Summary**: Borgin will join the party after the Agron fight. Use Exit to leave and then call the Talon2 with the Remote. Go to Juba and buy another Power Glove, Bangle, and Samurai Shield for Borgin, and equip him with those and the extra armor you bought in the Dwelg Town for him. There are 2 more caves that are now accessible and both have very important items, including a Ribbon Accessory, which you should equip to Sharon. T...
- **Characters**: Curtis; Sharon
- **Monsters**: Samurai
- **Items**: Fire Crystal; Remote
- **Equipment**: Bangle; Ribbon; Samurai

### 55. MOUNT GOHT

- **Section**: S55
- **World**: None
- **Summary**: Use maps to navigate the direct path here, there are recovery springs on the way so use them as required to save on items. The landscape will change after the Talon2 destroys part of the mountain so read the map carefully. There are no boxes to check in Mount Goht so proceed directly to Goht Castle. Continue taking encounters, if you are at level 31 or higher, and get the Gill Man meat drop, give it to Sharon or Arth...
- **Characters**: Arthur; Sharon
- **Monsters**: Anubis

### 56. GOHT CASTLE

- **Section**: S56
- **World**: None
- **Summary**: The path to take here is very straight forward. Take the northwestern stairs to the 2nd floor, hit the switch, carefully jump to get the 2 Ribbon Accessories on the left side of the room, then fall down the large hole in the center. From there go up and then left, then down and to the far southeastern part of the room to get the final Ribbon Accessory. Then continue north and east to find Balor. Take any battles you...
- **Characters**: Arthur; Sharon
- **Monsters**: Aeshma; Anubis; Shogun
- **Equipment**: Ribbon

### 57. BALOR BOSS FIGHT

- **Section**: S57
- **World**: None
- **Summary**: Be sure to fully Heal/Save before fighting Balor with a Tent, and try to avoid the Unexpected Attack. Recommended level is 30 and up. Balor has a ton of HP and some devastating attacks. If he uses physicals your party target will most likely not survive. Attack him much the same as the Agron fight, with Arthur/Sharon using Mystic Swords and LifeB or CureB if needed. Curtis should use CureB every round and Gloria shou...
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Monsters**: Anubis
- **Equipment**: Battle

### 58. PATH TO SOL

- **Section**: S58
- **World**: None
- **Summary**: Use a Tent and Save after Balor. At this point you want to take encounters on the way to Sol unless you already have 1 or 2 Anubis monsters. If you have Cyborgs, continue to take encounters. You can elect to get the Nukebomb weapon on the way to Sol as it is just a few steps from the direct route. If so equip it to Gloria and save it for the final battle.
- **Characters**: Gloria
- **Monsters**: Anubis
- **Equipment**: Battle

### 59. SOL/XAGOR FINAL BOSS

- **Section**: S59
- **World**: None
- **Summary**: Recommended level is 31 or higher. Save/Tent before walking into the vertical path to Sol as it is another auto battle. Make sure you have all 4 Ribbons equipped and have your best equipment going into the fight. During the Sol phase, use only weapons except the Nukebomb and have Gloria instead use the Psi Dagger or Psi Gun. Curtis should use Psi Dagger or Psi Gun and Arthur/Sharon should use Durend/Xcalibur. Borgin...
- **Characters**: Arthur; Curtis; Gloria; Sharon
- **Equipment**: Battle
- **Spells**: Lit X
- **Abilities**: Dk-Virus

## Characters

- **Agron** (Boss) - Class: None; Element: None; Barrier Machine Cave boss in the underworld segment.
- **Arthur** (Main Character) - Class: Human; Element: Fire; Starts as a Human with innate Fire element.
- **Ashura** (Boss) - Class: None; Element: None; South Tower boss in the present timeline.
- **Balor** (Boss) - Class: None; Element: None; Goht Castle boss on the path to Sol.
- **Chaos** (Boss) - Class: None; Element: None; Castle of Chaos boss and major difficulty spike.
- **Chronos** (NPC) - Class: None; Element: None; Key time-travel NPC who grants progression items.
- **Curtis** (Main Character) - Class: Mutant; Element: Air; Starts as a Mutant with innate Air element.
- **Dahak** (Boss) - Class: None; Element: None; Southwest Ruins boss.
- **Darius** (NPC) - Class: None; Element: None; Pureland story NPC tied to city progression.
- **Dion** (NPC Ally) - Class: None; Element: None; Late temporary ally recruited in Viper City.
- **Dogra** (Boss) - Class: None; Element: None; Boss fought after Lara joins in the southern cave arc.
- **Dr. Belksi** (NPC) - Class: None; Element: None; Future-era base NPC used for healing and route setup.
- **Dr. Pulcer** (NPC) - Class: None; Element: None; Scientist NPC tied to Talon communication and undersea base progression.
- **Fenrir** (Boss) - Class: None; Element: None; Eitar Prison boss in Pureland progression.
- **Gloria** (Main Character) - Class: Mutant; Element: Water; Starts as a Mutant with innate Water element.
- **Granny** (NPC) - Class: None; Element: None; Recurring NPC who supplies key travel spells.
- **Guha** (Boss) - Class: None; Element: None; Mount Hasid boss.
- **Jorgandr** (Boss) - Class: None; Element: None; Frost Cape boss before Talonsburg.
- **Lara** (NPC Ally) - Class: None; Element: None; Temporary ally through the southern cave and Dogra sequence.
- **Maitreya** (Boss) - Class: None; Element: None; Floatland tower boss guarding the X-Plane unit.
- **Myron** (NPC Ally) - Class: None; Element: None; Early guest ally and route-stable healer in the opening sequence.
- **Sharon** (Main Character) - Class: Human; Element: Earth; Starts as a Human with innate Earth element.
- **Sol** (Boss) - Class: None; Element: None; Late-game boss in the final approach.
- **Water Hag** (Boss) - Class: None; Element: None; Early boss encountered near Talon Shrine.
- **Xagor** (Final Boss) - Class: None; Element: None; Final boss fought with Sol in the endgame section.

## Equipment

- **Aegis** [Armor / Shields] - Cost: -; Def: 7; Evd: 14; MDef: 13; MEvd: 13; Cyb HP+: 150; Resist: OChange, OStone; Bonus: +5 Agility; Walkthrough availability: FINAL PREP BEFORE MOUNT GOHT; OPTIONAL SIDE QUESTING; Walkthrough notes: Crafted or mixed during the walkthrough.
- **Armlet** [Armor / Other] - Cost: -; Def: 2; Evd: 2; MDef: 14; MEvd: 14; Cyb HP+: 150; Resist: OFatal; Item Magic: Fatal
- **Bangle** [Armor / Other] - Cost: 18000; Def: 1; Evd: 1; MDef: 14; MEvd: 14; Cyb HP+: 140; Resist: OMute; Item Magic: -; Walkthrough availability: FINAL PREP BEFORE MOUNT GOHT; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Battle** [Armor / Armor] - Cost: -; Def: 10; Evd: 11; MDef: 9; MEvd: 10; Cyb HP+: 100; Resist: -; Bonus: +5 Attack; Walkthrough availability: ASHURA BOSS FIGHT; DHARM CITY; DOGRA BOSS FIGHT; LEAVING CHAOS CASTLE; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Belt** [Armor / Other] - Cost: 100; Def: 1; Evd: 1; MDef: 3; MEvd: 2; Cyb HP+: 20; Resist: -; Item Magic: -
- **Bronze** [Armor / Shields] - Cost: 700; Def: 2; Evd: 2; MDef: 2; MEvd: 2; Cyb HP+: 30; Resist: -
- **Bronze** [Armor / Helmets] - Cost: 400; Def: 2; Evd: 2; MDef: 2; MEvd: 1; Cyb HP+: 30; Resist: -; Item Magic: -
- **Bronze** [Armor / Armor] - Cost: 700; Def: 3; Evd: 3; MDef: 2; MEvd: 3; Cyb HP+: 30; Resist: -
- **Bronze** [Armor / Gloves] - Cost: 400; Def: 2; Evd: 2; MDef: 1; MEvd: 1; Cyb MP+: 30; Resist: -
- **Bronze** [Armor / Shoes] - Cost: 500; Def: 2; Evd: 2; MDef: 2; MEvd: 2; Cyb MP+: 30; Resist: -
- **Brooch** [Armor / Other] - Cost: 1600; Def: 1; Evd: 1; MDef: 8; MEvd: 8; Cyb HP+: 70; Resist: OPoison; Item Magic: -
- **Cool** [Armor / Other] - Cost: -; Def: 1; Evd: 1; MDef: 10; MEvd: 10; Cyb HP+: 100; Resist: OFire; Item Magic: Ice2; Walkthrough availability: MOUNT HASID; Walkthrough notes: Crafted or mixed during the walkthrough.
- **Diamond** [Armor / Shields] - Cost: 8500; Def: 5; Evd: 10; MDef: 10; MEvd: 11; Cyb HP+: 100; Resist: OThunder; Walkthrough availability: FENRIR BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Diamond** [Armor / Helmets] - Cost: 8500; Def: 8; Evd: 10; MDef: 10; MEvd: 11; Cyb HP+: 110; Resist: OThunder; Item Magic: -; Walkthrough availability: FENRIR BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Diamond** [Armor / Armor] - Cost: 8500; Def: 11; Evd: 11; MDef: 10; MEvd: 12; Cyb HP+: 110; Resist: OThunder; Walkthrough availability: FENRIR BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Diamond** [Armor / Gloves] - Cost: 8500; Def: 7; Evd: 8; MDef: 7; MEvd: 6; Cyb MP+: 120; Resist: OThunder; Walkthrough availability: FENRIR BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Diamond** [Armor / Shoes] - Cost: 5500; Def: 7; Evd: 8; MDef: 8; MEvd: 8; Cyb MP+: 140; Resist: OThunder; Walkthrough availability: FENRIR BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Dragon** [Armor / Shields] - Cost: 3400; Def: 4; Evd: 7; MDef: 7; MEvd: 8; Cyb HP+: 70; Resist: -; Walkthrough availability: LEAVING CHAOS CASTLE; RETURN TO MUU (PRESENT); Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Dragon** [Armor / Helmets] - Cost: 2400; Def: 6; Evd: 6; MDef: 6; MEvd: 7; Cyb HP+: 70; Resist: -; Item Magic: -; Walkthrough availability: LEAVING CHAOS CASTLE; RETURN TO MUU (PRESENT); Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Dragon** [Armor / Armor] - Cost: 3400; Def: 6; Evd: 6; MDef: 6; MEvd: 7; Cyb HP+: 70; Resist: -; Walkthrough availability: LEAVING CHAOS CASTLE; RETURN TO MUU (PRESENT); Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Dragon** [Armor / Gloves] - Cost: 2400; Def: 5; Evd: 5; MDef: 4; MEvd: 4; Cyb MP+: 70; Resist: -; Walkthrough availability: LEAVING CHAOS CASTLE; RETURN TO MUU (PRESENT); Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Dragon** [Armor / Shoes] - Cost: 3400; Def: 6; Evd: 7; MDef: 7; MEvd: 7; Cyb MP+: 90; Resist: -; Bonus: +5 Magic; Walkthrough availability: LEAVING CHAOS CASTLE; RETURN TO MUU (PRESENT); Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Earring** [Armor / Other] - Cost: 5500; Def: 1; Evd: 1; MDef: 10; MEvd: 9; Cyb HP+: 80; Resist: OPara; Item Magic: -
- **Fire** [Armor / Shields] - Cost: -; Def: 3; Evd: 6; MDef: 7; MEvd: 8; Cyb HP+: 60; Resist: OIce; Walkthrough availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; SOUTHWEST RUINS; Walkthrough notes: Crafted or mixed during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Fur** [Armor / Armor] - Cost: -; Def: 8; Evd: 8; MDef: 9; MEvd: 9; Cyb HP+: 50; Resist: OPara; Walkthrough availability: FENRIR BOSS FIGHT; TO EITAR PRISON; Walkthrough notes: Crafted or mixed during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Geta** [Armor / Shoes] - Cost: 2400; Def: 5; Evd: 6; MDef: 6; MEvd: 7; Cyb MP+: 100; Resist: -; Bonus: +5 Agility; Walkthrough availability: TO NEW DHARM/VIPER CITY; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Gold** [Armor / Shields] - Cost: 1700; Def: 3; Evd: 5; MDef: 5; MEvd: 4; Cyb HP+: 50; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Gold** [Armor / Helmets] - Cost: 1700; Def: 4; Evd: 5; MDef: 3; MEvd: 3; Cyb HP+: 50; Resist: -; Item Magic: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Gold** [Armor / Armor] - Cost: 2400; Def: 5; Evd: 6; MDef: 4; MEvd: 7; Cyb HP+: 50; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Gold** [Armor / Gloves] - Cost: 1700; Def: 4; Evd: 4; MDef: 3; MEvd: 3; Cyb MP+: 50; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Gold** [Armor / Shoes] - Cost: 1700; Def: 4; Evd: 5; MDef: 4; MEvd: 4; Cyb MP+: 70; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Hecate** [Armor / Helmets] - Cost: 25000; Def: 9; Evd: 11; MDef: 15; MEvd: 15; Cyb HP+: 150; Resist: -; Item Magic: -; Bonus: +5 Magic
- **Hecate** [Armor / Shoes] - Cost: 13000; Def: 8; Evd: 9; MDef: 9; MEvd: 10; Cyb MP+: 130; Resist: OMute
- **Hermes** [Armor / Shoes] - Cost: 18000; Def: 9; Evd: 9; MDef: 15; MEvd: 15; Cyb MP+: 150; Resist: -; Bonus: +5 Agility
- **Ice** [Armor / Shields] - Cost: -; Def: 4; Evd: 7; MDef: 8; MEvd: 9; Cyb HP+: 60; Resist: OFire; Walkthrough availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Iron** [Armor / Gloves] - Cost: 4000; Def: 6; Evd: 7; MDef: 5; MEvd: 5; Cyb MP+: 100; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Iron** [Armor / Shoes] - Cost: 1100; Def: 3; Evd: 3; MDef: 3; MEvd: 2; Cyb MP+: 50; Resist: -; Walkthrough availability: MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Leather** [Armor / Helmets] - Cost: 50; Def: 1; Evd: 1; MDef: 1; MEvd: 1; Cyb HP+: 10; Resist: -; Item Magic: -; Walkthrough availability: DHARM CITY; LEAVING DHARM/NORTH TOWER; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Leather** [Armor / Armor] - Cost: 200; Def: 2; Evd: 2; MDef: 2; MEvd: 2; Cyb HP+: 10; Resist: -; Walkthrough availability: DHARM CITY; LEAVING DHARM/NORTH TOWER; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Leather** [Armor / Gloves] - Cost: -; Def: 1; Evd: 1; MDef: 1; MEvd: 1; Cyb MP+: 10; Resist: -; Walkthrough availability: DHARM CITY; LEAVING DHARM/NORTH TOWER; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Leather** [Armor / Shoes] - Cost: 50; Def: 1; Evd: 1; MDef: 1; MEvd: 1; Cyb MP+: 10; Resist: -; Walkthrough availability: DHARM CITY; LEAVING DHARM/NORTH TOWER; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Light** [Armor / Armor] - Cost: 25000; Def: 17; Evd: 12; MDef: 15; MEvd: 15; Cyb HP+: 150; Resist: -; Walkthrough availability: MOUNT HASID; OPTIONAL SIDE QUESTING; RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Crafted or mixed during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Mage** [Armor / Armor] - Cost: 2600; Def: 5; Evd: 6; MDef: 6; MEvd: 7; Cyb HP+: 40; Resist: OConfuse
- **Mirror** [Armor / Shields] - Cost: 13000; Def: 6; Evd: 12; MDef: 11; MEvd: 13; Cyb HP+: 120; Resist: OMute
- **Mirror** [Armor / Helmets] - Cost: 13000; Def: 8; Evd: 12; MDef: 11; MEvd: 13; Cyb HP+: 130; Resist: OMute; Item Magic: -
- **Mirror** [Armor / Armor] - Cost: 13000; Def: 12; Evd: 13; MDef: 12; MEvd: 13; Cyb HP+: 120; Resist: OMute
- **Mirror** [Armor / Gloves] - Cost: -; Def: 8; Evd: 9; MDef: 9; MEvd: 9; Cyb MP+: 140; Resist: OMute
- **Pendant** [Armor / Other] - Cost: 700; Def: 1; Evd: 1; MDef: 7; MEvd: 6; Cyb HP+: 50; Resist: OCurse; Item Magic: -; Walkthrough availability: MUU CITY (PAST); TO SOUTHERN CAVE; Walkthrough notes: Possible enemy drop noted in the walkthrough.; Purchased or restocked during the walkthrough.
- **Plume** [Armor / Other] - Cost: 500; Def: 1; Evd: 1; MDef: 3; MEvd: 4; Cyb HP+: 30; Resist: OSleep; Item Magic: -; Walkthrough availability: ELAN CITY; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Power** [Armor / Armor] - Cost: 25000; Def: 15; Evd: 15; MDef: 12; MEvd: 12; Cyb HP+: 140; Resist: -; Bonus: +5 Attack, +5 Agility; Walkthrough availability: BEFORE GOING INTO THE UNDERWORLD; DWELG TOWN; FINAL PREP BEFORE MOUNT GOHT; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Power** [Armor / Gloves] - Cost: 18000; Def: 9; Evd: 9; MDef: 15; MEvd: 15; Cyb MP+: 150; Resist: -; Bonus: +5 Attack; Walkthrough availability: BEFORE GOING INTO THE UNDERWORLD; DWELG TOWN; FINAL PREP BEFORE MOUNT GOHT; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Psi** [Armor / Armor] - Cost: -; Def: 7; Evd: 7; MDef: 6; MEvd: 8; Cyb HP+: 100; Resist: -; Bonus: +5 Agility; Walkthrough availability: ELAN CITY; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Ribbon** [Armor / Other] - Cost: -; Def: 2; Evd: 2; MDef: 15; MEvd: 15; Cyb HP+: 150; Resist: OAll; Item Magic: -; Bonus: +5 Magic; Walkthrough availability: GOHT CASTLE; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Samurai** [Armor / Shields] - Cost: 18000; Def: 6; Evd: 14; MDef: 12; MEvd: 12; Cyb HP+: 130; Resist: OStone
- **Samurai** [Armor / Helmets] - Cost: 18000; Def: 9; Evd: 13; MDef: 12; MEvd: 12; Cyb HP+: 150; Resist: OStone; Item Magic: -
- **Samurai** [Armor / Armor] - Cost: 18000; Def: 13; Evd: 14; MDef: 13; MEvd: 12; Cyb HP+: 130; Resist: OStone
- **Samurai** [Armor / Gloves] - Cost: 18000; Def: 9; Evd: 10; MDef: 11; MEvd: 10; Cyb MP+: 150; Resist: OStone
- **SandMan** [Armor / Helmets] - Cost: -; Def: 5; Evd: 15; MDef: 6; MEvd: 15; Cyb HP+: 60; Resist: -; Item Magic: Sleep
- **Scarf** [Armor / Other] - Cost: 8500; Def: 1; Evd: 1; MDef: 12; MEvd: 13; Cyb HP+: 130; Resist: OStone; Item Magic: -
- **Shades** [Armor / Other] - Cost: 3400; Def: 1; Evd: 1; MDef: 9; MEvd: 10; Cyb HP+: 110; Resist: OBlind; Item Magic: -
- **Silver** [Armor / Shields] - Cost: 1300; Def: 2; Evd: 4; MDef: 4; MEvd: 3; Cyb HP+: 40; Resist: -; Walkthrough availability: RETURN TO MUU (PRESENT); TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Silver** [Armor / Helmets] - Cost: 1100; Def: 3; Evd: 3; MDef: 3; MEvd: 2; Cyb HP+: 40; Resist: -; Item Magic: -; Walkthrough availability: RETURN TO MUU (PRESENT); TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Silver** [Armor / Armor] - Cost: 1300; Def: 4; Evd: 4; MDef: 3; MEvd: 5; Cyb HP+: 40; Resist: -; Walkthrough availability: RETURN TO MUU (PRESENT); TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Silver** [Armor / Gloves] - Cost: 1100; Def: 3; Evd: 3; MDef: 2; MEvd: 3; Cyb MP+: 40; Resist: -; Walkthrough availability: RETURN TO MUU (PRESENT); TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Speed** [Armor / Shields] - Cost: -; Def: 7; Evd: 15; MDef: 15; MEvd: 15; Cyb HP+: 150; Resist: -; Bonus: +5 Agility; Walkthrough availability: FLOATLAND ARRIVAL; OPTIONAL SIDE QUESTING; PREPARING FOR THE UNDERWORLD; RETURN TO MUU (FUTURE); SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Speed** [Armor / Helmets] - Cost: 4000; Def: 6; Evd: 7; MDef: 8; MEvd: 8; Cyb HP+: 100; Resist: -; Item Magic: -; Bonus: +5 Agility; Walkthrough availability: FLOATLAND ARRIVAL; OPTIONAL SIDE QUESTING; PREPARING FOR THE UNDERWORLD; RETURN TO MUU (FUTURE); SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Speed** [Armor / Armor] - Cost: 5500; Def: 9; Evd: 9; MDef: 8; MEvd: 8; Cyb HP+: 130; Resist: -; Bonus: +5 Agility; Walkthrough availability: FLOATLAND ARRIVAL; OPTIONAL SIDE QUESTING; PREPARING FOR THE UNDERWORLD; RETURN TO MUU (FUTURE); SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Speed** [Armor / Shoes] - Cost: 5500; Def: 9; Evd: 10; MDef: 10; MEvd: 11; Cyb MP+: 150; Resist: -; Bonus: +5 Agility; Walkthrough availability: FLOATLAND ARRIVAL; OPTIONAL SIDE QUESTING; PREPARING FOR THE UNDERWORLD; RETURN TO MUU (FUTURE); SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **Warm** [Armor / Other] - Cost: -; Def: 1; Evd: 1; MDef: 12; MEvd: 13; Cyb HP+: 120; Resist: OIce; Item Magic: Fire2; Walkthrough availability: BEFORE GOING INTO THE UNDERWORLD; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Wizard** [Armor / Armor] - Cost: 18000; Def: 11; Evd: 11; MDef: 13; MEvd: 14; Cyb HP+: 100; Resist: -; Bonus: +5 Magic; Walkthrough availability: TO EITAR PRISON; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **X-Plane** [Armor / Shields] - Cost: 5500; Def: 5; Evd: 9; MDef: 8; MEvd: 9; Cyb HP+: 90; Resist: -; Walkthrough availability: FLOATLAND ARRIVAL; MAITREYA BOSS FIGHT; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; Purchased or restocked during the walkthrough.
- **X-Plane** [Armor / Helmets] - Cost: 5500; Def: 7; Evd: 9; MDef: 8; MEvd: 9; Cyb HP+: 90; Resist: -; Item Magic: -; Walkthrough availability: FLOATLAND ARRIVAL; MAITREYA BOSS FIGHT; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; Purchased or restocked during the walkthrough.
- **Adamant knife** [Weapons / Melee Weapons / Normal] - Cost: 3400; WP: 50; Cyb HP+: 80; Property: Ice; Item/Other: Ice1; Bonus: +5 Magic
- **ATM** [Weapons / Fixed Damage Weapons / Cannons] - Cost: 5500; WP: 70; Cyb HP+: 110; Target: S/G; Property: Damage
- **B-Jack whip** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 46; Cyb HP+: 70; Property: Damage; Item/Other: -
- **Battle axe** [Weapons / Melee Weapons / Normal] - Cost: 500; WP: 20; Cyb HP+: 10; Property: Damage; Item/Other: -
- **Battle hammer** [Weapons / Melee Weapons / Normal] - Cost: 100; WP: 7; Cyb HP+: 10; Property: Damage; Item/Other: -
- **Battle sword** [Weapons / Melee Weapons / Normal] - Cost: 400; WP: 15; Cyb HP+: 20; Property: Damage; Item/Other: -
- **Blitz** [Weapons / Fixed Damage Weapons / Cripplers] - Cost: 1700; WP: 10; Cyb HP+: 60; Target: S; Property: Damage; Bonus: Reduce target stats
- **Boomrng** [Weapons / Missile Weapons / Throwing] - Cost: 2400; WP: 40; Cyb HP+: 70; Property: Damage
- **Bronze staff** [Weapons / Melee Weapons / Normal] - Cost: 50; WP: 6; Cyb HP+: 20; Property: Damage; Item/Other: -
- **CatClaw** [Weapons / Melee Weapons / Normal] - Cost: 2400; WP: 45; Cyb HP+: 70; Property: Poison; Item/Other: Venom; Bonus: +5 Agility
- **Defense sword 25000** [Weapons / Melee Weapons / Normal] - Cost: 190; WP: 140; Cyb HP+: Damage; Property: -; Item/Other: +5 Att, +5 Def, +5 Agi, +5 Mag
- **Dragon sword** [Weapons / Melee Weapons / Normal] - Cost: 5500; WP: 70; Cyb HP+: 100; Property: -; Item/Other: -
- **Drain sword** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 60; Cyb HP+: 110; Property: Drain; Item/Other: -
- **Durend sword** [Weapons / Melee Weapons / Mystic Swords] - Cost: -; Walkthrough availability: GUHA BOSS FIGHT; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; WP: 90; Cyb HP+: 110; Property: Mystic
- **Elven bow** [Weapons / Missile Weapons / Bows] - Cost: 13000; WP: 100; Cyb HP+: 120; Property: Tornado
- **Emperor sword** [Weapons / Melee Weapons / Mystic Swords] - Cost: -; WP: 75; Cyb HP+: 130; Property: Mystic
- **Fast staff** [Weapons / Melee Weapons / Normal] - Cost: 4000; WP: 60; Cyb HP+: 120; Property: Damage; Item/Other: Ice2; Bonus: *; +5 Magic
- **Fire** [Weapons / Fixed Damage Weapons / Guns] - Cost: -; Walkthrough availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; SOUTHWEST RUINS; Walkthrough notes: Crafted or mixed during the walkthrough.; Treasure or route pickup from the walkthrough.; WP: 30; Cyb HP+: 70; Target: S/G; Property: Fire
- **Fire staff** [Weapons / Melee Weapons / Normal] - Cost: 500; WP: 15; Cyb HP+: 50; Property: Damage; Item/Other: Fire1
- **Gold bow** [Weapons / Missile Weapons / Bows] - Cost: 700; WP: 25; Cyb HP+: 50; Property: Damage
- **Gold nunchuck** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 48; Cyb HP+: 70; Property: Damage; Item/Other: -
- **Gold staff** [Weapons / Melee Weapons / Normal] - Cost: 400; WP: 10; Cyb HP+: 30; Property: Damage; Item/Other: -
- **Gold sword** [Weapons / Melee Weapons / Normal] - Cost: 1100; WP: 35; Cyb HP+: 50; Property: Damage; Item/Other: -
- **Grenade** [Weapons / Fixed Damage Weapons / Bombs] - Cost: 1100; WP: 30; Cyb HP+: 50; Target: S/G; Property: Damage
- **Gungnir spear 18000** [Weapons / Melee Weapons / Normal] - Cost: 160; WP: 130; Cyb HP+: Damage; Property: -
- **Headbut** [Weapons / Martial Arts] - Cost: 2400; WP: 7; Cyb HP+: 60; Property: Damage
- **Iron nunchuck** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 23; Cyb HP+: 30; Property: Damage; Item/Other: -
- **Jyudo** [Weapons / Martial Arts] - Cost: 25000; WP: 11; Cyb HP+: 120; Property: Damage
- **Karate** [Weapons / Martial Arts] - Cost: 28000; WP: 12; Cyb HP+: 140; Property: Damage
- **Kick** [Weapons / Martial Arts] - Cost: 1700; WP: 6; Cyb HP+: 50; Property: Damage
- **Kneebut** [Weapons / Martial Arts] - Cost: 13000; WP: 10; Cyb HP+: 110; Property: Damage
- **Laser** [Weapons / Fixed Damage Weapons / Guns] - Cost: 13000; Walkthrough availability: TO CIRRUS THE CLOUD CITY; TO NEW DHARM/VIPER CITY; Walkthrough notes: Treasure or route pickup from the walkthrough.; WP: 90; Cyb HP+: 120; Target: S/G; Property: Damage
- **Laser** [Weapons / Fixed Damage Weapons / Cannons] - Cost: 18000; Walkthrough availability: TO CIRRUS THE CLOUD CITY; TO NEW DHARM/VIPER CITY; Walkthrough notes: Treasure or route pickup from the walkthrough.; WP: 90; Cyb HP+: 140; Target: S/G; Property: Damage
- **Laser sword** [Weapons / Melee Weapons / Normal] - Cost: 2400; Walkthrough availability: TO NEW DHARM/VIPER CITY; Walkthrough notes: Treasure or route pickup from the walkthrough.; WP: 50; Cyb HP+: 70; Property: Damage; Item/Other: -
- **Long bow** [Weapons / Missile Weapons / Bows] - Cost: 100; WP: 7; Cyb HP+: 10; Property: Damage
- **Long sword** [Weapons / Melee Weapons / Normal] - Cost: 200; WP: 10; Cyb HP+: 10; Property: Damage; Item/Other: -
- **Magnum** [Weapons / Fixed Damage Weapons / Guns] - Cost: -; WP: 40; Cyb HP+: 110; Target: S; Property: Damage
- **Masmune sword** [Weapons / Melee Weapons / Mystic Swords] - Cost: -; WP: 120; Cyb HP+: 140; Property: Mystic
- **Missile** [Weapons / Fixed Damage Weapons / Cannons] - Cost: 25000; Walkthrough availability: MOUNT HASID; Walkthrough notes: Crafted or mixed during the walkthrough.; WP: 100; Cyb HP+: 150; Target: S/G; Property: Damage
- **Muramas sword** [Weapons / Melee Weapons / Mystic Swords] - Cost: -; WP: 100; Cyb HP+: 140; Property: Mystic; Item/Other: Returns some damage; Uncurses->Masmune
- **Napalm** [Weapons / Fixed Damage Weapons / Bombs] - Cost: 500; WP: 10; Cyb HP+: 30; Target: S/G; Property: Fire
- **Ninja** [Weapons / Missile Weapons / Throwing] - Cost: -; WP: 220; Cyb HP+: 150; Property: Damage
- **Nuke** [Weapons / Fixed Damage Weapons / Multibombs] - Cost: 50000; WP: 250; Cyb HP+: 250; Target: All; Property: Damage
- **Para axe** [Weapons / Melee Weapons / Normal] - Cost: 18000; WP: 150; Cyb HP+: 130; Property: Para; Item/Other: Para; Bonus: +5 Attack, +5 Magic
- **Petrify hammer** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 100; Cyb HP+: 110; Property: Stone; Item/Other: -
- **Poison** [Weapons / Fixed Damage Weapons / Guns] - Cost: 8500; WP: 30; Cyb HP+: 110; Target: S; Property: Poison; Bonus: **
- **Poison claw** [Weapons / Melee Weapons / Normal] - Cost: 18000; WP: 140; Cyb HP+: 130; Property: Poison; Item/Other: Venom; Bonus: +5 Agility, +5 Magic
- **Psi** [Weapons / Fixed Damage Weapons / Guns] - Cost: 5500; Walkthrough availability: ELAN CITY; Walkthrough notes: Purchased or restocked during the walkthrough.; WP: 50; Cyb HP+: 100; Target: S/G; Property: Damage; Bonus: **; +5 Magic
- **Psi knife** [Weapons / Melee Weapons / Normal] - Cost: 600; WP: 17; Cyb HP+: 30; Property: Damage; Item/Other: -; Bonus: *; +5 Agility
- **Psi sword** [Weapons / Melee Weapons / Normal] - Cost: 3400; WP: 55; Cyb HP+: 90; Property: Damage; Item/Other: -; Bonus: *
- **Punch** [Weapons / Martial Arts] - Cost: 700; WP: 5; Cyb HP+: 30; Property: Damage
- **Razor whip** [Weapons / Melee Weapons / Normal] - Cost: 700; WP: 27; Cyb HP+: 30; Property: Damage; Item/Other: -; Bonus: 2 hits at 1/2 damage
- **Rune axe** [Weapons / Melee Weapons / Normal] - Cost: 13000; WP: 100; Cyb HP+: 120; Property: Damage; Item/Other: -; Bonus: +5 Attack
- **Samurai bow** [Weapons / Missile Weapons / Bows] - Cost: -; WP: 170; Cyb HP+: 140; Property: -
- **Saw** [Weapons / Fixed Damage Weapons / Cripplers] - Cost: 18000; WP: 35; Cyb HP+: 130; Target: S; Property: Damage; Bonus: Reduce target stats
- **Silver sword** [Weapons / Melee Weapons / Normal] - Cost: 700; WP: 25; Cyb HP+: 40; Property: Damage; Item/Other: -
- **SMG** [Weapons / Fixed Damage Weapons / Guns] - Cost: 3400; WP: 40; Cyb HP+: 80; Target: S/G; Property: Damage
- **Smother** [Weapons / Martial Arts] - Cost: 8500; WP: 9; Cyb HP+: 100; Property: Damage
- **Star** [Weapons / Fixed Damage Weapons / Multibombs] - Cost: 5500; WP: 60; Cyb HP+: 110; Target: All; Property: Blind
- **Sun sword** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 90; Cyb HP+: 120; Property: Holy; Item/Other: -
- **TearGas** [Weapons / Fixed Damage Weapons / Multibombs] - Cost: 1700; WP: 60; Cyb HP+: 110; Target: All; Property: Para
- **Thunder staff** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 22; Cyb HP+: 60; Property: Thunder; Item/Other: Lit1
- **TNT** [Weapons / Fixed Damage Weapons / Bombs] - Cost: 1700; Walkthrough availability: ASHURA BOSS FIGHT; Walkthrough notes: Treasure or route pickup from the walkthrough.; WP: 40; Cyb HP+: 60; Target: S/G; Property: Damage
- **Tomhawk axe** [Weapons / Melee Weapons / Normal] - Cost: 1700; WP: 45; Cyb HP+: 60; Property: Damage; Item/Other: -
- **Vulkan** [Weapons / Fixed Damage Weapons / Cannons] - Cost: 8500; WP: 80; Cyb HP+: 120; Target: S/G; Property: Damage
- **Wall staff** [Weapons / Melee Weapons / Normal] - Cost: 18000; WP: 140; Cyb HP+: 150; Property: Damage; Item/Other: Stone; Bonus: +5 Def, +5 Agi, +5 Mag
- **White spear** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 130; Cyb HP+: 120; Property: Holy; Item/Other: -
- **X-Fire staff** [Weapons / Melee Weapons / Normal] - Cost: -; WP: 60; Cyb HP+: 110; Property: Damage; Item/Other: Erase; Bonus: *; +5 Agility, +5 Magic
- **X-Kick** [Weapons / Martial Arts] - Cost: 5500; WP: 8; Cyb HP+: 90; Property: Damage
- **X-Plane staff** [Weapons / Melee Weapons / Normal] - Cost: 1100; WP: 20; Cyb HP+: 70; Property: Damage; Item/Other: Aero
- **X-Plane sword** [Weapons / Melee Weapons / Normal] - Cost: 4000; WP: 65; Cyb HP+: 90; Property: Damage; Item/Other: -
- **Xcalibr sword** [Weapons / Melee Weapons / Mystic Swords] - Cost: -; WP: 170; Cyb HP+: 150; Property: Mystic

## Items

- **Air Crystal** [Crystal] - Availability: RETURN TO MUU (PRESENT); SOUTH TOWER; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **B-jack** [Tool] - Availability: ASHURA BOSS FIGHT; CHAOS BOSS BATTLE; RETURN TO MUU (PRESENT); SOUTH TOWER; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Catnip** [Tool] - Availability: TO EITAR PRISON; TO EITAR VILLAGE; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Cure1 Potion** [Consumable] - Availability: DOGRA BOSS FIGHT; TO SOUTHERN CAVE; TO THE PAST; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.
- **Cure2 Potion** [Consumable] - Availability: ASHURA BOSS FIGHT; CHAOS BOSS BATTLE; MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.
- **Dark Crystal** [Crystal] - Availability: BARRIER MACHINE CAVE; OPTIONAL SIDE QUESTING; PLUNDERING CAVES; RETURN TO EITAR VILLAGE/DARIUS; SPEED SHIELDS AND CURE B SPELLS; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Elixir** [Consumable] - Availability: AGRON BOSS FIGHT; BALOR BOSS FIGHT; CHAOS BOSS BATTLE; DAHAK BOSS FIGHT; FINAL PREP BEFORE MOUNT GOHT; GUHA BOSS FIGHT; MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; SOL/XAGOR FINAL BOSS; THE FUTURE AWAITS; TO NEW DHARM/VIPER CITY; TO SOUTHWEST RUINS; TO THE FROST CAPE; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.
- **Fire Crystal** [Crystal] - Availability: FINAL PREP BEFORE MOUNT GOHT; RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; SOUTHWEST RUINS; Notes: NPC reward or story gift from the walkthrough.; Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Firestar** [Key Item] - Availability: PURELAND ARRIVAL; Notes: Referenced in walkthrough progression.
- **Flushex Unit** [Talon Unit] - Availability: TO THE PAST; Notes: Purchased or restocked during the walkthrough.
- **Future Unit** [Talon Unit] - Availability: LEAVING CHAOS CASTLE; Notes: Boss reward or progression item from the walkthrough.
- **Hover Unit** [Talon Unit] - Availability: LEAVING CHAOS CASTLE; Notes: Boss reward or progression item from the walkthrough.
- **Laser Unit** [Talon Unit] - Availability: PREPARING FOR THE UNDERWORLD; SPEED SHIELDS AND CURE B SPELLS; TO CIRRUS THE CLOUD CITY; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Light Crystal** [Crystal] - Availability: BARRIER MACHINE CAVE; MOUNT HASID; OPTIONAL SIDE QUESTING; PLUNDERING CAVES; RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; SPEED SHIELDS AND CURE B SPELLS; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Missile Unit** [Talon Unit] - Availability: MOUNT HASID; Notes: Treasure or route pickup from the walkthrough.
- **Past Unit** [Talon Unit] - Availability: ELAN CITY; TO THE PAST; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Prison Key** [Key Item] - Availability: FENRIR BOSS FIGHT; Notes: Boss reward or progression item from the walkthrough.
- **Radio** [Key Item] - Availability: MAITREYA BOSS FIGHT; TO NEW DHARM/VIPER CITY; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Remote** [Key Item] - Availability: FINAL PREP BEFORE MOUNT GOHT; MAITREYA BOSS FIGHT; RETURN TO EITAR VILLAGE/DARIUS; TO EITAR PRISON; TO EITAR VILLAGE; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.
- **Rocket** [Key Item] - Availability: TO NEW DHARM/VIPER CITY; Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Rover Unit** [Talon Unit] - Availability: DOGRA BOSS FIGHT; Notes: Treasure or route pickup from the walkthrough.
- **Shield Unit** [Talon Unit] - Availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; TALONSBURG; Notes: Referenced in walkthrough progression.
- **Soft** [Consumable] - Availability: AGRON BOSS FIGHT; CASTLE OF CHAOS; MUU CITY (PAST); PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; Notes: Purchased or restocked during the walkthrough.; Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **Tablet** [Key Item] - Availability: DAHAK BOSS FIGHT; TO THE FROST CAPE; Notes: Boss reward or progression item from the walkthrough.; Referenced in walkthrough progression.
- **Teargas** [Tool] - Availability: CHAOS BOSS BATTLE; RETURN TO MUU (PRESENT); Notes: Boss reward or progression item from the walkthrough.; Referenced in walkthrough progression.
- **Tower Key** [Key Item] - Availability: RETURN TO ELAN CITY (PRESENT); Notes: Treasure or route pickup from the walkthrough.
- **Water Crystal** [Crystal] - Availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; RETURN TO MUU (PRESENT); Notes: Referenced in walkthrough progression.; Treasure or route pickup from the walkthrough.
- **X-Plane Unit** [Talon Unit] - Availability: MAITREYA BOSS FIGHT; Notes: Boss reward or progression item from the walkthrough.

## Spells

- **Aero** [Attack Magic] - Cost: 700; MP: 12; SP: 26; Target: S; Property: Tornado; Walkthrough availability: TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Drain** [Attack Magic] - Cost: 18000; MP: 32; SP: 0; Target: S; Property: Drain
- **Fire1** [Attack Magic] - Cost: 700; MP: 12; SP: 26; Target: S; Property: Fire; Walkthrough availability: TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Fire2** [Attack Magic] - Cost: 5500; MP: 24; SP: 82; Target: S/G; Property: Fire; Walkthrough availability: PURELAND ARRIVAL; Walkthrough notes: Purchased or restocked during the walkthrough.
- **FireX** [Attack Magic] - Cost: -; MP: 32; SP: 100; Target: All; Property: Fire; Walkthrough availability: GUHA BOSS FIGHT; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Flare** [Attack Magic] - Cost: -; MP: 56; SP: 200; Target: All; Property: -; Walkthrough availability: FINAL PREP BEFORE MOUNT GOHT; RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; Walkthrough notes: Crafted or mixed during the walkthrough.
- **Flood** [Attack Magic] - Cost: -; MP: 16; SP: 60; Target: All; Property: Ice
- **Ice 1** [Attack Magic] - Cost: 400; MP: 8; SP: 18; Target: S; Property: Ice; Walkthrough availability: DHARM CITY; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Ice 2** [Attack Magic] - Cost: 3400; MP: 20; SP: 64; Target: S/G; Property: Ice; Walkthrough availability: RETURN TO MUU (FUTURE); Walkthrough notes: Purchased or restocked during the walkthrough.
- **Lit 1** [Attack Magic] - Cost: 1700; MP: 16; SP: 42; Target: S; Property: Thunder; Walkthrough availability: ASHURA BOSS FIGHT; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Lit 2** [Attack Magic] - Cost: 8500; MP: 28; SP: 130; Target: S/G; Property: Thunder; Walkthrough availability: KNAYA CITY, THE CENTER OF TRADE; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Lit X** [Attack Magic] - Cost: -; MP: 48; SP: 160; Target: All; Property: Thunder
- **Magma** [Attack Magic] - Cost: 25000; MP: 36; SP: 210; Target: S/G; Property: Quake
- **Nuke** [Attack Magic] - Cost: 25000; MP: 36; SP: 180; Target: All; Property: -
- **Quake** [Attack Magic] - Cost: 3400; MP: 20; SP: 30; Target: All; Property: Quake; Walkthrough availability: RETURN TO MUU (FUTURE); Walkthrough notes: Purchased or restocked during the walkthrough.
- **Shake** [Attack Magic] - Cost: -; MP: 40; SP: 130; Target: All; Property: Quake
- **Virus** [Attack Magic] - Cost: 18000; MP: 32; SP: 150; Target: S/G; Property: -
- **Weak** [Attack Magic] - Cost: 8500; MP: 28; SP: 130; Target: S/G; Property: Tornado; Walkthrough availability: JORGANDR BOSS FIGHT; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **White** [Attack Magic] - Cost: 25000; MP: 36; SP: 170; Target: All; Property: -; Walkthrough availability: SOL/XAGOR FINAL BOSS; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Wind** [Attack Magic] - Cost: -; MP: 24; SP: 160; Target: All; Property: Tornado
- **Conf** [Support Magic] - Cost: 1700; MP: 16; Target: A/E; Effect: Cures / afflicts Confuse
- **Cure1** [Support Magic] - Cost: 400; MP: 8; Target: E/A; Effect: Recovers 30% of HP / attacks undead; Walkthrough availability: TO THE PAST; Walkthrough notes: Purchased or restocked during the walkthrough.
- **Cure2** [Support Magic] - Cost: 1700; MP: 16; Target: E/A; Effect: Recovers 60% of HP / attacks undead; Walkthrough availability: PLUNDERING SUNKEN SHIPS AND OPTIMIZING ARMOR; RETURN TO MUU (PRESENT); Walkthrough notes: Purchased or restocked during the walkthrough.
- **Cure3** [Support Magic] - Cost: 5500; MP: 24; Target: E/A; Effect: Recovers 100% of HP / attacks undead; Walkthrough availability: DAHAK BOSS FIGHT; PURELAND ARRIVAL; Walkthrough notes: Crafted or mixed during the walkthrough.; Purchased or restocked during the walkthrough.
- **CureA** [Support Magic] - Cost: 10000; MP: 8; Target: E/A; Effect: Recovers 30% of HP / attacks undead (S/G); Walkthrough availability: KNAYA CITY, THE CENTER OF TRADE; Walkthrough notes: Purchased or restocked during the walkthrough.
- **CureB** [Support Magic] - Cost: 61800; MP: 24; Target: E/A; Effect: Recovers 60% of HP / attacks undead (S/G); Walkthrough availability: PREPARING FOR THE UNDERWORLD; SPEED SHIELDS AND CURE B SPELLS; Walkthrough notes: Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Cycle** [Support Magic] - Cost: -; MP: 32; Target: A/E; Effect: Cures status problems / afflicts two random statuses
- **Erase** [Support Magic] - Cost: 5500; MP: 24; Target: A/E; Effect: Returns stats to normal
- **Exit** [Support Magic] - Cost: 8500; MP: 28; Target: E; Effect: Escapes from dungeon / removes enemy; Walkthrough availability: MAITREYA BOSS FIGHT; PATH TO MAITREYA; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; Treasure or route pickup from the walkthrough.
- **Exit2** [Support Magic] - Cost: -; MP: 48; Target: E; Effect: Escapes from dungeon / removes enemy (S/G)
- **Fast** [Support Magic] - Cost: 5500; MP: 24; Target: A; Effect: Increases Attack +10
- **Fatal** [Support Magic] - Cost: 25000; MP: 36; Target: E; Effect: Kills non-undead
- **Heal** [Support Magic] - Cost: 8500; MP: 28; Target: A; Effect: Cures status problems; Walkthrough availability: DAHAK BOSS FIGHT; LEAVING CHAOS CASTLE; PURELAND ARRIVAL; SOL/XAGOR FINAL BOSS; TO NEW DHARM/VIPER CITY; TO THE FROST CAPE; Walkthrough notes: Boss reward or post-boss pickup from the walkthrough.; Purchased or restocked during the walkthrough.; Treasure or route pickup from the walkthrough.
- **Life** [Support Magic] - Cost: 18000; MP: 32; Target: A/E; Effect: Cures Fell with 30% HP / kills undead
- **LifeA** [Support Magic] - Cost: -; MP: 40; Target: A/E; Effect: Cures Fell with 60% HP / kills non-undead
- **LifeB** [Support Magic] - Cost: -; MP: 56; Target: A/E; Effect: Cures Fell with 100% HP / kills undead; Walkthrough availability: RECRUITING TALON CREW, LOST MAGIC AND XCALIBUR; Walkthrough notes: Crafted or mixed during the walkthrough.
- **Mute** [Support Magic] - Cost: 3400; MP: 20; Target: E; Effect: Afflicts Mute
- **Para** [Support Magic] - Cost: 1700; MP: 16; Target: A/E; Effect: Cures / afflicts Para; Walkthrough availability: LEAVING CHAOS CASTLE; Walkthrough notes: Possible enemy drop noted in the walkthrough.
- **Pure** [Support Magic] - Cost: 10000; MP: 8; Target: A/E; Effect: Cures / afflicts Curse
- **Shell** [Support Magic] - Cost: 400; MP: 8; Target: A; Effect: Increases Defense +10; Walkthrough availability: SOL/XAGOR FINAL BOSS; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Sleep** [Support Magic] - Cost: 400; MP: 8; Target: A/E; Effect: Cures / afflicts Sleep
- **Spark** [Support Magic] - Cost: 700; MP: 12; Target: A/E; Effect: Cures / afflicts Blind
- **Stone** [Support Magic] - Cost: 3400; MP: 20; Target: A/E; Effect: Cures / afflicts Stone
- **Venom** [Support Magic] - Cost: 700; MP: 12; Target: A/E; Effect: Cures / afflicts Poison
- **Wall** [Support Magic] - Cost: 18000; MP: 32; Target: A; Effect: Parry effect at double effectiveness (one round only)
- **Dive** [Travel Magic] - Cost: -; MP: 0; Effect: Allows travel over water and to the seafloor; Walkthrough availability: BACK TO ELAN CITY; TO NEW DHARM/VIPER CITY; Walkthrough notes: NPC reward or story gift from the walkthrough.; Treasure or route pickup from the walkthrough.
- **Float** [Travel Magic] - Cost: -; MP: 0; Effect: Allows travel over water; Walkthrough availability: LEAVING DHARM/NORTH TOWER; Walkthrough notes: Treasure or route pickup from the walkthrough.
- **Morph** [Travel Magic] - Cost: -; MP: 16; Effect: Disguises party as WaterHags or Dwelgs

## Abilities

- **2-Swords** [Other Active Talents] - TP: 10; Base: 0; Target: S; Property: Damage; Other: 2 hits at 1/2 damage
- **2-Tusks** [Other Active Talents] - TP: 4; Base: 40; Target: S; Property: Damage; Other: 2 hits at 1/2 damage
- **2-XKick** [Other Active Talents] - TP: 10; Base: 0; Target: S; Property: Damage; Other: 2 hits at 1/2 damage
- **3-Heads** [Other Active Talents] - TP: 6; Base: 45; Target: S; Property: Damage; Other: 3 hits at 1/3 damage
- **4-Heads** [Other Active Talents] - TP: 8; Base: 40; Target: S; Property: Damage; Other: 4 hits at 1/4 damage
- **6-Arms** [Other Active Talents] - TP: 12; Base: 30; Target: S; Property: Damage; Other: 6 hits at 1/6 damage
- **8-Legs** [Other Active Talents] - TP: 4; Base: 160; Target: S; Property: -
- **Absorb** [Other Active Talents] - TP: 4; Base: 10; Target: S; Property: Drain
- **Acid** [Other Active Talents] - TP: 4; Base: 30; Target: S; Property: -
- **Avenge** [Other Active Talents] - TP: 4; Base: 25; Target: S; Property: -; Other: Automatic counterattack
- **Barrier** [Other Active Talents] - TP: -; Base: -; Target: S; Property: -; Other: Effect unknown
- **Bash** [Other Active Talents] - TP: 8; Base: 0; Target: S; Property: -
- **Beak** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: -
- **Bite** [Other Active Talents] - TP: 5; Base: 0; Target: S; Property: Paralyze
- **Blind** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Blind
- **Blitz** [Other Active Talents] - TP: 0; Base: 100; Target: S; Property: -; Other: Reduces Agility by 10
- **Breath** [Other Active Talents] - TP: 3; Base: 0; Target: S; Property: Paralyze
- **Burning** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: Fire; Other: Automatic counterattack
- **Charm** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Confuse
- **Counter** [Other Active Talents] - TP: 4; Base: 25; Target: S; Property: -; Other: Automatic counterattack
- **Crash** [Other Active Talents] - TP: 7; Base: 0; Target: S; Property: -
- **CursSong** [Other Active Talents] - TP: -; Base: -; Target: S/G; Property: Curse
- **Cyclone** [Other Active Talents] - TP: 4; Base: 55; Target: All; Property: Tornado
- **D-Beam** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: Thunder
- **Decoy** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Confuse
- **Dispel** [Other Active Talents] - TP: 6; Base: 0; Target: S; Property: Fatal
- **Dissolv** [Other Active Talents] - TP: 4; Base: 10; Target: S; Property: Drain
- **Dive** [Other Active Talents] - TP: 8; Base: 0; Target: S; Property: -
- **Dk-Virus** [Other Active Talents] - TP: -; Base: -; Target: All; Property: -; Other: Afflicts two random statuses; not used
- **Drain** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: Drain
- **Explode** [Other Active Talents] - TP: 0; Base: *; Target: S; Property: -; Other: Damage dealt = Max HP; user dies
- **Fin** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: -
- **Flame** [Other Active Talents] - TP: 4; Base: 35; Target: S/G; Property: Fire
- **Flash** [Other Active Talents] - TP: -; Base: -; Target: All; Property: Blind
- **Frost** [Other Active Talents] - TP: 4; Base: 25; Target: S/G; Property: Ice
- **Gaze(1)** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Curse
- **Gaze(2)** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Paralyze
- **Glow** [Other Active Talents] - TP: 4; Base: 65; Target: All; Property: Fire
- **Headbut** [Other Active Talents] - TP: 6; Base: 0; Target: S; Property: -
- **Horn** [Other Active Talents] - TP: 4; Base: 25; Target: S; Property: -
- **Hypnosis** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Sleep
- **Ink** [Other Active Talents] - TP: -; Base: -; Target: S/G; Property: Blind
- **Kick** [Other Active Talents] - TP: 6; Base: 0; Target: S; Property: -
- **Knife** [Other Active Talents] - TP: 4; Base: 0; Target: S; Property: Sleep
- **Lullaby** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Sleep
- **Mute** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Mute
- **Nail** [Other Active Talents] - TP: 4; Base: 15; Target: S; Property: -
- **Numb** [Other Active Talents] - TP: 0; Base: 50; Target: S; Property: -; Other: Reduces Attack by 10
- **P-Blast** [Other Active Talents] - TP: 4; Base: 30; Target: S; Property: -
- **P-Skin** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Poison; Other: Automatic counterattack
- **Paralyze** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Paralyze
- **ParaNail** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Paralyze
- **ParaSkin** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Paralyze; Other: Automatic counterattack
- **Petrify** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Stone
- **Poison(1)** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Poison
- **Poison(2)** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Poison
- **Psych** [Other Active Talents] - TP: 0; Base: 50; Target: S; Property: -; Other: Reduces Magic by 10
- **Punch** [Other Active Talents] - TP: 5; Base: 0; Target: S; Property: -
- **Quake** [Other Active Talents] - TP: 4; Base: 30; Target: All; Property: Quake
- **Remedy(1)** [Other Active Talents] - TP: 0; Base: 30; Target: S; Property: -; Other: Recovers 30 HP for ally
- **Remedy(2)** [Other Active Talents] - TP: 0; Base: 50; Target: S; Property: -; Other: Recovers 50 HP for ally
- **Riddle** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Confuse
- **Sand** [Other Active Talents] - TP: 0; Base: 50; Target: S/G; Property: -; Other: Reduces Agility by 5
- **Scream** [Other Active Talents] - TP: 4; Base: 0; Target: S; Property: Confuse
- **Silence** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Mute
- **Sleep** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Sleep
- **SleepGas** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Sleep
- **Sneer** [Other Active Talents] - TP: 6; Base: 0; Target: S; Property: Confuse
- **Soften** [Other Active Talents] - TP: 0; Base: 100; Target: S; Property: -; Other: Reduces Defense by 15
- **Squirt** [Other Active Talents] - TP: 4; Base: 18; Target: S; Property: Ice
- **Stab** [Other Active Talents] - TP: 5; Base: 0; Target: S; Property: -
- **Steal** [Other Active Talents] - TP: -; Base: -; Target: S; Property: -; Other: Steals Gold equal to what the enemy drops*
- **Stench** [Other Active Talents] - TP: 0; Base: 50; Target: S/G; Property: -; Other: Reduces Defense by 10
- **StoneGas** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Stone
- **StonGaze** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Stone
- **StonSkin** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Stone; Other: Automatic counterattack
- **Storm** [Other Active Talents] - TP: 4; Base: 45; Target: S/G; Property: Tornado
- **Sunburst** [Other Active Talents] - TP: 4; Base: 25; Target: S; Property: Fire
- **Swallow** [Other Active Talents] - TP: 4; Base: 20; Target: S/G; Property: Drain; Other: Backfires on bosses
- **Tail** [Other Active Talents] - TP: 4; Base: 30; Target: S; Property: -
- **Tentacle** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: -
- **Thunder** [Other Active Talents] - TP: 4; Base: 65; Target: S; Property: Thunder
- **Tongue** [Other Active Talents] - TP: 4; Base: 17; Target: S; Property: -
- **Touch** [Other Active Talents] - TP: 4; Base: 20; Target: S; Property: Drain
- **Tusk** [Other Active Talents] - TP: 4; Base: 23; Target: S; Property: -
- **Upper** [Other Active Talents] - TP: 7; Base: 0; Target: S; Property: -
- **W-Attack** [Other Active Talents] - TP: 10; Base: 0; Target: S; Property: Damage; Other: 2 hits at 1/2 damage
- **Whirl** [Other Active Talents] - TP: 4; Base: 45; Target: All; Property: Ice
- **WindUp** [Other Active Talents] - TP: 7; Base: 0; Target: S; Property: -
- **X-Flash** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Fatal
- **X-Gaze** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Fatal
- **X-Heat** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Fatal
- **XPowder** [Other Active Talents] - TP: -; Base: -; Target: S; Property: Fatal
- **Multiply** [Passive Talents] - Effect: Monster duplicates when atacked. No effect on player's characters?
- **OAll** [Passive Talents] - Effect: Immune to all status ailments
- **OBlind** [Passive Talents] - Effect: Immune to Blind
- **OChange** [Passive Talents] - Effect: Strong against all elementals
- **OConfuse** [Passive Talents] - Effect: Immune to Confuse
- **OCurse** [Passive Talents] - Effect: Immune to Curse
- **ODamage** [Passive Talents] - Effect: Strong against physical damage
- **OFatal** [Passive Talents] - Effect: Immune to Fatal
- **OFire** [Passive Talents] - Effect: Strong against Fire
- **OIce** [Passive Talents] - Effect: Strong against Ice
- **OMute** [Passive Talents] - Effect: Immune to Mute
- **OPara** [Passive Talents] - Effect: Immune to Paralyze
- **OPoison** [Passive Talents] - Effect: Immune to Poison
- **OQuake** [Passive Talents] - Effect: Strong against Quake
- **OSleep** [Passive Talents] - Effect: Immune to Sleep
- **OStone** [Passive Talents] - Effect: Immune to Stone
- **OThunder** [Passive Talents] - Effect: Strong against Thunder (Ice & Tornado)
- **OTornado** [Passive Talents] - Effect: Strong against Tornado
- **Repair** [Passive Talents] - Effect: Recover from status ailments at the end of each round
- **Selfix** [Passive Talents] - Effect: Recover 1/10 of max HP at the end of each round
- **XFire** [Passive Talents] - Effect: Weak against Fire
- **XIce** [Passive Talents] - Effect: Weak against Ice
- **XQuake** [Passive Talents] - Effect: Weak against Quake
- **XThunder** [Passive Talents] - Effect: Weak against Thunder (Ice & Tornado)
- **XTornado** [Passive Talents] - Effect: Weak against Tornado
- **6times** [Robot Active Talents] - TP: 12; Base: 30; Target: S; Property: Damage; Other: 6 hits at 1/6 damage
- **Beam** [Robot Active Talents] - TP: 4; Base: 10; Target: S; Property: -
- **Dance** [Robot Active Talents] - TP: 11; Base: 0; Target: S; Property: Fatal
- **Dash** [Robot Active Talents] - TP: 6; Base: 0; Target: S; Property: -
- **Dk-Force** [Robot Active Talents] - TP: 4; Base: 10; Target: S; Property: -; Other: not used by any species
- **Drill** [Robot Active Talents] - TP: 4; Base: 15; Target: S; Property: -
- **Drop** [Robot Active Talents] - TP: 7; Base: 0; Target: S; Property: Tornado
- **Fluid** [Robot Active Talents] - TP: 1; Base: 0; Target: All; Property: Poison; Other: not used by any species
- **Freeze** [Robot Active Talents] - TP: 6; Base: 0; Target: S/G; Property: Ice
- **Laser** [Robot Active Talents] - TP: 4; Base: 16; Target: S; Property: -
- **LowKick** [Robot Active Talents] - TP: 6; Base: 0; Target: S; Property: -
- **Rocket** [Robot Active Talents] - TP: 4; Base: 6; Target: S; Property: -
- **Slicer** [Robot Active Talents] - TP: 4; Base: 20; Target: S; Property: -
- **SpinCut** [Robot Active Talents] - TP: 4; Base: 10; Target: S; Property: -
- **Tromp** [Robot Active Talents] - TP: 4; Base: 0; Target: S/G; Property: Mute
- **Twice** [Robot Active Talents] - TP: 4; Base: 40; Target: S; Property: Damage; Other: 2 hits at 1/2 damage

## Status Effects

- **Blind** - Hit rate is reduced. Related spells: Spark
- **Confuse** - Target takes random actions against random targets. Related spells: Conf
- **Curse** - Target is reduced to half defense and half magic defense. Related spells: Pure
- **Fatal** - Target is instantly killed and becomes Fell. None
- **Fell** - Target lost all HP and is killed. Persists after battle. Related spells: Life; LifeA; LifeB
- **Mute** - Target cannot cast spells. Related spells: Mute
- **Normal** - Normal status condition Related spells: Erase
- **Paralysis** - Target cannot act. Related spells: Para
- **Petrify** - Target character cannot act; persists after battle. Target monster dies. Related spells: Stone
- **Sleep** - Target cannot act. Wears off over time. Related spells: Sleep

## Monster and Species Tables

- **Diviner** [Beasts] - Level range: 1-2; Element: Fire
- **Orc-Orc** [Beasts] - Level range: 1-2; Element: Water
- **Silver** [Beasts] - Level range: 1-2; Element: Earth
- **Sprite** [Beasts] - Level range: 1-2; Element: Air
- **Centaur** [Beasts] - Level range: 11-12; Element: Earth
- **Fiend** [Beasts] - Level range: 11-12; Element: Air
- **Horus** [Beasts] - Level range: 11-12; Element: Fire
- **Werepig** [Beasts] - Level range: 11-12; Element: Water
- **Nitemare** [Beasts] - Level range: 13-14; Element: Earth
- **Sylph** [Beasts] - Level range: 13-14; Element: Air
- **Viking** [Beasts] - Level range: 13-14; Element: Water
- **Wizard** [Beasts] - Level range: 13-14; Element: Fire
- **Brooder** [Beasts] - Level range: 15-16; Element: Water
- **Liz Man** [Beasts] - Level range: 15-16; Element: Earth
- **Thanos** [Beasts] - Level range: 15-16; Element: Air
- **Watcher** [Beasts] - Level range: 15-16; Element: Fire
- **Fish Man** [Beasts] - Level range: 17-18; Element: Water
- **Loki** [Beasts] - Level range: 17-18; Element: Air
- **Medusa** [Beasts] - Level range: 17-18; Element: Earth
- **Osiris** [Beasts] - Level range: 17-18; Element: Fire
- **Hermit** [Beasts] - Level range: 19-20; Element: Fire
- **Lamia** [Beasts] - Level range: 19-20; Element: Earth
- **Merman** [Beasts] - Level range: 19-20; Element: Water
- **Soarx** [Beasts] - Level range: 19-20; Element: Air
- **Big Head** [Beasts] - Level range: 21-22; Element: Water
- **Liz Duke** [Beasts] - Level range: 21-22; Element: Earth
- **Mage** [Beasts] - Level range: 21-22; Element: Fire
- **Siren** [Beasts] - Level range: 21-22; Element: Air
- **Mephisto** [Beasts] - Level range: 23-24; Element: Air
- **Naga** [Beasts] - Level range: 23-24; Element: Earth
- **Nix** [Beasts] - Level range: 23-24; Element: Water
- **Set** [Beasts] - Level range: 23-24; Element: Fire
- **Scylla** [Beasts] - Level range: 25-26; Element: Earth
- **Selkie** [Beasts] - Level range: 25-26; Element: Water
- **Sorcerer** [Beasts] - Level range: 25-26; Element: Fire
- **Succubus** [Beasts] - Level range: 25-26; Element: Air
- **Dagon** [Beasts] - Level range: 27-28; Element: Water
- **Liz King** [Beasts] - Level range: 27-28; Element: Earth
- **Sphinx** [Beasts] - Level range: 27-28; Element: Air
- **Warlock** [Beasts] - Level range: 27-28; Element: Fire
- **Echidna** [Beasts] - Level range: 29-30; Element: Earth
- **Echidna** [Beasts] - Level range: 29-30; Element: Air
- **Gillman** [Beasts] - Level range: 29-30; Element: Water
- **Gillman** [Beasts] - Level range: 29-30; Element: Fire
- **Broomer** [Beasts] - Level range: 3-4; Element: Fire
- **Fighter** [Beasts] - Level range: 3-4; Element: Earth
- **Nymph** [Beasts] - Level range: 3-4; Element: Air
- **SeaMonk** [Beasts] - Level range: 3-4; Element: Water
- **Aeshma** [Beasts] - Level range: 31-99; Element: Air
- **Anubis** [Beasts] - Level range: 31-99; Element: Earth
- **Anubis** [Beasts] - Level range: 31-99; Element: Water
- **Anubis** [Beasts] - Level range: 31-99; Element: Fire
- **Familiar** [Beasts] - Level range: 5-6; Element: Air
- **Kelpie** [Beasts] - Level range: 5-6; Element: Earth
- **Mad Boar** [Beasts] - Level range: 5-6; Element: Water
- **Thoth** [Beasts] - Level range: 5-6; Element: Fire
- **Fairy** [Beasts] - Level range: 7-8; Element: Air
- **Mustang** [Beasts] - Level range: 7-8; Element: Earth
- **Pirate** [Beasts] - Level range: 7-8; Element: Water
- **Witch** [Beasts] - Level range: 7-8; Element: Fire
- **Magician** [Beasts] - Level range: 9-10; Element: Fire
- **Pixie** [Beasts] - Level range: 9-10; Element: Air
- **SaltMonk** [Beasts] - Level range: 9-10; Element: Water
- **Warrior** [Beasts] - Level range: 9-10; Element: Earth
- **Hooligan** [Cyborgs] - Level range: 1-2; Element: Earth/Water
- **Quacky** [Cyborgs] - Level range: 1-2; Element: Fire/Air
- **Duke** [Cyborgs] - Level range: 11-12; Element: Earth/Water
- **LoonyGuy** [Cyborgs] - Level range: 11-12; Element: Fire/Air
- **Cracker** [Cyborgs] - Level range: 13-14; Element: Fire/Air
- **Outlaw** [Cyborgs] - Level range: 13-14; Element: Earth/Water
- **Rumorer** [Cyborgs] - Level range: 15-16; Element: Fire/Air
- **Soldier** [Cyborgs] - Level range: 15-16; Element: Earth/Water
- **Dullahan** [Cyborgs] - Level range: 17-18; Element: Earth/Water
- **Ronin** [Cyborgs] - Level range: 17-18; Element: Fire/Air
- **Samurai** [Cyborgs] - Level range: 19-20; Element: Fire/Air
- **Terorist** [Cyborgs] - Level range: 19-20; Element: Earth/Water
- **Commando** [Cyborgs] - Level range: 21-22; Element: Earth/Water
- **Tattler** [Cyborgs] - Level range: 21-22; Element: Fire/Air
- **Brain** [Cyborgs] - Level range: 23-24; Element: Earth/Water
- **Hatamoto** [Cyborgs] - Level range: 23-24; Element: Fire/Air
- **Daimyo** [Cyborgs] - Level range: 25-26; Element: Fire/Air
- **HiredGun** [Cyborgs] - Level range: 25-26; Element: Earth/Water
- **SS** [Cyborgs] - Level range: 27-28; Element: Earth/Water
- **Virago** [Cyborgs] - Level range: 27-28; Element: Fire/Air
- **Shogun** [Cyborgs] - Level range: 29-30; Element: Earth/Water
- **Shogun** [Cyborgs] - Level range: 29-30; Element: Fire/Air
- **Talker** [Cyborgs] - Level range: 3-4; Element: Fire/Air
- **Thief** [Cyborgs] - Level range: 3-4; Element: Earth/Water
- **Headless** [Cyborgs] - Level range: 5-6; Element: Earth/Water
- **Stranger** [Cyborgs] - Level range: 5-6; Element: Fire/Air
- **Burgler** [Cyborgs] - Level range: 7-8; Element: Earth/Water
- **Imposter** [Cyborgs] - Level range: 7-8; Element: Fire/Air
- **Brigand** [Cyborgs] - Level range: 9-10; Element: Earth/Water
- **Busybody** [Cyborgs] - Level range: 9-10; Element: Fire/Air
- **F-Drake** [Monsters] - Level range: 1-2; Element: Fire
- **Raven** [Monsters] - Level range: 1-2; Element: Air
- **Turtle** [Monsters] - Level range: 1-2; Element: Water
- **Worm** [Monsters] - Level range: 1-2; Element: Earth
- **DualMask** [Monsters] - Level range: 11-12; Element: Fire
- **Ghost** [Monsters] - Level range: 11-12; Element: Air
- **Mushroom** [Monsters] - Level range: 11-12; Element: Earth
- **Pentagon** [Monsters] - Level range: 11-12; Element: Water
- **GigaWorm** [Monsters] - Level range: 13-14; Element: Earth
- **Griffon** [Monsters] - Level range: 13-14; Element: Air
- **Igasaur** [Monsters] - Level range: 13-14; Element: Water
- **Salamand** [Monsters] - Level range: 13-14; Element: Fire
- **BabyWyrm** [Monsters] - Level range: 15-16; Element: Air
- **DrainRay** [Monsters] - Level range: 15-16; Element: Water
- **GreyWolf** [Monsters] - Level range: 15-16; Element: Earth
- **Tire** [Monsters] - Level range: 15-16; Element: Fire
- **Octopus** [Monsters] - Level range: 17-18; Element: Water
- **Remora** [Monsters] - Level range: 17-18; Element: Air
- **Snake** [Monsters] - Level range: 17-18; Element: Earth
- **Young-D** [Monsters] - Level range: 17-18; Element: Fire
- **BlackCat** [Monsters] - Level range: 19-20; Element: Earth
- **D.Bone** [Monsters] - Level range: 19-20; Element: Fire
- **Squid** [Monsters] - Level range: 19-20; Element: Water
- **Typhoon** [Monsters] - Level range: 19-20; Element: Air
- **BulbFish** [Monsters] - Level range: 21-22; Element: Water
- **Hunter** [Monsters] - Level range: 21-22; Element: Earth
- **Wheel** [Monsters] - Level range: 21-22; Element: Fire
- **Wyrm Kid** [Monsters] - Level range: 21-22; Element: Air
- **Ammonite** [Monsters] - Level range: 23-24; Element: Water
- **EvilMask** [Monsters] - Level range: 23-24; Element: Fire
- **Serpent** [Monsters] - Level range: 23-24; Element: Earth
- **Specter** [Monsters] - Level range: 23-24; Element: Air
- **Amoeba** [Monsters] - Level range: 25-26; Element: Water
- **D.Fossil** [Monsters] - Level range: 25-26; Element: Fire
- **MummyCat** [Monsters] - Level range: 25-26; Element: Earth
- **Tempest** [Monsters] - Level range: 25-26; Element: Air
- **BoltRay** [Monsters] - Level range: 27-28; Element: Water
- **FireFan** [Monsters] - Level range: 27-28; Element: Fire
- **Romulus** [Monsters] - Level range: 27-28; Element: Earth
- **Wyrm** [Monsters] - Level range: 27-28; Element: Air
- **Hydra** [Monsters] - Level range: 29-30; Element: Earth
- **Hydra** [Monsters] - Level range: 29-30; Element: Air
- **Kraken** [Monsters] - Level range: 29-30; Element: Water
- **Kraken** [Monsters] - Level range: 29-30; Element: Fire
- **Big Eye** [Monsters] - Level range: 3-4; Element: Air
- **Ray** [Monsters] - Level range: 3-4; Element: Water
- **Wisper** [Monsters] - Level range: 3-4; Element: Fire
- **Wolf** [Monsters] - Level range: 3-4; Element: Earth
- **Garuda** [Monsters] - Level range: 31-99; Element: Fire
- **Garuda** [Monsters] - Level range: 31-99; Element: Air
- **Sei-Ryu** [Monsters] - Level range: 31-99; Element: Earth
- **Sei-Ryu** [Monsters] - Level range: 31-99; Element: Water
- **Baby-D** [Monsters] - Level range: 5-6; Element: Fire
- **Fungus** [Monsters] - Level range: 5-6; Element: Earth
- **Gargoyle** [Monsters] - Level range: 5-6; Element: Air
- **Starfish** [Monsters] - Level range: 5-6; Element: Water
- **Adamant** [Monsters] - Level range: 7-8; Element: Water
- **Amprex** [Monsters] - Level range: 7-8; Element: Air
- **F-Liz.** [Monsters] - Level range: 7-8; Element: Fire
- **LandWorm** [Monsters] - Level range: 7-8; Element: Earth
- **Angler** [Monsters] - Level range: 9-10; Element: Water
- **Evil Eye** [Monsters] - Level range: 9-10; Element: Air
- **Fireball** [Monsters] - Level range: 9-10; Element: Fire
- **Scorpion** [Monsters] - Level range: 9-10; Element: Earth
- **Flower** [Robots] - Level range: 1-2; Element: Fire/Air
- **Orb Rat** [Robots] - Level range: 1-2; Element: Earth/Water
- **IronLady** [Robots] - Level range: 11-12; Element: Earth/Water
- **Reaper** [Robots] - Level range: 11-12; Element: Fire/Air
- **Cactus** [Robots] - Level range: 13-14; Element: Fire/Air
- **Spectrat** [Robots] - Level range: 13-14; Element: Earth/Water
- **Beguiler** [Robots] - Level range: 15-16; Element: Fire/Air
- **Guard** [Robots] - Level range: 15-16; Element: Earth/Water
- **Bazooka** [Robots] - Level range: 17-18; Element: Fire/Air
- **Valkyrie** [Robots] - Level range: 17-18; Element: Earth/Water
- **75mm** [Robots] - Level range: 19-20; Element: Fire/Air
- **Keeper** [Robots] - Level range: 19-20; Element: Earth/Water
- **Monitor** [Robots] - Level range: 21-22; Element: Earth/Water
- **Swindler** [Robots] - Level range: 21-22; Element: Fire/Air
- **105mm** [Robots] - Level range: 23-24; Element: Fire/Air
- **Iken** [Robots] - Level range: 23-24; Element: Earth/Water
- **150mm** [Robots] - Level range: 25-26; Element: Fire/Air
- **Searcher** [Robots] - Level range: 25-26; Element: Earth/Water
- **Alert** [Robots] - Level range: 27-28; Element: Earth/Water
- **Hustler** [Robots] - Level range: 27-28; Element: Fire/Air
- **210mm** [Robots] - Level range: 29-30; Element: Earth/Water
- **210mm** [Robots] - Level range: 29-30; Element: Fire/Air
- **Tomtom** [Robots] - Level range: 3-4; Element: Earth/Water
- **Trixter** [Robots] - Level range: 3-4; Element: Fire/Air
- **Venus** [Robots] - Level range: 31-99; Element: Earth/Water
- **Venus** [Robots] - Level range: 31-99; Element: Fire/Air
- **AirMaid** [Robots] - Level range: 5-6; Element: Earth/Water
- **Cosmos** [Robots] - Level range: 5-6; Element: Fire/Air
- **IronRose** [Robots] - Level range: 7-8; Element: Fire/Air
- **Jerrit** [Robots] - Level range: 7-8; Element: Earth/Water
- **Con Man** [Robots] - Level range: 9-10; Element: Fire/Air
- **Maitie** [Robots] - Level range: 9-10; Element: Earth/Water

## Formula Reference

- **Melee weapons** [Weapons] - Damage = skill x (WP + Att. + Agi.) - Def. Notes: Humans use normal melee at skill 2. Mystic swords use skill 2 for every supported class. Mutants reach skill 2 with Psi knife, Psi sword, X-Fire staff, and Fast staff.
- **Missile weapons** [Weapons] - Damage = skill x (WP + 2 x Att.) - Def. Notes: Humans throw at skill 2. Bows stay at skill 1 for supported classes.
- **Martial arts** [Weapons] - Damage = 1/2 x skill x WP x Att. - Def. Notes: Beasts use martial arts at skill 1.5; most other supported classes use skill 1.
- **Fixed-damage weapons** [Weapons] - Damage = skill x WP - Def. Notes: Group damage is divided by group size. Humans use cripplers at skill 8. Mutants add 2 x Magic when using the Psi gun and humans or mutants use the Poison gun at skill 8.
- **Attack magic** [Magic] - Damage = skill x (SP + Mag.) - M.Def. Notes: Mutants cast attack magic at skill 3; monsters, beasts, humans, and cyborgs cast at skill 1.5; robots cannot cast it.
- **Item magic** [Magic] - Damage = skill x (SP + Mag.) - M.Def. Notes: All classes that can use the item spell use item magic at skill 1.5.
- **Talents** [Talents] - Damage = skill x (1/4 x TP x (Att. + maxHP/10) + base) - Def. Notes: Robot talents use skill 1.5 when used by robots. Counterattacking talents resolve at half power.
- **Cannon** [Talon] - Damage = 200 - Def. Notes: Pre-installed Talon attack that hits all enemies.
- **Missile** [Talon] - Damage = 400 - Def. Notes: Talon weapon unit found at Mount Hasbid.
- **Laser** [Talon] - Damage = 600 - Def. Notes: Talon weapon unit found at Cirrus.
- **E-Ray** [Talon] - Damage = 800 - Def. Notes: Talon weapon unit found at Underworld Cave.

## Robot Capsules

- **Attack** - Cost: 1500; Effect: +3 Attack; Bought: Dharm (Present); Elan (Past, Future); Cirrus, Donmac, Knaya (Pureland)
- **Defense** - Cost: 1500; Effect: +3 Defense; Bought: Elan (Present); Lae (Past); Viper City (Future); Knaya, Porle (Pureland)
- **Speed** - Cost: 1500; Effect: +3 Agility; Bought: Elan (Present); Lae (Past); Viper City (Future); Knaya, Porle (Pureland)
- **HP** - Cost: 1500; Effect: +24-40 max HP; Bought: Dharm (Present); Elan (Past, Future); Cirrus, Donmac, Knaya (Pureland)

## Talon Units

- **Rover** [Engine] - Travels over land; Found: South Cave (Past)
- **Hover** [Engine] - Travels over land and water; Found: Castle of Chaos (Present); Talonsburg (Pureland)
- **Soar** [Engine] - Travels over land, water, and mountains; Found: Eastern Ruins (Pureland)
- **Past** [Warp] - Warps to and from the Past; Found: Elan (Present)
- **Future** [Warp] - Warps to and from the Future; Found: Castle of Chaos (Present)
- **X-Plane** [Warp] - Warps to Pureland (one-way travel); Found: Matrieya's Tower (Floatland)
- **Cannon** [Weapon] - Attacks all enemies: Damage = 200 - Def.; Found: Pre-installed
- **Missile** [Weapon] - Attacks all enemies: Damage = 400 - Def.; Found: Mount Hasbid (Pureland)
- **Laser** [Weapon] - Attacks all enemies: Damage = 600 - Def.; Found: Cirrus (Pureland)
- **E-Ray** [Weapon] - Attacks all enemies: Damage = 800 - Def.; Found: Underworld Cave (Underworld)
- **Shield** [Weapon] - Prevents random encounters; Found: Talonsburg (Pureland)
- **Berth** [Option] - Recovers party HP, MP, and status; Found: Viper City (Future)
- **Flushex** [Option] - Changes lead member to original form; Found: Lae (Past)
