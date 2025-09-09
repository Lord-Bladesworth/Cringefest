using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuadrant : MonoBehaviour
{
    public bool ForceQuadrantActive;
    bool isQuadrantActive = false;

    public bool IsQuadrantActive { get { return isQuadrantActive; } }

    [SerializeField]
    Transform[] Spawnpoints;
    public Transform[] getQuadrantSpawnpoints { get { return Spawnpoints; } }

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            isQuadrantActive = true;
            Debug.Log("Quadrant is now active!");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Quadrant is no longer active");
            isQuadrantActive = false;
        }
    }
}
