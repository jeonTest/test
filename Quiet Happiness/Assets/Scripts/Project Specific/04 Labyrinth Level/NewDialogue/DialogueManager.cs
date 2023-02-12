using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    private Message[] currentMessages;
    private Npc[] currentNpcs;
    private int activeMessage = 0;
    public static bool isActive = false;

    public float readTime = 5;
    private float seconds;

    public void OpenDialogue(Message[] messages, Npc[] npcs)
    {
        currentMessages = messages;
        currentNpcs = npcs;
        activeMessage = 0;

        Debug.Log("Yup: " + messages.Length);
        isActive = true;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
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

        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (isActive == true)
        {
            seconds += Time.deltaTime;

            if (seconds >= readTime)
            {
                seconds = 0;
                NextMessage();
            }
        }
    }
}
