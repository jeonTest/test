using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;

    public float distance = 1;
    public bool playerNear;

    private GameObject dialogueBox;

    public float dist;
    public bool active = true;

    DialogueManager dialogueManager;

    public void Start()
    {
        dialogueBox = GameObject.Find("UI/PassiveDialogue");
        dialogueManager = dialogueBox.GetComponent<DialogueManager>();
    }


    public void Update()
    {
        active = dialogueManager.isActive;
        StartDialogue();
        distanceToPlayer();
    }

    public void StartDialogue()
    {
        if (playerNear == true && active == true)
        {
            dialogueBox.SetActive(true);
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, npcs);
        }

        if((playerNear == false && active == false) || playerNear == false)
        {
            dialogueBox.SetActive(false);
        }
        
    }

    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        dist = Vector3.Distance(playerObj.position, transform.position);

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

[System.Serializable]
public class Message
{
    public int npcId;
    public string message;
}

[System.Serializable]
public class Npc
{
    public string name;
}
