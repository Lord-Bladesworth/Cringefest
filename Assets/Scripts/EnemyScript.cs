using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this only handles movement. for entity thingies, head over to the GameEntity class
public class EnemyScript : Controller 
{
    Transform playertarget;
    
    GameEntity gameEntity;
    public Action playerReachedAction;
    public bool MovementLock;


    [SerializeField]
    float MaxTargetDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameEntity = GetComponent<GameEntity>();
        playertarget= GameObject.FindObjectOfType<PlayerController>().transform;  
    }

    private void LateUpdate()
    {
        MoveTowardsPlayer();
        transform.LookAt(new Vector3(playerposition.x,1, playerposition.z));
    }
    Vector3 playerposition;
    void MoveTowardsPlayer()
    {
        if (MovementLock)
            return;
       // Debug.Log(Vector3.Distance(transform.position, playerposition));
        playerposition = playertarget.position;

        if (Vector3.Distance(transform.position, playerposition) > MaxTargetDistance)
        {
            playerposition = new Vector3(playerposition.x, 0, playerposition.z);
            transform.position = Vector3.MoveTowards(transform.position, playertarget.position, gameEntity.getEntityStats.MovementSpeed);
        }
        else
        {
            if(playerReachedAction!= null)
            playerReachedAction();
        }
     }

}
