using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colour { Red, Orange, Yellow, Green, LightBlue, DarkBlue, Purple };

public class Brush
{
    public Colour Colour { get; set; }
    public Colour activeBrush;

    public Brush(Colour colour)
    {
        Colour = colour;
    }

}
public class ActiveColor : MonoBehaviour
{
    public Brush activeBrush;
  
    public void Red()
    {
        Brush activeBrush = new Brush(Colour.Red);
        Debug.Log(activeBrush.Colour);
    }

    public void Orange()
    {
        Brush activeBrush = new Brush(Colour.Orange);
        Debug.Log(activeBrush.Colour);
    }

    public void Yellow()
    {
        Brush activeBrush = new Brush(Colour.Yellow);
        Debug.Log(activeBrush.Colour);
    }

    public void Green()
    {
        Brush activeBrush = new Brush(Colour.Green);
        Debug.Log(activeBrush.Colour);
    }

    public void LightBlue()
    {
        Brush activeBrush = new Brush(Colour.LightBlue);
        Debug.Log(activeBrush.Colour);
    }

    public void DarkBlue()
    {
        Brush activeBrush = new Brush(Colour.DarkBlue);
        Debug.Log(activeBrush.Colour);
    }

    public void Purple()
    {
        Brush activeBrush = new Brush(Colour.Purple);
        Debug.Log(activeBrush.Colour);
    }



}
