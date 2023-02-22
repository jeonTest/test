using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishedQuests : Module
{
    public GameObject[] questNPC;
    Quest[] quest;
    public bool allFinished = false;
    public GameObject finishedScreen;
    public GameObject outro;
    VideoTimer videoTimer;

    void Start()
    {
        videoTimer = outro.GetComponent<VideoTimer>();
    }

    void Update()
    {
        int i = 0;
        quest = new Quest[questNPC.Length];
        int npcNum = questNPC.Length;

        if (i < npcNum)
        {
            quest[i] = questNPC[i].GetComponent<Quest>();
            if (quest[i].questDone == true)
            {
                i += 1;
            }
        }

        if (i >= npcNum)
        {
            allFinished = true;
        }

        if(allFinished == true)
        {
            StartCoroutine(FinishTime());
        }
    }

    IEnumerator FinishTime()
    {
        yield return new WaitForSeconds(17f);
        if (videoTimer.videoActive == true)
        {
            outro.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        finishedScreen.SetActive(true);
    }

    public void Finished()
    {
        SceneManager.LoadScene("Menu");
        ModuleManager.GetModule<SaveGameManager>().SetCompletionInfo(CompletionIDs.BRUSHLEVELDONE, true);
    }
}
