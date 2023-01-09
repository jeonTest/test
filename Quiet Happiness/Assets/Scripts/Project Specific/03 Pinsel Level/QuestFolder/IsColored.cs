using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsColored : MonoBehaviour
{
    public bool finished = false;

    private GameObject ColorCol1;
    private GameObject ColorCol2;

    public bool halfway;

    ObjectColor objectColor;
    Ray ray;
    RaycastHit hit;

    void Awake()
    {
        objectColor = GetComponent<ObjectColor>();
    }

    void Start()
    {
        ColorCol1 = transform.GetChild(0).gameObject;
        ColorCol2 = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if(objectColor.rightColor == true)
        {
            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                if (Mouse.current.leftButton.isPressed)
                    if (hit.transform.name == ColorCol1.name)
                            halfway = true;
            }
        }

        if (halfway == true)
        {
            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                if (Mouse.current.leftButton.isPressed)
                    if (hit.transform.name == ColorCol2.name)
                        finished = true;
            }
        }

        if (finished == true)
            gameObject.SetActive(false);
    }
}
