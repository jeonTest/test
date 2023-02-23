using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingAway : MonoBehaviour
{
    public Vector3 destination;
    private Vector3 curPos;
    public GameObject questGiver;
    Quest quest;
    DialogueBrushGame dialogue;
    public string[] afterQuestDialogue;

    void Start()
    {
        quest = questGiver.GetComponent<Quest>();
        dialogue = GetComponent<DialogueBrushGame>();
    }

    void Update()
    {
        curPos = gameObject.transform.position;

        if (quest.questDone == true)
        {
            StartCoroutine(StartWalkíng());
        }

        if(curPos == destination)
        {
            dialogue.dialogue = afterQuestDialogue;
        }
    }

    IEnumerator StartWalkíng()
    {
        yield return new WaitForSeconds(3);

        transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime);
    }
}
