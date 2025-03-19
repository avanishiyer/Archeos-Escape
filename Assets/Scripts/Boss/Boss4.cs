using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    [SerializeField] GameObject bossBar;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] LevelChanger levelChanger;

    private void Start()
    {
        bossBar.GetComponentInChildren<UIBossBar>().boss = gameObject;
        enemyHealth.isBoss = true;
    }

    private void Update()
    {
        if (enemyHealth.health <= 0)
        {
            levelChanger.ChangeStats(5);
            gameObject.SetActive(false);
        }

    }
}
