using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

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
    public GameObject[] coloredObj;

    [Header("Searching")]
    public bool objectFound = false;

    DialogueBrushGame dialogueBrush;
    DialogueBrushGame talkingAnswer;
    IsColored[] isColored;
    Ray ray;
    RaycastHit hit;

    void Awake()
    {
        dialogueBrush = GetComponent<DialogueBrushGame>();
        if (_questTypes[_questType] == _questTypes[3])
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
            if (_questTypes[_questType] == _questTypes[1])
            {
                ColouringQuest();
            }
            else if (_questTypes[_questType] == _questTypes[2])
            {
                SearchingQuest();
            }
            else if (_questTypes[_questType] == _questTypes[3])
            {
                TalkingQuest();
            }
        }
    }

    void ColouringQuest()
    {
        isColored = new IsColored[coloredObj.Length];

        for (int i = 0; i < coloredObj.Length; i++)
        {
            isColored[i] = coloredObj[i].GetComponent<IsColored>();
            if (isColored[i].finished == false)
                questDone = false;
            else
            {
                questDone = true;
            }
        }
    }

    void SearchingQuest()
    {
        questGameObj.SetActive(true);

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            if (Mouse.current.leftButton.isPressed)
                if (hit.transform.name ==  questGameObj.name)
                    objectFound = true;
        }

        if(objectFound == true)
        {
            questDone = true;
        }
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
