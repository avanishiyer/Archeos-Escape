using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] public Collider2D attackRange;
    [SerializeField] public Collider2D hitBox;

    [SerializeField] public float attackSpeed = 1f;
    private float canAttack;
    public RangedEnemyAttack rangedEnemyAttack;

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

                LayerMask layerMask = 1 << 9;

                if (collision != null)
                {
                    RaycastHit2D ray = Physics2D.Raycast(transform.position, collision.transform.position - transform.position, Mathf.Infinity, layerMask);
                    Debug.DrawRay(transform.position, collision.transform.position - transform.position, Color.green);

                    bool hasLineOfSight = ray.collider.CompareTag("Player");
                    if (hasLineOfSight)
                    {
                        AttackPlayer(collision);
                    }

                }

            }
        }
    }

    public void AttackPlayer(Collider2D collidedPlayer)
    {
        if (collidedPlayer.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                rangedEnemyAttack.ShootProjectile(gameObject.transform);
                Debug.Log("attacked player");
                canAttack = 0f;
            }
        }
    }
}
