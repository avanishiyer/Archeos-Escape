using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    NavMeshAgent agent;

    [SerializeField] public Collider2D followRange;
    [SerializeField] public Collider2D stopFollowingRange;

    private Transform target;

    public bool hasLineOfSight = false;
    int layerMask;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        layerMask = 1 << 9;

        if (target != null)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, target.transform.position - transform.position, Mathf.Infinity,layerMask);
            Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.green);

            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                agent.SetDestination(target.position);
            }
            
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.IsTouching(followRange))
            {
                if (collision.IsTouching(stopFollowingRange))
                {
                    target = null;
                }
                else
                {
                    target = collision.transform;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.IsTouching(followRange))
            {
                target = null;
            }
        }
    }
}
