using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataController : MonoBehaviour
{
    //implements singleton pattern. this object will live after loading other scenes.
    private static SaveDataController _instance;
    public static SaveDataController Instance { get { return _instance; } }

    public SavedData MyData = new SavedData();

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        SaveSystem.Init();

        DontDestroyOnLoad(this.gameObject);

        if (File.Exists(SaveSystem.SAVE_FOLDER + SaveSystem.FILE_NAME))
        {
            MyData = JsonUtility.FromJson<SavedData>(SaveSystem.Load());
        }

    }

    private void Start()
    {
        SceneManager.LoadScene("StartMenu");
    }



}
