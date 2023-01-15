using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueBrushGame : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject dialogueBox;
    public bool questStarter = true;


    public string npcName;
    public string[] dialogue;
    public string[] afterQuestDialogue;

    public bool startQuest = false;

    private GameObject diaText;

    public int dialogueNumber;

    public bool playerNear;

    public float talkingDistance = 4;

    [Header("Multi Choices")]

    public bool rightAnswer;
    public GameObject answerButtons;
    public string wrongText = "Leider falsch";

    Quest quest;
    Answers answerA;
    Answers answerB;
    Answers answerC;
    

    public bool Waiting = false;
    public bool nextTry = false;
    public string textMesh;

    public void Start()
    {
        if (questStarter == false)
        {
            dialogueBox.SetActive(false);
        }
        if (questStarter == false)
        {
            answerButtons.SetActive(false);
        }
        playerNear = false;
        SetName();
    }
    
    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
        diaText = dialogueBox.transform.GetChild(1).gameObject;
        if (questStarter == true)
        {
            quest = GetComponent<Quest>();
        }
        answerA = GameObject.Find("AnswerA").GetComponent<Answers>();
        answerB = GameObject.Find("AnswerB").GetComponent<Answers>();
        answerC = GameObject.Find("AnswerC").GetComponent<Answers>();

    }

    public void QuestAnswers()
    {
        if (answerA.finished == true || answerB.finished == true || answerC.finished == true)
            rightAnswer = true;

    }

    public void Update()
    {
        textMesh = diaText.GetComponent<TextMeshPro>().text;
        if (textMesh == wrongText)
        {
            nextTry = true;
        }

        distanceToPlayer();
        if (questStarter == true)
        {
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
        }
        else if(questStarter == false)
        {
            if (dialogueNumber >= dialogue.Length || playerNear == false)
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
        if (Waiting == false)
        {
            if (questStarter == true)
            {
                if (quest.questDone == false)
                {
                    if (dialogueBox.activeSelf == true && dialogueNumber < dialogue.Length)
                    {
                        dialogueNumber += 1;
                        startQuest = true;
                        quest.isActive = true;
                    }

                    if(startQuest == false && dialogueNumber == dialogue.Length - 1)
                    {
                        startQuest = true;
                        quest.isActive = true;
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
            else if (questStarter == false)
            {
                if (dialogueBox.activeSelf == true && dialogueNumber < dialogue.Length)
                {
                    dialogueNumber += 1;
                    if (dialogueNumber == dialogue.Length - 2)
                    {
                        answerButtons.SetActive(true);
                        Waiting = true;
                    }
                }
            }
        }

        else if(Waiting == true && nextTry == true)
        {
            dialogueNumber -= 1;
            Waiting = false;
            answerA.answerClicked = false;
            answerB.answerClicked = false;
            answerC.answerClicked = false;
        }
    }

    public void SetName()
    { 
        GameObject npc = dialogueBox.transform.GetChild(0).gameObject;
        npc.GetComponent<TextMeshPro>().text = npcName;
    }

    public void SetDialogue(int i)
    {
        
        if (questStarter == true)
        {
            if (quest.questDone == false)
            {
                diaText.GetComponent<TextMeshPro>().text = dialogue[i];
            }
            else if (quest.questDone == true)
            {
                diaText.GetComponent<TextMeshPro>().text = afterQuestDialogue[i];
            }
        }
        else if (questStarter == false)
        {
            diaText.GetComponent<TextMeshPro>().text = dialogue[i];

            if ((answerA.answerClicked == true && answerA.finished == false) || (answerB.answerClicked == true && answerB.finished == false) || (answerC.answerClicked == true && answerC.finished == false))
            {
                diaText.GetComponent<TextMeshPro>().text = wrongText;
            }
            else if(answerA.finished == true || answerB.finished == true || answerC.finished == true )
            {
                dialogueNumber = dialogue.Length - 1;
                diaText.GetComponent<TextMeshPro>().text = dialogue[i];
                Waiting = false;
                rightAnswer = true;
            }
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
