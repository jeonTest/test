using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverQuest : MonoBehaviour
{
    public GameObject river;
    public GameObject questGiver;
    Quest quest;


    void Start()
    {
        river.GetComponent<ObjectColor>().enabled = false;
        quest = questGiver.GetComponent<Quest>();
    }


    void Update()
    {
        QuestStarted();
    }

    public void QuestStarted()
    {
        if(quest.isActive == true)
        {
            river.GetComponent<ObjectColor>().enabled = true;
        }
    }
}
