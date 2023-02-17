using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Answers : MonoBehaviour
{
    public string answer;
    public bool rightAnswer;
    public bool answerClicked;
    [HideInInspector]
    public bool finished = false;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        answerClicked = false;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            if (Mouse.current.leftButton.isPressed)
                if (hit.transform.name == gameObject.name)
                    answerClicked = true;
        }

        if (rightAnswer == true && answerClicked == true)
        {
            finished = true;

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Answer");
            foreach (GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }
        }
    }
}
