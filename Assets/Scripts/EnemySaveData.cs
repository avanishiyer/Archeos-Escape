using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaveData : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField] EnemyHealth enemyHealth;
    float savedHealth;
    Vector3 savedPosition;
    bool savedAlive;

    public void LoadData(GameData data)
    {
        //data.enemyPositions.TryGetValue(id, out savedPosition);
        //data.enemyHealth.TryGetValue(id, out savedHealth);
        //data.enemyIsAlive.TryGetValue(id, out savedAlive);
        
        //enemyHealth.health = savedHealth;
        //transform.position = savedPosition;
        //gameObject.SetActive(savedAlive);
        
    }

    public void SaveData(ref GameData data)
    {
        //if (data.enemyPositions.ContainsKey(id)) data.enemyPositions.Remove(id);
        //if (data.enemyHealth.ContainsKey(id)) data.enemyHealth.Remove(id);
        //if (data.enemyIsAlive.ContainsKey(id)) data.enemyIsAlive.Remove(id);

        //data.enemyPositions.Add(id, transform.position);
        //data.enemyHealth.Add(id, enemyHealth.health);
        //data.enemyIsAlive.Add(id, gameObject.activeSelf);
    }
}
