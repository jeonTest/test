using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColor : MonoBehaviour
{
    public string[] Brush = { "Red", "Orange", "Yellow", "Green", "LightBlue", "DarkBlue", "Purple", "Brown" };
    public string colourActive;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool brushCursor = false;

    public void Red()
    {
        colourActive = Brush[0];
        brushCursor = true;
    }

    public void Orange()
    {
        colourActive = Brush[1];
        brushCursor = true;
    }

    public void Yellow()
    {
        colourActive = Brush[2];
        brushCursor = true;
    }

    public void Green()
    {
        colourActive = Brush[3];
        brushCursor = true;
    }

    public void LightBlue()
    {
        colourActive = Brush[4];
        brushCursor = true;
    }

    public void DarkBlue()
    {
        colourActive = Brush[5];
        brushCursor = true;
    }

    public void Purple()
    {
        colourActive = Brush[6];
        brushCursor = true;
    }

    public void Brown()
    {
        colourActive = Brush[7];
        brushCursor = true;
    }

    public void Update()
    {
        if(brushCursor == true)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
        else if(brushCursor == false)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }



}
