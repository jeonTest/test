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

    private bool start;

    DialogueManager dialogueManager;

    public void Start()
    {
        dialogueBox = GameObject.Find("UI/DialogueBox");
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
        if(start == false)
        {
            dialogueBox.SetActive(false);
        }

        if(playerNear == true)
        {
            start = true;
        }

        if(playerNear == false)
        {
            dialogueManager.isActive = false;
            start = false;
        }

        if (active == true && playerNear == true)
        {
            dialogueBox.SetActive(true);
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, npcs);
            dialogueManager.seconds += Time.deltaTime;
            dialogueManager.NextMessage();        
        } 

        if (active == false && start == true)
        {
            dialogueBox.SetActive(false);
            dialogueManager.seconds = 0;
            dialogueManager.activeMessage = 0;
            dialogueManager.spawning += Time.deltaTime;
            if (dialogueManager.spawning >= dialogueManager.readTime)
            {
                dialogueManager.isActive = true;
                dialogueManager.spawning = 0;
            }
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
