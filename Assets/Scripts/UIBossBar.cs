using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossBar : MonoBehaviour
{
    [SerializeField] GameObject bossBarParent;
    Image bossBar;
    EnemyHealth enemyHealthScript;
    public GameObject boss;
    float maxHealth;
    float currentHealth;

    private void Start()
    {
        bossBar = GetComponent<Image>();
        enemyHealthScript = boss.GetComponent<EnemyHealth>();
        maxHealth = enemyHealthScript.maxHealth;
    }

    private void Update()
    {
        if (boss != null)
        {
            bossBarParent.SetActive(true);
            currentHealth = enemyHealthScript.health;

            bossBar.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            bossBarParent.SetActive(false);
        }
        
    }
}
