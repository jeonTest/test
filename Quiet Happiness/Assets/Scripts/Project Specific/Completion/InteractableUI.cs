using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableUI : MonoBehaviour
{
    public GameObject UiImage;
    public float activateDistance = 5;
    public PlayerInput input;
    public bool playerNear = false;

    void Update()
    {
        distanceToPlayer();
        ActivateImage();
    }

    public void ActivateImage()
    {
        if(playerNear == true)
        {
            UiImage.SetActive(true);
        }

        if (playerNear == false)
        {
            UiImage.SetActive(false);
        }
    }

    public void OnInteract()
    {
        UiImage.SetActive(false);
    }

    public void distanceToPlayer()
    {
        Transform playerObj = GameObject.FindWithTag("Player").transform;
        float dist = Vector3.Distance(playerObj.position, transform.position);

        if (dist <= activateDistance)
        {
            playerNear = true;
        }
        else
        {
            playerNear = false;
        }
    }
}
