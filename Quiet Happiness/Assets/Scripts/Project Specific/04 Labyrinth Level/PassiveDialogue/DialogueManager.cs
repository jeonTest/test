using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI messageText;
    public float readTime = 5;
    public bool isActive = true;

    private Message[] currentMessages;
    private Npc[] currentNpcs;
    public int activeMessage = 0;
    public float seconds = 0;


    public void OpenDialogue(Message[] messages, Npc[] npcs)
    {
        currentMessages = messages;
        currentNpcs = npcs;
        isActive = true;
        DisplayMessage();
    }

    public void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Npc npcToDisplay = currentNpcs[messageToDisplay.npcId];
        npcName.text = npcToDisplay.name;
    }

    public void NextMessage()
    {
        if(seconds >= 5)
        {
            activeMessage++;
            seconds = 0;
        }

        if (activeMessage == currentMessages.Length-1 && seconds >= 4)
        {
            isActive = false;
        }
        else
        {
            DisplayMessage();
        }
    }

    public void Update()
    {
        if (isActive == true )
        {
            seconds += Time.deltaTime;
            NextMessage();
        }
    }

    public void OnEnable()
    {
        seconds = 0;
        activeMessage = 0;
    }
}
