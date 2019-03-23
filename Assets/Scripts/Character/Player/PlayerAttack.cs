using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeSinceLastAttack;
    public float minTimeBetweenAttacks;
    public Animator animator;

    public Transform attackPosition;
    public LayerMask enemyCollisionLayer;
    public float attackRange;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastAttack <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                animator.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyCollisionLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log("Hit enemy");
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(1);
                }

            }
            timeSinceLastAttack = minTimeBetweenAttacks;
        }
        else
        {
            timeSinceLastAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
