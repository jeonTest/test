using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightOn : MonoBehaviour
{
    public PlayerInput Input;
    public bool nearPlayer;
    public Light torch;
    public bool lightOn;
    public float lightIntensity = 0.5f;

    public void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        nearPlayer = false;
        lightOn = false;
}

    private void OnLight()
    {
        if (nearPlayer == true)
        {
            if (lightOn == false)
            {
                Debug.Log("Light On!");
                torch.intensity = lightIntensity;
                lightOn = true;
            }
            else if(lightOn == true)
            {
                Debug.Log("Light Off!");
                torch.intensity = 0f;
                lightOn = false;
            }
        }

        if (nearPlayer == false)
        {
            Debug.Log("Too far away!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = false;
        }
    }
}
