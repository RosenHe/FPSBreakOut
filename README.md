# FPSBreakOut

1. The Camera is setted.
2. Character can throw a ball by clicking mouse button left.
3. Character can move by press W,A,S,D,and space to jump.
4. Three Boxes is created.

Questions left:
-Ball spawning in wrong location - should spawn infront of player moving at player speed + ball speed
-ball should also spawn in the middle of new cos
-A Score Board.
-Opening Scene and Ending Scene.(I do the art later. please contact me if you have something specific)

Completed:
Added a crosshair




Current Bugs:




Game mechanics description:

There is a box wall that has an assortment of boxes. 
  The box wall will move forward as the player moves by jumping on platforms
  The platforms are made as the player shoots boxes off the wall with balls.


when colliding with a box the ball should disappear,
 then the box should give points based on the color and number for the box
 then based on the number and color of the box it should fall towards the player 
	then it will become a box platform for the player
	
A box platform will last for a number of seconds indicated by the box
	A sound tick should go off for every second the platform counts down (or the box flashes)
	when it hits zero the box dissipates

As the player moves forward they have to avoid falling to the ground 
	if they fall a number of times (lives) its gameover, 
        they also lose points based on how many times they lose
        if the player falls, they respawn on the last box they were on, with an extra 5 second count. 
           If the last box doesnt exist any more then its the second last one

(Endless game mode idea): 
player faces a random assortment of boxes in each stage, and get an extra life for every 5 stages.
Will need a highscore 


