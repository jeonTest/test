using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNpc : MonoBehaviour
{
    public DialogueTrigger02 trigger;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            trigger.StartDialogue();
        }
    }
}
