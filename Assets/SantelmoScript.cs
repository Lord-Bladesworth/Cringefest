using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantelmoScript : MonoBehaviour
{
    EnemyScript enemyScript;
    AttackBehaviour attackBehaviour;
    private void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        enemyScript.playerReachedAction += Attack;
        attackBehaviour = GetComponent<AttackBehaviour>();
    }

    void Attack()
    {
        StartCoroutine("AttackProcedure");
    }
    IEnumerator AttackProcedure()
    {
        enemyScript.MovementLock = true;
        attackBehaviour.Attack();
        yield return new WaitForSeconds(0.50f);
        enemyScript.MovementLock = false;

    }
}
