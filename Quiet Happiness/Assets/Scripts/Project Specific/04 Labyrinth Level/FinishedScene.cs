using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScene : Module
{
    public GameObject finishedScreen;

    void Start()
    {
        finishedScreen.SetActive(false);
    }


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            finishedScreen.SetActive(true);
        }
    }

    public void Finished()
    {
       SceneManager.LoadScene("Menu");
       ModuleManager.GetModule<SaveGameManager>().SetCompletionInfo(CompletionIDs.LABYRINTHLEVELDONE, true);
    }
}
