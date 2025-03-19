using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Vector3 currentVelocity;
    Vector3 prevPos;

    [SerializeField] Animator animator;

    private void Awake()
    {
        prevPos = transform.position;
    }

    private void Update()
    {
        currentVelocity = (transform.position - prevPos) / Time.deltaTime;
        //Debug.Log(currentVelocity);
        animator.SetFloat("x", currentVelocity.x);
    }
}
