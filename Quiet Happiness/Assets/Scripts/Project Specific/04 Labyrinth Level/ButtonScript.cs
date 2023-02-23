using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class ButtonScript : MonoBehaviour
{
    public PlayerInput Input;
    public GameObject Door;
    public bool nearPlayer;
    public bool doorOpen;
    private bool start = false;

    public bool BlendShapes = false;
    float blendOne = 0f;
    float blendSpeed = 10f;

    public Animator anim;
    public AudioSource switchSound;

    public GameObject uiNote;
    public TextMeshProUGUI uiText;

    SkinnedMeshRenderer skinnedMeshRenderer01;
    Mesh skinnedMesh01;

    BoxCollider boxCollider01;

    MatValueOpen matValueOpen;
    MatValueClose matValueClose;
    public GameObject DoorOpen;
    public GameObject DoorClose;

    public void Awake()
    {
        Input = GetComponent<PlayerInput>();

        if (BlendShapes == true)
        {
            skinnedMeshRenderer01 = Door.GetComponent<SkinnedMeshRenderer>();
            skinnedMesh01 = Door.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        }

        boxCollider01 = Door.GetComponent<BoxCollider>();

        matValueOpen = DoorOpen.GetComponent<MatValueOpen>();
        matValueClose = DoorClose.GetComponent<MatValueClose>();
        uiNote.transform.localScale = Vector3.zero;
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
            if (BlendShapes == true)
            {
                while (blendOne >= 0)
                {
                    skinnedMeshRenderer01.SetBlendShapeWeight(0, blendOne);
                    blendOne -= blendSpeed;
                    boxCollider01.isTrigger = false;
                }
            }
            else if(BlendShapes == false)
            {
                anim.SetFloat("Movement",1f);
                boxCollider01.isTrigger = false;
            }
        }
        else if (doorOpen == true)
        {
            if (BlendShapes == true)
            {
                while (blendOne <= 100)
                {
                    skinnedMeshRenderer01.SetBlendShapeWeight(0, blendOne);
                    blendOne += blendSpeed;
                    boxCollider01.isTrigger = true;
                }
            }
            else if (BlendShapes == false)
            {
                anim.SetFloat("Movement", 0);
                boxCollider01.isTrigger = true;
            }
        }
    }

    private void OnInteract()
    {
        if(start == false)
        {
            start = true;
        }

        if (nearPlayer == true)
        {
            Debug.Log("Button pressed!");

            switchSound.Play();

            if (doorOpen == false)
            {
                doorOpen = true;
                matValueOpen.MatValueOpenChange();
                matValueClose.MatValueCloseChange();

                uiText.text = "Etwas öffnet sich...";
                uiNote.LeanScale(Vector3.one, 0.5f);
                StartCoroutine(NoteTime());

            }
            else if(doorOpen == true)
            {
                doorOpen = false;
                matValueOpen.MatValueCloseChange();
                matValueClose.MatValueOpenChange();

                uiText.text = "Etwas schließt sich...";
                uiNote.LeanScale(Vector3.one, 0.5f);
                StartCoroutine(NoteTime());
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

    IEnumerator NoteTime()
    {
        yield return new WaitForSeconds(2);
        uiNote.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
}
