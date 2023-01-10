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
    private bool start = false;

    float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 10f;

    SkinnedMeshRenderer skinnedMeshRenderer01;
    Mesh skinnedMesh01;

    SkinnedMeshRenderer skinnedMeshRenderer02;
    Mesh skinnedMesh02;

    BoxCollider boxCollider01;
    BoxCollider boxCollider02;


    public void Awake()
    {
        Input = GetComponent<PlayerInput>();

        skinnedMeshRenderer01 = Door.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh01 = Door.GetComponent<SkinnedMeshRenderer>().sharedMesh;

        skinnedMeshRenderer02 = Door02.GetComponent<SkinnedMeshRenderer>();
        skinnedMesh02 = Door02.GetComponent<SkinnedMeshRenderer>().sharedMesh;

        boxCollider01 = Door.GetComponent<BoxCollider>();
        boxCollider02 = Door02.GetComponent<BoxCollider>();
    }

    void Start()
    {
        nearPlayer = false;
        doorOpen = false;
    }

    void Update()
    {
        if (doorOpen == false && start == true)
        {
            while (blendOne >= 0)
            {
                skinnedMeshRenderer01.SetBlendShapeWeight(0, blendOne);
                blendOne -= blendSpeed;
                boxCollider01.isTrigger = false;

                while (blendTwo <= 100)
                {
                    skinnedMeshRenderer02.SetBlendShapeWeight(0, blendTwo);
                    blendTwo += blendSpeed;
                    boxCollider02.isTrigger = true;
                }
            }

        }
        else if (doorOpen == true)
        {
            while (blendOne <= 100)
            {
                skinnedMeshRenderer01.SetBlendShapeWeight(0, blendOne);
                blendOne += blendSpeed;
                boxCollider01.isTrigger = true;

                while (blendTwo >= 0)
                {
                    skinnedMeshRenderer02.SetBlendShapeWeight(0, blendTwo);
                    blendTwo -= blendSpeed;
                    boxCollider02.isTrigger = false;
                }
            }
        }
    }

    private void OnButtonPress()
    {
        if(start == false)
        {
            start = true;
        }

        if (nearPlayer == true)
        {
            Debug.Log("Button pressed!");

            if (doorOpen == false)
            {
                doorOpen = true;

            }
            else if(doorOpen == true)
            {
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
