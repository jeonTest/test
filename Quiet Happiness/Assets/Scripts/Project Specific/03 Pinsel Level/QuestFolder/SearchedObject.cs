using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchedObject : MonoBehaviour
{
    Quest quest;
    Quest ownQuest;
    public Vector3 newPosition;
    public GameObject questGiver;
    public Transform target;
    NavMeshAgent nav;
    public GameObject destination;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
        ownQuest = GetComponent<Quest>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        /*if(quest.isActive == true && quest.objectFound == true)
        {
            transform.position = newPosition;
            //newPosition = transform.position;
            ownQuest.questDone = true;
        }*/

        StartFollowing();
    }



    void StartFollowing()
    {
        if(quest.isActive == true && quest.objectFound == true && ownQuest.questDone == false)
        {
            nav.SetDestination(target.position);
        }
    }
}
