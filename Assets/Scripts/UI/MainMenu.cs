using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        DebugInfo.text = "JSON file path needed: " + SaveSystem.SAVE_FOLDER + SaveSystem.FILE_NAME;
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

}
