using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//component that manages the entity's stats
public class GameEntity : MonoBehaviour
{
    float HP;
    float Damage;
    float Speed;

    bool Invuln = false;
    Action OnHurt;
    Action OnAttack;


    IEnumerable InvulnerabilityWindow()
    {
        Invuln = true;
        yield return new WaitForSeconds(3);
        Invuln = false;
        yield break;
    }

 

    void Attack()
    {
        if(OnAttack != null) 
            OnAttack();
    }
    void Hurt()
    {
        if (Invuln)
            return;

        if (OnHurt != null)
            OnHurt();
    }
    
}

