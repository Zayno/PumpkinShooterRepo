# PumpkinShooterRepo
Pumpkin Shooter


*Changes:
* Added “PreLoad” scene. This scene needs to be the first one to run. It initializes the game and creates the lifetime objects for the other scenes.
* Moved pumpkin prefabs out of the resources folder. That folder shouldnt be used for prefabs in general.
* Implemented JSON functionality to read/write the save data.
* The loaded json data controls all game aspects and it gets loaded dynamically at runtime.
* Created a game manager that manages the gameplay.
* Added Auto Aim. It aims at the spawn point using a constant speed you can set in the inspector.
* Changed some physics issues. Pumpkins need to be kinematic until hit. 
* Cached all objects that could be reused. Instead of finding/getting it everytime.
* Make sure the JSON file is available and in the correct directory “Game_Data\Saves\SaveData.json”. You will get a notification if can’t be found. 
* Made all the changes from the document.

Resources used: only unity API resources. Mainly JSON and vector math ones.


