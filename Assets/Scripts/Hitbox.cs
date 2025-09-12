using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public List<GameObject> targets { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        targets = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GameEntity>())
        {
            targets.Add(other.gameObject);
            //Debug.Log("Enter!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject); 
        
    }
}
