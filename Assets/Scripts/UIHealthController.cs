using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthController : MonoBehaviour
{
    Image healthBar; 
    PlayerHealth playerHealthScript;
    float maxHealth;
    float currentHealth;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        playerHealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        maxHealth = playerHealthScript.maxHealth;
    }

    private void Update()
    {
        currentHealth = playerHealthScript.health;

        healthBar.fillAmount = currentHealth / maxHealth; 
    }
}
