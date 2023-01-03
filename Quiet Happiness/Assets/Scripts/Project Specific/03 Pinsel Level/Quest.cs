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
    public string questDescription;
    public GameObject reward;

    [Header("Colouring")]
    public string[] colours;
    public GameObject[] objectToColor;

    [Header("Searching")]
    public GameObject searchObject;

    [Header("Talking")]
    public GameObject personToTalk;
   

    void Start()
    {
        isActive = false;
    }

    void Update()
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

    void ColouringQuest()
    {

    }

    void SearchingQuest()
    {

    }

    void TalkingQuest()
    {

    }
}
