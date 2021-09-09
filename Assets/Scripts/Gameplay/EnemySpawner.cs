using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnNumber {none, First, Second, third};

    [SerializeField] private Transform _spawnPoint = null;

    [SerializeField] private Enemy _enemyPrefab = null;

    [SerializeField] private SpawnNumber MyNumber = SpawnNumber.none;

    private Enemy _lastSpawned = null;


    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        _lastSpawned = Instantiate( _enemyPrefab, _spawnPoint.position, _spawnPoint.rotation );
        _lastSpawned.MySpawnNumber = MyNumber;
    }

    public void SetEnemyPrefab(Enemy NewEnemy)
    {
        if(_lastSpawned)
        {
            Destroy(_lastSpawned);
        }

        _enemyPrefab = NewEnemy;

        SpawnEnemy();
    }
}
