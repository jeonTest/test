using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonScript : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject Door;
    public bool nearPlayer;

    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        nearPlayer = false;
    }

    private void OnButtonPress()
    {
        if (nearPlayer == true)
        {
            Debug.Log("Button pressed!");
            Door.SetActive(false);
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
