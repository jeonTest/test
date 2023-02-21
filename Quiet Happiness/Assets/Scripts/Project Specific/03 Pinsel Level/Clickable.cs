using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clickable : MonoBehaviour
{
    public GameObject uiNote;
    public float showDistance;
    private bool playerNear;
    public GameObject questGiver;
    public string hintText;
    public TextMeshProUGUI uiText;

    Quest quest;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
        uiNote.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        ShowNote();
        distanceToPlayer();
    }

    public void ShowNote()
    {
        if(quest.isActive == true && playerNear == true && quest.questDone == false)
        {
            uiText.text = hintText;
            uiNote.LeanScale(Vector3.one, 0.5f);
        }

        if(quest.questDone == true)
        {
            uiNote.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }


    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(playerObj.position, transform.position);

        if (dist <= showDistance)
        {
            playerNear = true;
        }
        else
        {
            playerNear = false;
        }
    }

}
