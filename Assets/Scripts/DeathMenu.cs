using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] public GameObject deathPanel;
    [SerializeField] public PlayerHealth playerHealth;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlaySFX(audioManager.playerDeath);
    }

    private void Update()
    {
        if (playerHealth.health <= 0)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void RespawnButton()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
