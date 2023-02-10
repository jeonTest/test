using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger02 : MonoBehaviour
{
    public Message[] messages;
    public Npc[] npcs;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager02>().OpenDialogue(messages, npcs);
    }
}

[System.Serializable]
public class Message02
{
    public int npcId;
    public string message;
}

[System.Serializable]
public class Npc02
{
    public string name;
}
