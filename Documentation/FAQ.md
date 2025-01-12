# FAQ
### how do I play
 * at the top of the scene view you will see a play button. click that button to begin playing in the editor
   ![image](https://github.com/user-attachments/assets/c1e5f451-6f25-45d7-9e37-0978e21d68ba)

### Stretching mechanisms.
 * there are two kinds of stretching, one cant be avoided but the other is a simple mistake.
 * The one that can be avoided is a result of losing scale, which happens if you creat a game object as a child of one of the model objects
  ![image](https://github.com/user-attachments/assets/a41a59cf-13a0-47f3-a55b-380a65a5e1df)
 * pictured above is what this looks like.
 * the other kind of stretch is usually charachterized by mechanisms not staying in place when under load, this is an issue with unity.

### My robot Mechanism is stiff or freaks out
 * This is usually a result of stacked DOF. Unity does not appreceate stacking more than 4 dof. (elevators always count as 2)
 * This also can happen when putting elevators on arms. if the elevators size is larger than that of the arm, or not centered you may have to adjust your weights to keep it from flopping.

### treat it like real life and it should behave
