using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore = null;
    [SerializeField] private Text _versionNumber = null;
    [SerializeField] private Text DebugInfo = null;
    // Start is called before the first frame update
    void Start()
    {
        _highScore.text = AppLifeSaveData.HighScore.ToString();
        _versionNumber.text = SaveDataController.Instance.MyData.Version_Number.ToString();
        if(File.Exists(SaveSystem.SAVE_FOLDER + SaveSystem.FILE_NAME))
        {
            DebugInfo.text = "JSON file Found here: " + SaveSystem.SAVE_FOLDER + SaveSystem.FILE_NAME;
            DebugInfo.color = Color.white;
        }
        else
        {
            DebugInfo.text = "CAN'T FIND JSON file. PLEASE PLACE HERE: " + SaveSystem.SAVE_FOLDER + SaveSystem.FILE_NAME;
            DebugInfo.color = Color.yellow;


        }
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

}
