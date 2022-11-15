using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonScript : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject Door;
    public GameObject Door02;
    public bool nearPlayer;
    public bool doorOpen;


    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        nearPlayer = false;
        doorOpen = false;
    }

    private void OnButtonPress()
    {
        if (nearPlayer == true)
        {
            Debug.Log("Button pressed!");

            if (doorOpen == false)
            {
                Door.SetActive(false);
                Door02.SetActive(true);
                doorOpen = true;
            }
            else if(doorOpen == true)
            {
                Door.SetActive(true);
                Door02.SetActive(false);
                doorOpen = false;
            }
        }

        if(nearPlayer == false)
        {
            Debug.Log("Too far away!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nearPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            nearPlayer = false;
        }
    }
}
