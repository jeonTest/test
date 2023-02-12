using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, npcs);
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
