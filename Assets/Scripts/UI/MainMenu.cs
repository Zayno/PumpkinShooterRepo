using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore = null;
    [SerializeField] private Text _versionNumber = null;
    // Start is called before the first frame update
    void Start()
    {
        _highScore.text = SaveDataController.Instance.MyData.Record_High_Score.ToString();
        _versionNumber.text = SaveDataController.Instance.MyData.Version_Number.ToString();
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
