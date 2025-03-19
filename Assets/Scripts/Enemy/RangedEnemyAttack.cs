using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RangedEnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private GameObject spawnedProjectile;

    public void ShootProjectile(Transform enemyTransform)
    {
        Vector3 startLocation = enemyTransform.position;
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        spawnedProjectile = Instantiate(projectile, startLocation, Quaternion.identity);
    }

}
