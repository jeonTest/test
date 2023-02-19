using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wimmelbild : MonoBehaviour
{
    public GameObject WimmelbildObj;
    public GameObject SearchedObj;
    public PlayerInput input;
    public GameObject questGiver;

    private bool playerNear = false;
    public float distance = 5;

    Quest quest;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
    }

    void Update()
    {
        distanceToPlayer();
    }

    public void OnInteract()
    {
        if(playerNear == true && quest.isActive == true && quest.questDone == false)
        {
            WimmelbildObj.SetActive(true);
        }
    }

    public void ObjectFound()
    {
        WimmelbildObj.SetActive(false);
        SearchedObj.SetActive(false);
        quest.objectFound = true;
    }


    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(playerObj.position, transform.position);

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
