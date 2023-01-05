using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] [DropDown(nameof(_questTypes))] private int _questType;
    private List<string> _questTypes = new List<string>
    {
        "None",
        "Colouring",
        "Searching",
        "Talking"
    };

    public bool isActive;
    public bool questDone;
    public string questDescription;
    public GameObject reward;

    public GameObject questGameObj;

    //reminder: editor script machen damit es übersichtlicher wird
    [Header("Colouring")]
    public string[] colours;

    DialogueBrushGame dialogueBrush;
    DialogueBrushGame talkingAnswer;

    void Awake()
    {
        dialogueBrush = GetComponent<DialogueBrushGame>();
        if (_questType == 3)
        {
            talkingAnswer = questGameObj.GetComponent<DialogueBrushGame>();
        }
    }

    void Start()
    {
        isActive = false;
        questDone = false;
    }

    void Update()
    {
        StartQuest();
        if (isActive == true)
        {
            if (_questType == 1)
            {
                ColouringQuest();
            }
            else if (_questType == 2)
            {
                SearchingQuest();
            }
            else if (_questType == 3)
            {
                TalkingQuest();
            }
        }
    }

    void ColouringQuest()
    {

    }

    void SearchingQuest()
    {

    }

    void TalkingQuest()
    {
        if (talkingAnswer.rightAnswer == true)
        {
            questDone = true;
        }
    }

    void StartQuest()
    {
        if(dialogueBrush.dialogueNumber == (dialogueBrush.dialogue.Length - 1) && questDone == false)
        {
            questGameObj.SetActive(true);
            isActive = true;
        }
    }
}
