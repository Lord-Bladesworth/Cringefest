using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuadrant : MonoBehaviour
{
    public bool ForceQuadrantActive;
    bool isQuadrantActive = false;


    //go with the most braindead solution as possible
    TimerManager timerManager;
    public float LastActivated { get; private set; }
    public bool IsQuadrantActive { get { return isQuadrantActive; } }

    [SerializeField]
    SpawnQuadrant[] neighboringQuadrants;

    SpawnQuadrant[] getNeighbors { get { return neighboringQuadrants; } }

    [SerializeField]
    Transform[] Spawnpoints;
    public Transform[] getQuadrantSpawnpoints { get { return Spawnpoints; } }

    // Start is called before the first frame update
    void Start()
    {
        timerManager = GameObject.FindObjectOfType<TimerManager>();
        if(Spawnpoints.Length ==0 || Spawnpoints == null)
        {
            Debug.LogError("Warning: quadrant " + gameObject.name + " has no spawnpoints assigned!");
        }
        
    }

    private void LateUpdate()
    {
        if (!isQuadrantActive)
            return;
    }
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.tag == "Player")
        {
            isQuadrantActive = true;
            LastActivated = timerManager.getTimeElapsed;
           // Debug.Log(gameObject.name+"Quadrant is now active at "+timerManager.getTimeElapsed);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("Quadrant is no longer active");
            isQuadrantActive = false;
        }
    }
    
}
