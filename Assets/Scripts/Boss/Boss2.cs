using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
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
            levelChanger.ChangeStats(3);
            gameObject.SetActive(false);
        }

    }

}
