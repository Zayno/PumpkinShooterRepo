
using System;
[Serializable]
public class SavedData
{
    public SavedData()
    {
        //defaults
        Record_High_Score = 999;
        Cannon_Turn_Speed = 45.0f;
        Ball_Speed = 20.0f;
        Version_Number = "1.1.1";
        Game_Length_Seconds = 60;
        Pumpkin_1 = 1;
        Pumpkin_2 = 2;
        Pumpkin_3 = 3;
    }

    public int      Record_High_Score;
    public float    Cannon_Turn_Speed;
    public float    Ball_Speed;
    public string   Version_Number;
    public int      Game_Length_Seconds;

    //we have 4 types of pumpkins. indexed from 1 to 4 inclusive
    public int Pumpkin_1;
    public int Pumpkin_2;
    public int Pumpkin_3;
}
