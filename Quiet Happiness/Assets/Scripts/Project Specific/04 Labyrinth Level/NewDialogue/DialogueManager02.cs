using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager02 : MonoBehaviour
{
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    private Message[] currentMessages;
    private Npc[] currentNpcs;
    private int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Npc[] npcs)
    {
        currentMessages = messages;
        currentNpcs = npcs;
        activeMessage = 0;

        Debug.Log("Yup: " + messages.Length);
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
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            isActive = false;
        }
    }

    void Update()
    {
        //if (Input && isActive == true)
        //NextMessage();
    }

    public void ButtonTest()
    {
        if(isActive == true)
        {
            NextMessage();
        }
    }
}
