using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSnail : MonoBehaviour
{
    public GameObject questGiver;
    public GameObject reward;
    Quest quest;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
    }
   
    void Update()
    {
        if(quest.questDone == true)
        {
            reward.SetActive(true);
        }
    }
}
