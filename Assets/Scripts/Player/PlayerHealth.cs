using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    public float health = 0f;
    [SerializeField] public float maxHealth;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (mod < 0)
            audioManager.PlaySFX(audioManager.takeDamage);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            health = 0f;
            Debug.Log("Player dead");
        }


        Debug.Log("Player Health: " + health);
    }

    public void LoadData(GameData data)
    {
        //health = data.playerHealth;
    }

    public void SaveData(ref GameData data)
    {
        //data.playerHealth = health;
    }
}
