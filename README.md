# Games-Engines-Assignment
Procedural generation in Unity

## Goal of Assignment
This is a game where i try to combine procedural generation of tree's other thorny plants and growing them in a kind of a maze in relation to the player. The player will have to control a ball which will pop if it hits the thorns while trying to get to a checkpoint/exit of the maze. The player will have to avoid these thorny vines and trees as they grow toward the player in a dynamic way.

## Similar projects
This project shows a way of growing trees in-game similarly to what i need, only my trees will look differently with branches growing lower to the ground where the player is and they will grow towards the player.

![tree_ref](https://github.com/Marcin7373/Games-Engines-Assignment/tree/master/Ref/tree_ref.gif)
By: https://github.com/Marcin7373/Games-Engines-Assignment/tree/master/Ref

Some interesting ways in which i thought of generating these trees and bushes was without using the inbuilt tree object in unity similar to this video using fractals except i dont want my results to look so symmetrical and planned. My plants need to look and grow dynamically at the player as they move.

![YouTube](https://www.youtube.com/watch?v=VXegg-HGT0s)

I couldn't find much more that did anything similar to what i want to do other than some tree growing, some of which only upscaled the whole tree.

## Gameplay
The player will start in a plain field with a line of sight at the goal unable to move for a few seconds as the plants start growing infront of them obscuring their vision of the goal. They will then roll around as a ball avoiding thorny branches growing towards them needing to be constantly moving looking for openings. This can create an impossible scenario where the randomly generated branches grow in a way that traps the player. So the player will have an ability where they can harden and push through the branches for a limited amount of time. 
The player from the start will lose sight of the goal so i have some solutions which i will test to see which works best. I could give the player a directional indicator above them. Give them the ability to jump just high enough to see above the thicker bushes while giving them a new mechaninc to play with to avoid newer freshly growing branches that are low enough to jump. Or simply have the camera be high above the player to let them see everything ahead of them if it turns out the game is too hard.
Another possible mechanic could involve having the branches in the player cone of vision to grow faster.

## Plan
This project may be over ambitious for me so here is my plan step by step proioritizing things that should be done first.

-Make a thorny bush that grows in-game from a specific point with the branches growing at random. (Optionally make a taller tree variant)
-Make the trees/bushes grow randomly on a plane within a radius of the player (possibly in a pattern making the maze)
-Turn it into a playable game where a make the player character ball with controls and a goal to go towards.
-(If somehow i get to this point) The plane/ground could be made procedurally to make it more dynamic.
