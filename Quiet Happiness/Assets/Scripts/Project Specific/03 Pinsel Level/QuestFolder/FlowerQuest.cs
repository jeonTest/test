using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerQuest : MonoBehaviour
{
    public bool coloured = false;
    public GameObject white;
    public GameObject colouredObj;
    Quest quest;

    void Awake()
    {
        quest = GetComponent<Quest>();
    }

    void Start()
    {
        if (coloured == false)
            colouredObj.SetActive(false);
    }

    void Update()
    {
        CheckQuest();
        if (coloured == true)
        {
            colouredObj.SetActive(true);
            white.SetActive(false);
        }
    }

    public void CheckQuest()
    {
        if(quest.questDone == true)
        {
            coloured = true;
        }
    }
}
