using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AttackBehaviour attackBehaviour;
    [SerializeField]
    MeshRenderer hitbox;
    private void Awake()
    {
        attackBehaviour = GetComponent<AttackBehaviour>();
        attackBehaviour.OnAttack += PlayAttackAnimation;
    }

    void PlayAttackAnimation()
    {
        StartCoroutine(showHitbox());
    }
    IEnumerator showHitbox()
    {
        hitbox.enabled = true;
        yield return new WaitForSeconds(1);
        hitbox.enabled = false;
        
    }

}
