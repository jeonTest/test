using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueBrushGame : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject dialogueBox;
    public string npcName;
    public string[] dialogue;
    public string[] afterQuestDialogue;

    public int dialogueNumber;

    public bool playerNear;

    public float talkingDistance = 4;

    Quest quest;


    public void Start()
    {
        dialogueBox.SetActive(false);
        playerNear = false;
        SetName();
    }
    
    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
        quest = GetComponent<Quest>();
    }

    public void Update()
    {
        distanceToPlayer();
        if (quest.questDone == false)
        {
            if (dialogueNumber >= dialogue.Length || playerNear == false)
            {
                dialogueBox.SetActive(false);
                dialogueNumber = 0;
            }
        }
        else if (quest.questDone == true)
        {
            if (dialogueNumber >= afterQuestDialogue.Length || playerNear == false)
            {
                dialogueBox.SetActive(false);
                dialogueNumber = 0;
            }
        }
            SetDialogue(dialogueNumber);
    }

    private void OnStartDialogue()
    {
        if (playerNear == true)
        {
            dialogueBox.SetActive(true);
        }
    }

    private void OnSkipDialogue()
    {
        if (quest.questDone == false)
        {
            if (dialogueBox.activeSelf == true && dialogueNumber < dialogue.Length)
            {
                dialogueNumber += 1;
            }
        }
        else if (quest.questDone == true)
        {
            if (dialogueBox.activeSelf == true && dialogueNumber < afterQuestDialogue.Length)
            {
                dialogueNumber += 1;
            }
        }
    }

    public void SetName()
    { 
        GameObject npc = dialogueBox.transform.GetChild(0).gameObject;
        npc.GetComponent<TextMeshPro>().text = npcName;
    }

    public void SetDialogue(int i)
    {
        GameObject diaText = dialogueBox.transform.GetChild(1).gameObject;
        if (quest.questDone == false)
        {
            diaText.GetComponent<TextMeshPro>().text = dialogue[i];
        }
        else if(quest.questDone == true)
        {
            diaText.GetComponent<TextMeshPro>().text = afterQuestDialogue[i];
        }
    }

    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(playerObj.position, transform.position);

        if (dist <= talkingDistance)
        {
            playerNear = true;
        }
        else
        {
            playerNear = false;
        }
    }
}
