using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToSpawn : MonoBehaviour
{
    private void Start()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        player.position = transform.position;
    }
}
