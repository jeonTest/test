using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject giver;
    public GameObject target;
    Quest quest;
    Quest ownQuest;

    void Start()
    {
        quest = giver.GetComponent<Quest>();
        ownQuest = target.GetComponent<Quest>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && quest.objectFound == true)
        {
            ownQuest.questDone = true;
        }
    }
}
