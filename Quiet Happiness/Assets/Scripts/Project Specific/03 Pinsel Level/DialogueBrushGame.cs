using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueBrushGame : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject dialogueBox;
    public string npcName;
    public string[] dialogue;

    public int dialogueNumber;

    public bool playerNear;


    public void Start()
    {
        dialogueBox.SetActive(false);
        playerNear = false;
        SetName();
    }
    
    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }

    public void Update()
    {
        if (dialogueNumber >= dialogue.Length || playerNear == false)
        {
            dialogueBox.SetActive(false);
            dialogueNumber = 0;
        }
        SetDialogue(dialogueNumber);
    }

    private void OnStartDialogue()
    {
        if (playerNear == true)
        {
            dialogueBox.SetActive(true);
            Debug.Log("Dialogue!");

        }
        else
        {
            Debug.Log("No Friend near :(");
        }
    }

    private void OnSkipDialogue()
    {        
        if (dialogueBox.activeSelf == true && dialogueNumber < dialogue.Length)
        {
            dialogueNumber += 1;
        }
    }

    public void SetName()
    { 
        GameObject npc = dialogueBox.transform.GetChild(0).gameObject;
        npc.GetComponent<TextMeshPro>().text = npcName;
    }

    public void SetDialogue(int i)
    {
        GameObject diaText = dialogueBox.transform.GetChild(1).gameObject;
        diaText.GetComponent<TextMeshPro>().text = dialogue[i];
    }

    #region Boxcollider
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = false;
        }
    }
    #endregion
}
