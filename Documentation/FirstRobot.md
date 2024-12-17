# Creating Your First Robot

## Adding a robot
* In the Resources/Robots folder right click the project view.
* Find the Create > menu
* then find the Prefab button in the submenu, click it to create a new prefab.
* When you click it should create a new file and allow you to name it, name it 9999 and hit enter
  ![image](https://github.com/user-attachments/assets/4868b1ca-64b9-44a3-899f-8e5b2914f200)

## Setting up the driveTrain
* double click the 9999 prefab (the file you just made is known as a prefab)
* Once in it look to the inspector screen and add a GenerateDriveTrain scipt by clicking add Component then searching for it.
* now if you double click 9999 on the heirarchy you should see the robot.
* Make sure to disable auto save which is found in the top right of the scene view to avoid any makor issues. (dont forget to save frequently though)
  ![image](https://github.com/user-attachments/assets/464b9682-0bac-4d8b-bbc2-e22239ceeb61)
* Now we are going to fill out the fields, we are going to make the robot frame 27"x27". the wheels 1.5" wide by 4" diameter. A weight of 65lbs, a drive force of 300, and a bumper height of 4. enjoy watching the script change everything for you.
![image](https://github.com/user-attachments/assets/e3b813ef-4ff2-4802-94a6-2b69cbf9a808)


##GamePieces
* right click the 9999 object in the Hierarchy, and select create empty Name it intake.
* The blue arrow in the scene view when selecting 9999 indicates the front.
  ![fce78031-84c8-42a7-a3fd-ab431852a162](https://github.com/user-attachments/assets/d09fc19f-4a25-4554-a065-142572a70b4c)
* select the intake object you created and add a generate intake component
* The default size is 0"x0"x0" so we will adjust it to be 15"x4"x3"
* Then move the arrows that are visible when intake is selected to move the object to the rear of the robot and position it to be just inside the frame
 ![e22d9e1e-c792-4d6a-b966-91bebd8224ac](https://github.com/user-attachments/assets/77ed6afb-ea6f-4daf-a381-49365317f384)
* next we want to setup the intake controls. Set the button to Lt and the Intake type to Hold. The intake type controls the behaviour of button actions.
 ![39c41937-5557-42b9-ada6-67ee1d24ff56](https://github.com/user-attachments/assets/c212a419-257c-4736-83dd-c9b6cdf9cb0a)
* Now create another empty object this time named stow.
* add a generate stow component
* Again the default is 0"x0"x0" this time set it to 14"x3"x14"
* at the top of the inspector window is the Transform component, all objects have this. it can be used to set percise locations. use it to set the angle to -45,0,0
* Then reposition the stow such that the intake would transfer smoothly into it.
* now return to the Intake object on the generator script is a line called Transfer to Stow, drag the stow object you just made into it. this is the transfer system. it allows you to move objects from an intake to a stow to another stow or outake.
* Now returning to the Stow Object, we want to set the transfer button to Rt, presses to transfer is 1, and transfer type is button.
  ![53373702-1fac-4ee4-9b0f-7764fdaf7fe7](https://github.com/user-attachments/assets/ccc8e527-f75e-46b7-a848-4bc5a3351e08)
* now create a outake object with a generateOutake script, Defaults are all 0. The outake is the end of a game pieces travel and as such once it is transfered in the game piece will be rereleased to the world.
* Set the outake size to 14"x3"x2", speed to 14, and leave the rest at 0.
* Now set the angle to -45 and reposition to the end of the stow. If the dropdowns in the top left of the Scene view are set to Pivot, local, the blue arrow will indicate the direction of travel of the game object.
![d60d61da-1d5c-4ad6-a46a-e980fe18e198](https://github.com/user-attachments/assets/5607f184-41be-4fac-bbe3-9797f43a7ed9)

* Now return to the stow object and drag the Outake Object to the endpoint on the generate stow script.
 ![1e202e89-67b9-4354-80d1-6434ec07605c](https://github.com/user-attachments/assets/d6639b1c-e08a-46a2-9d79-6f65df60a60a)
* now press the Scenes button in the top left of the scene view just above the pivot drop downs to return to the Field scene. remember to save if it asks.

## Playing with the robot.
* select GameHandler in the Hierarchy and set the Robot Name to 9999
* Click the play button above the Scene View.
* The robot should work now, but you may notice something.
* The robot doesnt make shots from the subwoofer.
* Use your previous knowledge to fix that.
* (the fix is to adjust the angle of the stow and outake to -55 then correct their positions.

## Iterating the Design
* The next step is to play with the amp
* To do this we are going to create a new object on the robot named OutakeAmp. we will give it the same position angle and size as teh Outake object. Set the Outake Speed to 4.65 and back spin to 4.5
* Now back on stow we are going to add a new endpoint by clicking the plus below the endpoint list. drag outake amp to the new endpoint and the transfer button to Y
* Return and click play and see how it works
![f32d63ca-876d-4c1d-90d7-006cd721f16d](https://github.com/user-attachments/assets/dcca6c90-a4b4-4a09-a403-7a352c4c9b08)

## Introduction To Heirarchy usage and climbers
* in order to climb we need to understand how the heirarchy works. The heirarchy has two types of object references. Parents, and Childs, a parent is an object that has objects inside its "folder". A child, is the objects inside the folder.
* For instance in the photo below. ArmSec1 is a Child of Arm. ArmSec1 is a parent of ClimbElevator(1), and Stationary is a child of ClimbElevator(1).
 ![f220fc6e-64ee-47b2-8858-880c89f74bde](https://github.com/user-attachments/assets/959fa39d-081f-4253-b91f-c81e3c923100)

* So why is this important. well, children of an object will follow their parent. so to get a set of colliders to follow our climb elevator we need to make sure to child it to the correct object on the elevator.
* So create an empty object and add an elevator generator.
* This is by far the most complex generator but is mostly self explanatory. You can set the weight of the non moving part of the elevator, and the weight of the moving part. The only od thing is that if you check stow top, you in essance will visually lose a stage
* Returning to our situation we will set the Height to 15 num of stages to one, and width to 3 so that we can align the hook. Feel free to drop it lower to treat it like a telescopic tube it is not easy to line up child parts if you do though.
* set the stationary weight to 5 and the stage weight to 1.
* set the setpoint to 15.
* Now drag it to one side of the shooter/stow body
* Now, open the climb elevator by clicking the arrow next to it. then stationary > Stage 1. Create an empty object by right clicking stage 1 and name it hook
![44ed85d6-ed1a-44e9-b1fc-8f08076020f7](https://github.com/user-attachments/assets/bf430e82-574e-4a8c-a027-83cfbd5a6447)
* Next add a hook generator to the elevator.
* Set the width to 1, stem Height to 17, bride length to 3 and hook Height to 1.
* Then align it with the cross bridge on the elevator, this is the "stage" it is aligned to middle in the editor for ease of spotting.
* ![439454c0-87f4-4a78-95c7-2b2436488b16](https://github.com/user-attachments/assets/b90c1d8e-c42b-416b-bb1a-f49e921d925f)
* return to the field scene and test.
* The robot likley did not pull of the ground. this is easy to fix, simply click the climbElevator Object the Ctrl C Ctrl V (copy and paste) the game object and drag to the other side. you now have two identical climbers.
*![3581d7ef-6087-471f-a70d-719b5207621b](https://github.com/user-attachments/assets/736ea7ee-77d4-4f3b-96aa-ecdb98a6dc06)


# [Next step](https://github.com/masonmm3/MoSimBuilder/blob/Stable/Documentation/SecondRobot.md)



