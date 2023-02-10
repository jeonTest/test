using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesNear : MonoBehaviour
{
    public bool playerNear;
    public float distance;
    public float dist;


    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("NPC").transform;
        dist = Vector3.Distance(playerObj.position, transform.position);

        if (dist <= distance)
        {
            playerNear = true;
        }
        else
        {
            playerNear = false;
        }
    }
}
