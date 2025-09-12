using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Rendering;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField]
    string[] targetTags;
    [SerializeField]
    AttackTypeEnum attackType;
    GameEntity parentEntity;
    Hitbox hitbox;
    int cd = 3; //cooldown
    public Action OnAttack;

    bool hitFlag;
    // Start is called before the first frame update
    void Start()
    {
       hitbox = GetComponentInChildren<Hitbox>();
        if (hitbox == null)
            Debug.LogWarning("Attack script has no hitbox attached!");

        parentEntity = GetComponent<GameEntity>();
        GameObject.FindObjectOfType<TimerManager>().OnTimerTick += OnAttackTick;
    }

    
    void OnAttackTick(float timeElapsed)
    {
       // Debug.Log("Attack tick "+cd);
        if (cd == 0)
        {
            if(attackType == AttackTypeEnum.Auto)
            {
                Attack();
            }

        }
        if (cd > 0)
            cd--;
    }

    GameEntity _currentEntity;
    public void Attack()
    {
        if(OnAttack != null)
        OnAttack();
       // Debug.Log("Attack! "+ hitbox.targets.Count);
        cd = parentEntity.getEntityStats.AttackCooldown;

        if (hitbox.targets.Count < 1)
            return;

        for(int i=0; i< hitbox.targets.Count|| i < parentEntity.getEntityStats.targetLimit;i++)
        {
            _currentEntity = hitbox.targets[i].GetComponent<GameEntity>();
            //DON'T ATTACK YOURSELF && tags that don't count
            if((_currentEntity == parentEntity)&& checktags(_currentEntity.tag))
            {
                continue; 
            }
            if (_currentEntity == null)
                continue;
            _currentEntity.Hurt(parentEntity.getEntityStats.Attack);
           // Debug.Log("Attack successful! target:"+ _currentEntity.name);
        }
    }
    bool checktags(string tag)
    {
        for(int n=0; n< targetTags.Length;n++)
        {
            if(tag == targetTags[n])
            {
                return true;
            }
        }
        return false;
    }

    enum AttackTypeEnum { 
    Auto, Manual
    }



}
