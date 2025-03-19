using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RangedEnemyProjectile : MonoBehaviour
{
    Transform player;
    public float upTime = 2;
    float currentUpTime;
    public float damage;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    private Vector3 targetPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPosition = player.position;
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;     
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        if (transform.position == targetPosition)
        {
            if (currentUpTime < upTime)
            {
                currentUpTime += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
            Destroy(gameObject);
        }
    }
}
