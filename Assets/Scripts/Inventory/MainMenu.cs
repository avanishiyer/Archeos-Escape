using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, IDataPersistence
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameBut;
    [SerializeField] private Button contGameBut;
    private int levelToLoad;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        if (levelToLoad == 0)
        {
            contGameBut.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();

        DataPersistenceManager.instance.NewGame();

        SceneManager.LoadSceneAsync(1);
    }

    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        
        if (levelToLoad == 0) SceneManager.LoadSceneAsync(1);
        else SceneManager.LoadSceneAsync(levelToLoad);
    }

    public void QuitGame()
    {
        DisableMenuButtons();

        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        newGameBut.interactable = false;
        contGameBut.interactable = false;
    }

    public void LoadData(GameData gameData)
    {
        levelToLoad = gameData.level;
    }
    public void SaveData(ref GameData gameData)
    {
        // nothing
    }

    public void PlaySoundOnClick()
    {
        audioManager.PlaySFX(audioManager.menuClick);
    }
}
