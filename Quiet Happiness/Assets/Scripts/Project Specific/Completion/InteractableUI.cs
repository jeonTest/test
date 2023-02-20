using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    public GameObject UiImage;
    public float activateDistance = 5;
    public bool playerNear = false;
    private int i = 0;
    private GameObject parentCanvas;
    private GameObject clone;

    void Start()
    {
        parentCanvas = GameObject.Find("Interactable");
    }

    void Update()
    {
        distanceToPlayer();
        ActivateImage();
    }

    public void ActivateImage()
    {
        if(playerNear == true && i < 1)
        {
            i = 1;
            clone = Instantiate(UiImage, parentCanvas.transform);
        }

        if (playerNear == false && i == 1)
        {
            i = 0;
            Destroy(clone);
        }
    }

    IEnumerator UiTimer()
    {
        UiImage.SetActive(true);

        yield return new WaitForSeconds(2f);

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
