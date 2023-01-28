using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchedObject : MonoBehaviour
{
    Quest quest;
    Quest ownQuest;
    public Vector3 newPosition;
    public GameObject questGiver;
    

    void Awake()
    {
        quest = questGiver.GetComponent<Quest>();
        ownQuest = GetComponent<Quest>();
    }


    void Update()
    {
        if(quest.isActive == true && quest.objectFound == true)
        {
            transform.position = newPosition;
            //newPosition = transform.position;
            ownQuest.questDone = true;
        }
    }
}
