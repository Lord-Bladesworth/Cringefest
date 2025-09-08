using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    SpawnQuadrant _quadrants;
    [SerializeField]
    int MaxEnemySpawn;

    GameObject[] _enemypool;

    [SerializeField]
    int InitialSpawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        _enemypool = new GameObject[MaxEnemySpawn];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
