using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossMinionSpawner : MonoBehaviour
{
    [SerializeField] GameObject spiderPrefab;
    [SerializeField] GameObject huskPrefab;
    [SerializeField] GameObject skeletonPrefab;
    [SerializeField] GameObject witchPrefab;

    float spawnCD = 7f;

    [SerializeField] GameObject boss;
    float timePassed;
    bool minionsDead;

    private void Start()
    {
        timePassed = 5f;
    }

    private void Update()
    {
        if (boss.activeSelf)
        {
            if (transform.childCount == 0) minionsDead = true;
            else minionsDead = false;

            if (timePassed >= spawnCD)
            {
                if (minionsDead)
                {
                    SpawnMinons();
                    timePassed = 0f;
                }
            }
            else
            {
                timePassed += Time.deltaTime;
            }
        }
    }

    private void SpawnMinons()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(RandomMinions(), boss.transform.position, Quaternion.identity, transform);
        }
        
    }

    private GameObject RandomMinions()
    {
        var rand = new System.Random();
        var minions = new List<GameObject> { spiderPrefab, huskPrefab, skeletonPrefab, witchPrefab };

        int index = rand.Next(minions.Count);
        var minion = minions[index];
        minions.RemoveAt(index);
        return minion;
    }
}
