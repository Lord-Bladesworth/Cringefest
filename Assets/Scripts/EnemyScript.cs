using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Transform playertarget;
    
    public Action playerReachedAction;
    public bool MovementLock;


    int Health;
    [SerializeField]
    float MaxTargetDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        playertarget= GameObject.FindObjectOfType<PlayerController>().transform;  
    }
    // Update is called once per frame
    void Update()
    {
        

    }

    private void LateUpdate()
    {
        MoveTowardsPlayer();
        transform.LookAt(new Vector3(playerposition.x,0, playerposition.z));
    }
    Vector3 playerposition;
    void MoveTowardsPlayer()
    {
        if (MovementLock)
            return;
        Debug.Log(Vector3.Distance(transform.position, playerposition));
        playerposition = playertarget.position;

        if (Vector3.Distance(transform.position, playerposition) > MaxTargetDistance)
        {
            playerposition = new Vector3(playerposition.x, 0, playerposition.z);
            transform.position = Vector3.MoveTowards(transform.position, playertarget.position, 0.06f);
        }
        else
        {
            playerReachedAction();
        }
     }
    void damaged(int Damage)
    {
        
    }
}
