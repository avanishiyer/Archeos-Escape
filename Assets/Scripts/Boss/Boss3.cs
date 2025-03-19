using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] GameObject point3;
    [SerializeField] GameObject point4;
    [SerializeField] GameObject point5;
    [SerializeField] GameObject point6;

    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] LevelChanger levelChanger;

    private GameObject currentPointSelecetion;
    private GameObject previousPointSelection;
    private bool isTravelling;

    public float speed;
    float step;

    public float coolDown;
    float timePassed;
    bool onCD;

    private void Start()
    {
        isTravelling = false;
        onCD = false;
        enemyHealth.isBoss = false;
    }

    private void Update()
    {
        step = speed * Time.deltaTime;
        if (!onCD)
        {
            while (!isTravelling)
            {
                GameObject chosen = NewChooseRandomPoint();
                if (chosen != currentPointSelecetion
                    && chosen != previousPointSelection
                    && chosen != null)
                {
                    previousPointSelection = currentPointSelecetion;
                    currentPointSelecetion = chosen;
                    isTravelling = true;
                    //Debug.Log("new point");
                }
            }

            if (transform.position != currentPointSelecetion.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPointSelecetion.transform.position, step);
                //Debug.Log("going");
            }
            else
            {
                isTravelling = false;
                onCD = true;
                //Debug.Log("not going");
            }
        }
        else
        {
            if (timePassed < coolDown)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                onCD = false;
                timePassed = 0;
            }
        }

        if (GetComponent<EnemyHealth>().health <= 0f)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<LevelChanger>().ChangeStats(4);
            gameObject.SetActive(false);
        }
    }

    public GameObject NewChooseRandomPoint()
    {
        var random = new System.Random();
        var points = new List<GameObject> { point1, point2, point3, point4, point5, point6 };

        int index = random.Next(points.Count);
        var point = points[index];
        points.RemoveAt(index);
        return point;
    }
}
