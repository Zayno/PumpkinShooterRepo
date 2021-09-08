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

    [Tooltip("How long to wait after a hit to respawn a pumpkin?")]
    [SerializeField] private float DelayBeforeRespawning = 3.0f;


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

    }

    public void DelayedRespawn(EnemySpawner.SpawnNumber num)
    {

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
        AppLifeSaveData.CurrentScore++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
