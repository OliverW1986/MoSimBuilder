# Missing Details and Misc.

There are a few features that were not covered. They are mostly the advanced sequencing tools which require more complex robots than reasonably coverable in this guide. Fortunatly, I left several Example robots to be used 
as help when referencing the next set of information.

## Sequencing motion of subsystems
* The final mode for movement is Sequence. This mode is really helpful when something requires multiple steps. it can also allow for toggles on things that require multiple presses.
* The system moves down the available setpoints starting at the top. if a setpoint has a different keybind assinged it is skiped completly. Only setpoints with the same keybind are sequenced together.
![3d1a8d52-6586-4e5c-a197-b28825bea8c5](https://github.com/user-attachments/assets/d4cec4c5-e8f0-4c96-badb-5a1f01e66c98)


  ## Game Piece Sequencing.
  * similar to the motion sequences its possible to create sequences of game piece movement. This is done using "presses to transfer" on a stow object
  * When a stow object has a game piece the presses to transfer is the number of times in a row that button must be pressed to transfer to that buttons relevant endpoint. (endpoints can be other stows or outakes)
  * Transfering between two stows does not count towards the presses. so if you transfer from storage a to b by pressing y and motion system b goes to setpoint by pressing y you only need one press as the first of the two is spent transfering from stow a to b.
![2268dcab-d351-469a-a41c-1ad92ec5a773](https://github.com/user-attachments/assets/e76eb2fd-7193-45e2-8590-797806896cfe)


### This is all of the information needed to competently build robots in MoSim Builder Alpha 1+
 
