using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    private Transform target;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Controller");
        target = player.transform;
    }

    private void Update()
    {
        gameObject.transform.position = target.position;
    }
}
