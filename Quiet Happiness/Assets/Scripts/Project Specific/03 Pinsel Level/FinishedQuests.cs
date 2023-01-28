using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedQuests : MonoBehaviour
{
    public GameObject[] questNPC;
    Quest[] quest;
    public bool allFinished = false;
    public GameObject finishedScreen;


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
        yield return new WaitForSeconds(10f);
        finishedScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Finished()
    {
        SceneManager.LoadScene("Menu");
    }
}
