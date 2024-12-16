# Third Robot

* The final robot we will make will expand upon your previous works while teaching limitations, and important things to the way a robot functions.

## Quakkas style
* The final robot will be made to look similar to the 2024 quakkas robots.
* start by making a new prefab mine will be named 9997
* Then make a standard robot frame same as previous.
* Now add a generate arm
* Push it to the front then set the length to 28. and the rotation of the Arm not the ArmSec1 to 180.
  ![image](https://github.com/user-attachments/assets/594f79cc-0e27-4b23-9dc5-b1ed469f1b13)
* Leave the Limits at 0,0
* Enable contious aim.
* return to the field and find the AimFinder game object.
* Ensure it is in the center of the speaker then in the Inspector right click position and click copy.
* returning to 9997 we want to set the arm Tartet to the copied values by right click and pasting.
* Check the Continous aim box.
* Right click the ArmSec1 object and go to 3dObject>Cube to create a new cube.
* This will create a new generic cube. the scale in the transform is 1m in space. use this to set a size. 0.0254 is the scale factor for inches. so do 14 * 0.0254 for x 18 * 0.0254 for y and 0.0254 for z. then set x angle to 40 and put at the end of the arm.
  ![image](https://github.com/user-attachments/assets/716682b5-ecf3-41dd-9c66-ab3c6f92bbb7)
* Now create an intake, stow and outake on the arm section we just added. set the angle to 130 this time.
* Go ahead and set up the the intake to Lt and stow to outake on Rt. set outake speed to 25.
![image](https://github.com/user-attachments/assets/9927a782-c3cc-4533-bb30-06a13467e297)
* now return to the aim and set the indicator aim to Outake.

## Shooting and limitations.
* a limitation of the current system is that you can not have hold and toggle at the same time, and becuase we use constant aim we need a setpoint for intake which is generaly a hold, we need to adjust the control scheme.
* set the first setpoint to 1 a, now to add a setpoint click the plus under setpoint and it will automatically ad a setpoint button for you. (if you try adding a setpoint button it will be deleted and likley mess up the controls.)
* it may be tempting to set it to 0 however because 0 is your stow angle it will not leave continous aim mode. the condition for continous aim is that the setpoint is the stow angle and continous aim is enabled.
* Now add a control on y for -100.
![image](https://github.com/user-attachments/assets/0ec5d7fd-112e-4acd-9e83-c26ab27cdb88)
* return to the main scene set the robot and test.
* Chances are it lifted up. This is because we didnt set an angle offset. this is important when tuning a shooter, especially non inline ones.
* To fix this set the angle offset to -48. you may note that the angle 130-180+2 gives you this.
* You may also notice that the amp is iffy, this is because the design relies on game piece bending and the downside of the systems in use is that it will not work with amp systems that require bending that can not be adjusted.

## Climbing
* Add an Elevator to the bottom of the shooter. Make sure its parented to the ArmSec1. Because the parent is 180 deg the elevator will generate upsidown.
* Set width to 3 weight to 1 for all.
* add a hook generator to stage 1.
* Flip the y rotation 180 and align with the carriage.
* put the setpoint to 16 on x in toggle mode.
  ![image](https://github.com/user-attachments/assets/a46e3b1b-c824-4803-be76-555f72e74655)
* now go to the arm and add a setpoint for climbing at -80 on x
