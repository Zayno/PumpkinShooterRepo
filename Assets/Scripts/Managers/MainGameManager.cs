using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    private static MainGameManager _instance;
    public static MainGameManager Instance { get { return _instance; } }

    [SerializeField] private EnemySpawner Spawner_1;
    [SerializeField] private EnemySpawner Spawner_2;
    [SerializeField] private EnemySpawner Spawner_3;
    [SerializeField] private List<Enemy> EnemyPrefabList;
    [SerializeField] private GameSession _gameSession = null;

    [Tooltip("How long to wait after a hit to respawn a pumpkin?")]
    [SerializeField] private float DelayBeforeRespawning = 3.0f;
    public int SessionScore = 0;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        if(SaveDataController.Instance)
        {
            //TODO: add validation to make sure prefabs exist and the json is valid
            Spawner_1.SetEnemyPrefab(EnemyPrefabList[SaveDataController.Instance.MyData.Pumpkin_1 - 1]);
            Spawner_2.SetEnemyPrefab(EnemyPrefabList[SaveDataController.Instance.MyData.Pumpkin_2 - 1]);
            Spawner_3.SetEnemyPrefab(EnemyPrefabList[SaveDataController.Instance.MyData.Pumpkin_3 - 1]);
        }

        _gameSession.OnSessionEnd += HandleSessionEnded;
        SessionScore = 0;

    }

    IEnumerator DelayedRespawn(EnemySpawner.SpawnNumber num, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (num == EnemySpawner.SpawnNumber.First)
        {
            Spawner_1.SpawnEnemy();
        }
        else if (num == EnemySpawner.SpawnNumber.Second)
        {
            Spawner_2.SpawnEnemy();
        }
        else if (num == EnemySpawner.SpawnNumber.third)
        {
            Spawner_3.SpawnEnemy();
        }
    }

    public void OnPumpkinHit(EnemySpawner.SpawnNumber num)
    {
        StartCoroutine(DelayedRespawn(num, DelayBeforeRespawning));
        SessionScore++;
    }

    void HandleSessionEnded()
    {
        _gameSession.OnSessionEnd -= HandleSessionEnded;

        if(SessionScore > AppLifeSaveData.HighScore)
        {
            AppLifeSaveData.HighScore = SessionScore;
        }
    }
}
