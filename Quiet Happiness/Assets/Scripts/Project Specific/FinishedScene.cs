using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScene : MonoBehaviour
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
            Time.timeScale = 0f;
        }
    }

    public void Finished()
    {
       SceneManager.LoadScene("Menu");
    }
}
