using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    SpawnQuadrant[] _quadrants;
   

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] EnemyType[] enemyTypes;

    GameObject[] _enemyPool;

    Queue<int> poolIndex;

    [SerializeField]
    int MaxEnemySpawn;
    [SerializeField]
    int InitialSpawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        poolIndex = new Queue<int>();
        _quadrants = GameObject.FindObjectsByType<SpawnQuadrant>(FindObjectsSortMode.None);
    }
    float spawnTimer = 0;
    [SerializeField]
    int baseSpawnTime;
    float timePassed = 0;

    void PoolEnemies()
    {
        _enemyPool = new GameObject[MaxEnemySpawn];
        for(int i=0; i< MaxEnemySpawn; i++)
        {
            _enemyPool[i] = Instantiate(_enemyPrefab,gameObject.transform);
            _enemyPool[i].SetActive(false);
        }
    }
    private void Awake()
    {
        PoolEnemies();
    }

    float spawnTimeLapsed = 15;
    private void LateUpdate()
    {
        timePassed += Time.deltaTime;
        
        if(timePassed > spawnTimeLapsed)
        {
            SpawnEnemyQuadrants();
            timePassed = 0;
        }
    }

    void SpawnEnemyQuadrants()
    {
        Debug.Log("quadrants count:" + _quadrants.Length);
        for(int i=0; i< _quadrants.Length; i++)
        {
            if (_quadrants[i].isActiveAndEnabled)
            {
                SpawnEnemyInQuadrant(_quadrants[i], 2);
                break;
            }
        }
    }
    
    void SpawnEnemyInQuadrant(SpawnQuadrant quadrant, int enemiestoSpawn)
    {
        Debug.Log("spawning: " + enemiestoSpawn);
        for(int i=0; i< _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf)
                poolIndex.Enqueue(i);
        }
        Debug.Log("Queue size: " + poolIndex.Count);
        while (poolIndex.Count!=0)
        {
         for(int spawns = 0; spawns< quadrant.getQuadrantSpawnpoints.Length;spawns++)
            {
                int _index = poolIndex.Dequeue();
                _enemyPool[_index].SetActive(true);
                _enemyPool[_index].transform.position = quadrant.getQuadrantSpawnpoints[spawns].position;
                Debug.Log("Activating index: " + _index);
            }
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(50, 200, 100, 100), timePassed.ToString());
    }

}

[Serializable]
public class EnemyType
{
    public GameObject prefab;
    [Range(0,1)]
    public float Occurence;
}