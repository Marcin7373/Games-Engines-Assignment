# Goal of Assignment
This is a game where I try to combine procedural generation of tree like thorny bushes and growing them in a kind of a maze in relation to the player. The player will have to control a ball which when hit by the thorns starts you back at the start. The player will have to avoid these thorny vines/trees as they grow toward the player in a dynamic way. The player has a dash ability where for a limited time they can pass through the throns with a long cooldown. The thorny forest is grown on a perlin noise U-shaped mesh funneling the player towards the goal.

## Description (What it does and how it works)
The game starts in a U-shaped plane generated using a sine wave mixed with perlin noise creating a rough terrain, but not too rough as the player will need to smoothly roll a ball through it. Walls on either side prevent the player from falling off while killing the player if they try and climb it avoiding the valley of thorns. The sides are coloured red using a shader to worn the player. At that point the player has control of a ball which has a dash using "space" which speeds up the player briefly and lets them pass through the thorns. The balls material changes to match the ground as they dash and turn blue when the dash is in cooldown. The camera has a distance variable which can be adjusted, it will make sure to always face forward, smoothly and always look at the ball using trigonometry.

The maze of branches is distributed using perlin noise by the spawners which spawn a number of branches which grow independently in clusters. But dont start growing until the player is in range as the growth is quick initially. The branches are spawned on top of the curved and noisy mesh by having the BranchSpawner use raycasting to move to the surface. Each branch grows using Lerping in three stages. First it grows quickly using scale while rotating making it look more dynamic. There are many randomizations that make them grow to different angles or start at different angles as well as Lerping in position slightly making them behave differently from each other. As the growth gets slower it enters the second stage where it grows at a constant rate until third stage where it stops growing simply rotates very slowly toward the player. These branches are turned inactive when the player gets far enough away from them for efficiency.
The code layout follows a tree like structure where a branch cluster is spawned by a BranchSpawner which is spawned in a pattern using perlin noise by the ForestSpawner. It also randomly picks BranchSpawners to skip to create holes for the player to get through. That ForestSpawner is then attached to the plane which is generated into a U-curve using a sine wave and perlin noise using the TerrainPerlinNoise script.

## Demo
[![YouTube](http://img.youtube.com/vi/bqs-oxIBY4U/0.jpg)](https://youtu.be/bqs-oxIBY4U)

## Options for Setup
- In the Grow script the radius for spawning controls how early the branches grow when the player gets close and the despawning value can be decreased to increase performance.
- In branchSpawn more tree branches can be added to increase veriety.
- In the ForestSpawner lGap and wGap can be changed to increse the gaps between branch clusters to make the game easier. The multiplier can also be increased to increase the amplitude of the perlin noise for the branches making a pattern less apparent and the game harder.
- In the Controller the cooldownRate can be increased and dashLength and speed can be increased to make the game easier.
- TerrainPerlinNoise script has a multiplier and gradient variables for perlin noise adjustments.

## Potential bugs
The BranchSpawer scripts send out a raycast on start to spawn on top of the mesh, but the mesh may not generate fast enough making the branches spawn below the mesh.
To fix make the ForestSpwaner script go last in Project settings execution order, so that it goes after the TerrainPerlinNoise script which is the "default" label on that list.

Tree Prefabs when selected have a weird bug where the cursor and the inspector icon blink and load over and over again, found no way to fit it, but game runs fine as long as the tree object is not selected and visible in the inspector.

### Sources Used
I used a tutorial video to get a start applying perlin noise to a plane, but had to figure out the balance and sine wave layer on top on my own.
