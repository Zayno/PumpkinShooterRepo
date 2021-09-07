using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem 
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static readonly string FILE_NAME = "SaveData.json";

    public static void Init()
    {
        if(!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string JsonStringToSave)
    {
        File.WriteAllText(SAVE_FOLDER + FILE_NAME, JsonStringToSave);
    }

    public static string Load()
    {
        if(File.Exists(SAVE_FOLDER + FILE_NAME))
        {
            string LoadedString = File.ReadAllText(SAVE_FOLDER + FILE_NAME);
            return LoadedString;
        }
        else
        {
            return null;
        }
    }
}
