using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // damage values
    public float damage = 1f;

    public enum WeaponType { melee, ranged };
    public WeaponType weaponType;

    // if the collider collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (collision.tag == "MeleeEnemy")
        {
            MeleeEnemy meleeEnemy = collision.GetComponent<MeleeEnemy>();

            if (collision == meleeEnemy.hitBox)
            {
                enemyHealth.TakeDamage(damage);
                if (weaponType == WeaponType.ranged) Destroy(gameObject);
            }
        }
        if (collision.tag == "RangedEnemy")
        {
            RangedEnemy rangedEnemy = collision.GetComponent<RangedEnemy>();

            if (collision == rangedEnemy.hitBox)
            {
                enemyHealth.TakeDamage(damage);

                if (weaponType == WeaponType.ranged) Destroy(gameObject);
            }
        }
        if (weaponType == WeaponType.ranged && collision.tag == "Walls") Destroy(gameObject);

    }
}
