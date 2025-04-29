# 3D FPS Game 🎮

I created this game in Fall 2023 with C# and Unity.

## About the Game

The 3D FPS Game is a first person shooter set in a dynamic environment where the player must navigate through a dangerous terrain, defeat enemies, and accomplish a set of objectives. The goal of the game is to clear the area of enemies, locate powerful weapons, and use them to defeat guards protecting a house. The game focuses on precision shooting, strategy, and resource management, providing an immersive and thrilling experience.

### Development Overview
This game was developed using Unity's robust game engine along with C# scripting to handle player mechanics, enemy AI, and game logic. I utilized the built-in physics and AI systems to create a more realistic and interactive environment. The game also features several core gameplay elements, such as weapon management, NPC enemy patrols, and interactive sound and visual effects.

Unity’s asset store provided useful resources for weapon models and basic NPC enemies, which I integrated into the game. Custom scripts were written to handle specific game interactions such as picking up weapons, firing, and triggering sound and visual effects.

The development process involved:
- Designing the game world and ensuring all elements (house, gates, guards, ammo, etc.) were placed logically for the player to explore.
- Creating a smooth first person control system that allows the player to move, jump, and shoot with responsiveness.
- Implementing AI behaviors for the guards that make the game more challenging as players get closer to the house.
- Adding sound effects and visual effects that complement the actions in the game for a more immersive experience.

## 1. Player Character 🧑‍💻
- The game uses first-person control for the player’s perspective.
- The player character can perform the following actions:
  - Walk using the WASD keys or the arrow keys.
  - Run by holding down SHIFT key + WASD/arrow keys.
  - Jump using the SPACE key.
  - Switch weapons by pressing Q or E keys.
  - Fire weapons by clicking the left mouse button.
  - Look around by moving the mouse.
- The player starts with three lives, and each life is lost when hit by enemy fire.

## 2. Weapons 🔫
- There are two types of weapons in the game:
  - Gun and Rocket-Propelled Grenade (RPG).
  
### Weapon Mechanics:
- To kill an enemy with the gun, you need to hit them three times.
- To kill an enemy with the RPG, only one hit is required.
  
### Weapon Acquisition:
- The player does not have any weapons at the start of the game.
- Weapons (gun and RPG) can be found scattered around the game world and can be picked up by walking or running over them.
- Gun has a limited 6 bullets.
- RPG can only be fired once, but additional ammunition (bullets and grenades) can be found in the game world.

### Weapon Models:
- The 3D weapon models (gun and RPG) are invisible at the start but appear when picked up.

## 3. Game World
- The game world includes the following objects:
  - A house that serves as the objective.
  - A gate that needs to be passed to get close to the house.

### Guards and Enemy AI:
- The house is guarded by two NPC guards, who patrol the area.
- The guards will pursue the player if they get too close to the house.
- If a guard is within a certain range of the player, they will shoot at the player.
- Guards have unlimited ammunition.
- The NPCs use Unity's AI to navigate, and capsules serve as basic representations of the guards. Character animations are not necessary.

### Game Level:
- Only one level is required where the player must clear the area and reach the house.

## 4. Gameplay
- Goal: The player's objective is to eliminate the two guards and enter the house.
- To get close to the house, the player needs to pass through the gate.
- If the player gets within a certain range of the house, the guards will pursue them.
- Guards will shoot at the player when they are within close range.
- If the player is too far from the house, the guards will return to patrol.
- The player can look for additional ammunition (bullets and grenades) if they run out.
- The player loses one life each time they are hit by enemy bullets.

## 5. Sound Effects 🔊
Sound effects are triggered during specific events:
- Shooting the gun
- Shooting the RPG
- RPG explosion
- Hitting a guard
- Player gets hit
- Background music

## 6. Visual Effects
- When bullets or grenades hit an object, a visual effect such as a particle system is triggered to simulate impact.

## 7. Graphical User Interface (GUI) 📊
The GUI displays critical information during gameplay:
- Lives left
- Weapons collected
- Number of bullets left
- Kills
