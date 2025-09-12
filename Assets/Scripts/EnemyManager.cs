using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    SpawnQuadrant[] _quadrants;
   

    [SerializeField] GameObject _enemyPrefab;
   // [SerializeField] EnemyType[] enemyTypes;

    GameObject[] _enemyPool;

    Queue<int> poolIndexQueue;

    [SerializeField]
    int MaxEnemySpawn;
    [SerializeField]
    int SpawnInterval = 7;

    int killtally = 0;
    int getTally { get { return killtally; } }
    // Start is called before the first frame update
    void Start()
    {
        poolIndexQueue = new Queue<int>();
        _quadrants = GameObject.FindObjectsByType<SpawnQuadrant>(FindObjectsSortMode.None);
        TimerManager timer =  GameObject.FindObjectOfType<TimerManager>();
        timer.OnTimerTick += OnTick;
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
            _enemyPool[i].GetComponent<GameEntity>().OnDeath += onEnemyDeath;
        }
    }
    private void Awake()
    {
        PoolEnemies();
    }


    private void LateUpdate()
    {
    }
    private void onEnemyDeath(GameObject enemyObject)
    {
        killtally++;
        enemyObject.SetActive(false);

    }

    public void ClearStage()
    {
        for(int i=0; i< _enemyPool.Length; i++)
        {
            if (_enemyPool[i].activeSelf)
            {
                _enemyPool[i].SetActive(true);
                
            }
        }
        gameObject.SetActive(false);
    }
    private void OnTick(float timeElapsed)
    {
        timePassed++;
        if (timePassed > SpawnInterval)
        {
            SpawnEnemyQuadrants();
            timePassed = 0;
        }
    }

    void SpawnEnemyQuadrants()
    {
       // Debug.Log("quadrants count:" + _quadrants.Length);
        for(int i=0; i< _quadrants.Length; i++)
        {
            if (_quadrants[i].isActiveAndEnabled)
            {
                SpawnEnemyInQuadrant(_quadrants[i], 2,1);
                break;
            }
        }
    }

    SpawnQuadrant lastActive;
    void SpawnEnemyInQuadrant(SpawnQuadrant quadrant, int enemiestoSpawn,int Depth)
    {
      //  Debug.Log("spawning: " + enemiestoSpawn);
        for(int i=0; i< _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf)
                poolIndexQueue.Enqueue(i);
        }
      //  Debug.Log("Queue size: " + poolIndex.Count);

        lastActive =  GetLastActiveQuadrant();
        SpawnInQuadrant(poolIndexQueue, lastActive);

    }

    void SpawnInQuadrant(Queue<int> poolIndex,SpawnQuadrant current,int Depthlevel =0)
    {
        Transform[] quadrants = current.getQuadrantSpawnpoints;
        int _currentIndex;
        for(int i=0; i< quadrants.Length;i++)
        {
            if (poolIndex.Count == 0)
                return;
            _currentIndex = poolIndex.Dequeue();
            _enemyPool[_currentIndex].SetActive(true);
            _enemyPool[_currentIndex].transform.position = quadrants[i].position;
        }
        poolIndex.Clear();
        
    }
    private SpawnQuadrant GetLastActiveQuadrant()
    {
        SpawnQuadrant[] quads = _quadrants;
        return quads.OrderByDescending(x => x.LastActivated).First();
       
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