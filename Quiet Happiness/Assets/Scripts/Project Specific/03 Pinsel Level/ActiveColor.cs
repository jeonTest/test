using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColor : MonoBehaviour
{
    public string[] Brush = { "Red", "Orange", "Yellow", "Green", "LightBlue", "DarkBlue", "Purple" };
    public string colourActive;
  
    public void Red()
    {
        colourActive = Brush[0];
    }

    public void Orange()
    {
        colourActive = Brush[1];
    }

    public void Yellow()
    {
        colourActive = Brush[2];
    }

    public void Green()
    {
        colourActive = Brush[3];
    }

    public void LightBlue()
    {
        colourActive = Brush[4];
    }

    public void DarkBlue()
    {
        colourActive = Brush[5];
    }

    public void Purple()
    {
        colourActive = Brush[6];
    }



}
