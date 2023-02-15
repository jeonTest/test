using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchedObject : MonoBehaviour
{
    Quest quest;
    Quest ownQuest;
    public GameObject questGiver;
    public Transform target;
    NavMeshAgent nav;
    public GameObject destination;

    public Vector3 goal;

    public Animator anim;
    public Animator playerAnim;

    public Vector3 curPos;
    private Vector3 lastPos;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
        ownQuest = GetComponent<Quest>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        StartFollowing();
    }

    void StartFollowing()
    {
        if (curPos == lastPos)
        {
            anim.SetBool("Following", false);
        }
        else
        {
            anim.SetBool("Following", true);
        }
        lastPos = curPos;

        if (quest.isActive == true && quest.objectFound == true && ownQuest.questDone == false)
        {
            nav.SetDestination(target.position);

            curPos = gameObject.transform.position;            
        }

        if(ownQuest.questDone == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, 5 * Time.deltaTime);
        }
    }
}
