using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyAssetOnClick : MonoBehaviour
{
    public GameObject deactivateOnClick;
    Ray ray;
    RaycastHit hit;
    ObjectColor objectColor;

    void Awake()
    {
        objectColor = GetComponent<ObjectColor>();
    }

    void Update()
    {
        if (objectColor.rightColor == true)
        {
            ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(deactivateOnClick);
            }
        }
    }
}
