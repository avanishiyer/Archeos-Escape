using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour, IDataPersistence
{
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] Animator tranistionAnim;
    int currentScene;
    int nextLevel;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);
    }

    public void ChangeStats(int level)
    {
        nextLevel = level;
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        tranistionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(nextLevel);
        Debug.Log(nextLevel);
        switch (currentScene)
        {
            case 1:
                playerHealth.maxHealth = 20f;
                break;

            case 2:
                playerHealth.maxHealth = 25f;
                break;

            case 3:
                playerHealth.maxHealth = 30f;
                break;

            case 4:
                playerHealth.maxHealth = 35f;
                break;

            case 5:
                playerHealth.maxHealth = 45f;
                break;

            default:
                break;
        }
        tranistionAnim.SetTrigger("Start");
    }

    public void LoadData(GameData data)
    {
        nextLevel = data.level;
    }

    public void SaveData(ref GameData data)
    {
        data.level = currentScene;
        Debug.Log(currentScene);
    }
}
