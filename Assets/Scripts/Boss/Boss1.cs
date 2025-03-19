using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] LevelChanger levelChanger;

    private void Start()
    {
        enemyHealth.isBoss = true;
    }
    private void Update()
    {
        if (enemyHealth.health <= 0)
        {
            levelChanger.ChangeStats(2);
            gameObject.SetActive(false);
        }
            
    }
}
