using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] GameObject spiderPrefab;
    [SerializeField] GameObject huskPrefab;
    [SerializeField] GameObject skeletonPrefab;
    [SerializeField] GameObject witchPrefab;
    [SerializeField] public int spidersToSpawn;
    [SerializeField] public int husksToSpawn;
    [SerializeField] public int skeletonsToSpawn;
    [SerializeField] public int witchsToSpawn;
    [SerializeField] float spawnCD = 7f;
    [SerializeField] GameObject boss;
    float timePassed;
    bool minionsDead;

    private void Start()
    {
        timePassed = 5f;
        minionsDead = true; ;
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
        for (int i = 0; i < spidersToSpawn; i++)
        {
            Instantiate(spiderPrefab, boss.transform.position, Quaternion.identity, transform);
        }

        for (int i = 0; i < skeletonsToSpawn; i++)
        {
            Instantiate(skeletonPrefab, boss.transform.position, Quaternion.identity, transform);
        }

        for (int i = 0; i < husksToSpawn; i++)
        {
            Instantiate(huskPrefab, boss.transform.position, Quaternion.identity, transform);
        }

        for (int i = 0; i < witchsToSpawn; i++)
        {
            Instantiate(witchPrefab, boss.transform.position, Quaternion.identity, transform);
        }
    }
}
