using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoaderSceneManager : MonoBehaviour
{

    private void Awake()
    {

    }

    void Start()
    {
        SaveSystem.Init();
        SavedData MyData = new SavedData();

        string JsonText = JsonUtility.ToJson(MyData);
        SaveSystem.Save(JsonText);
    }

}
