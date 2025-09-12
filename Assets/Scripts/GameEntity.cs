using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//component that manages the entity's stats
public class GameEntity : MonoBehaviour
{


    [SerializeField]
    private EntityStatistics baseStats = new EntityStatistics();
    
    EntityStatistics currentStats = new EntityStatistics();
    public EntityStatistics getEntityStats {  get { return currentStats; } }
    bool Invuln = false;
    Action OnHurt;
    Action OnDeath;
    private void Awake()
    {
        currentStats = baseStats;
    }

    public void SpawnIn()
    {
        gameObject.SetActive(true);
    }
    IEnumerable InvulnerabilityWindow()
    {
        Invuln = true;
        yield return new WaitForSeconds(3);
        Invuln = false;
        yield break;
    }
    public void Hurt(int damage)
    {
        if (Invuln)
            return;
        if (OnHurt != null)
        {
            if ((currentStats.Health < 0) && (OnDeath != null))
                 OnDeath();
            
            currentStats.Health -= damage;
            OnHurt();
        }
    }
    public void Victory()
    {

    }
   
}

[System.Serializable]
public class EntityStatistics
{
    
    public int Health;
    public int Attack;
    public int AttackCooldown; //in seconds
    public float MovementSpeed;
    public int targetLimit;
    public bool isInvuln;
}
