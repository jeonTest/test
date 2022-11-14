using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    LevelProgressBar levelProgressBar;

    void Update()
    {
        Finish();
    }

    public void Finish()
    {
        levelProgressBar = gameObject.GetComponent<LevelProgressBar>();

        if (levelProgressBar.progress >= 99)
        {
            Debug.Log("Player has finished!");
            Time.timeScale = 0f;
        }
    }
}
