using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    [SerializeField] public float maxHealth = 3f;
    [SerializeField] public bool isBoss = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        audioManager.PlaySFX(audioManager.enemyHit);

        if (health <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().UpdateHealth(3f);

            if (!isBoss)
            {
                gameObject.SetActive(false);
                audioManager.PlaySFX(audioManager.enemyDeath);
            }
            else
            {
                audioManager.PlaySFX(audioManager.bossDeath);

                GameObject.FindGameObjectWithTag("Player").GetComponent<LevelChanger>().ChangeStats((SceneManager.GetActiveScene().buildIndex) + 1);
            }
        }
    }
}
