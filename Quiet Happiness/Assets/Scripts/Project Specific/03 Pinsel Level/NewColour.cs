using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewColour : MonoBehaviour
{
    public AudioSource getColourSound;

    void OnEnable()
    {
         getColourSound.Play();
    }
}
