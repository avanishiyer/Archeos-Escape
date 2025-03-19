using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject door;
    [SerializeField] GameObject bossBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boss.SetActive(true);
            door.SetActive(true);
            bossBar.SetActive(true);
            bossBar.GetComponentInChildren<UIBossBar>().boss = boss;
            Destroy(gameObject);
        }
    }
}
