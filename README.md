# FPSBreakOut
Completed!
- boxes need to stop falling and become platforms when reaching a plane (also scale up now)
- Player movement smoothed out/ box/boxwall movement smoothed out
More details in the changelog.txt.

TODOs:
- add timer for boxes to countdown and disappear, boxes should change color until reaching '1' and then poof.
- player dies when falls to ground, has number of starting lives (currently only restarts the game)
- A Score Board.
- Opening Scene and Ending Scene.(I do the art later. please contact me if you have something specific)
- player reaching goal, move to next stage
- need give points to player
- currently can shoot forever, need to add cooldown for ball shooting
- need GUI for current score, and shooting cool down, and maybe a timer.

low priority:
- Balls disappear (instead of popping particle effect,phasing, or sounds) 


Game mechanics description: (just for reference, feel free to add)

There is a box wall that has an assortment of boxes. 
  The box wall will move forward as the player moves by jumping on platforms
  The platforms are made as the player shoots boxes off the wall with balls.

ball should spawn infront of the player in the middle of the cross hair and should be moving initially on the able that the camera is facing

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


