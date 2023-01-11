using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    ActiveColor activeColor;
    public string colors;
    public bool rightColor;

    [SerializeField] [DropDown(nameof(_colorTypes))] private int _colorObject;
    private List<string> _colorTypes = new List<string>
    {
        "Red",
        "Orange",
        "Yellow",
        "Green",
        "LightBlue",
        "DarkBlue",
        "Purple",
        "Brown"
    };

    void Awake()
    {
        activeColor = GameObject.Find("Manager").GetComponent<ActiveColor>();
    }

    
    void Update()
    {
        colors = activeColor.colourActive;
        RestrictPainting();
    }

    public void RestrictPainting()
    {
        if(activeColor.colourActive == _colorTypes[_colorObject])
        {
            rightColor = true;
        }
        else
        {
            rightColor = false;
        }
    }
}
