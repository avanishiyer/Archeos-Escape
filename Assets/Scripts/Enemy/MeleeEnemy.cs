using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] public Collider2D hitBox;
    [SerializeField] public Collider2D attackRange;


    [SerializeField] private float attackDamage = 2f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    
    private void Start()
    {
        canAttack = attackSpeed;
    }

    private void FixedUpdate()
    {
        if (canAttack < attackSpeed)
        {
            canAttack += Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.IsTouching(attackRange))
            {
                AttackPlayer(collision);
            }
        }
    }

    public void AttackPlayer(Collider2D collidedPlayer)
    {
        if (collidedPlayer.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collidedPlayer.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
        }
    }
}
