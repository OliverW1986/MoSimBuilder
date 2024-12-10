# Creating Your First Robot

## Adding a robot
* In the Resources/Robots folder right click the project view.
* Find the Create > menu
* then find the Prefab button in the submenu, click it to create a new prefab.
* When you click it should create a new file and allow you to name it, name it 9999 and hit enter
  ![image](https://github.com/user-attachments/assets/ac7dfc7e-0e68-49dd-a7f6-5eaf9777887a)

## Setting up the driveTrain
* double click the 9999 prefab (the file you just made is known as a prefab)
* Once in it look to the inspector screen and add a GenerateDriveTrain scipt by clicking add Component then searching for it.
* now if you double click 9999 on the heirarchy you should see the robot.
* Make sure to disable auto save which is found in the top right of the scene view to avoid any makor issues. (dont forget to save frequently though)
  ![image](https://github.com/user-attachments/assets/b521b7ce-e8e5-457a-9ed1-c3f965515bb4)
* Now we are going to fill out the fields, we are going to make the robot frame 27"x27". the wheels 1.5" wide by 4" diameter. A weight of 65lbs, a drive force of 300, and a bumper height of 4. enjoy watching the script change everything for you.
![image](https://github.com/user-attachments/assets/12bd97f1-7cd0-4cbc-8ceb-ceae38719b42)

##GamePieces
* right click the 9999 object in the Hierarchy, and select create empty Name it intake.
* The blue arrow in the scene view when selecting 9999 indicates the front.
  ![image](https://github.com/user-attachments/assets/fce78031-84c8-42a7-a3fd-ab431852a162)
* select the intake object you created and add a generate intake component
* The default size is 0"x0"x0" so we will adjust it to be 15"x4"x3"
* Then move the arrows that are visible when intake is selected to move the object to the rear of the robot and position it to be just inside the frame
 ![image](https://github.com/user-attachments/assets/e22d9e1e-c792-4d6a-b966-91bebd8224ac)
* next we want to setup the intake controls. Set the button to Lt and the Intake type to Hold. The intake type controls the behaviour of button actions.
  ![image](https://github.com/user-attachments/assets/39c41937-5557-42b9-ada6-67ee1d24ff56)
* Now create another empty object this time named stow.
* add a generate stow component
* Again the default is 0"x0"x0" this time set it to 14"x3"x14"
* at the top of the inspector window is the Transform component, all objects have this. it can be used to set percise locations. use it to set the angle to -45,0,0
* Then reposition the stow such that the intake would transfer smoothly into it.
* now return to the Intake object on the generator script is a line called Transfer to Stow, drag the stow object you just made into it. this is the transfer system. it allows you to move objects from an intake to a stow to another stow or outake.
* Now returning to the Stow Object, we want to set the transfer button to Rt, presses to transfer is 1, and transfer type is button.
  ![image](https://github.com/user-attachments/assets/53373702-1fac-4ee4-9b0f-7764fdaf7fe7)
* now create a outake object with a generateOutake script, Defaults are all 0. The outake is the end of a game pieces travel and as such once it is transfered in the game piece will be rereleased to the world.
* Set the outake size to 14"x3"x2", speed to 14, and leave the rest at 0.
* Now set the angle to -45 and reposition to the end of the stow. If the dropdowns in the top left of the Scene view are set to Pivot, local, the blue arrow will indicate the direction of travel of the game object.
![image](https://github.com/user-attachments/assets/d60d61da-1d5c-4ad6-a46a-e980fe18e198)
* Now return to the stow object and drag the Outake Object to the endpoint on the generate stow script.
  ![image](https://github.com/user-attachments/assets/1e202e89-67b9-4354-80d1-6434ec07605c)
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
![image](https://github.com/user-attachments/assets/f32d63ca-876d-4c1d-90d7-006cd721f16d)




