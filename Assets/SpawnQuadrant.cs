using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuadrant : MonoBehaviour
{
    public bool ForceQuadrantActive;
    bool isQuadrantActive = false;

    [SerializeField]
    Transform[] Spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if (!isQuadrantActive)
            return;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
            isQuadrantActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player")
            isQuadrantActive = false; 
    }
}
