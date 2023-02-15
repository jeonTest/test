using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnimation : MonoBehaviour
{
    public Animator animator;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
               animator.SetBool("playJiggle", true);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playFGjiggle", true);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playFG2Jiggle", true);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playSingleMushroomJiggle", true);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playG1MushroomJiggle", true);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playG2MushroomJiggle", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playJiggle", false);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playFGjiggle", false);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playFG2Jiggle", false);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playSingleMushroomJiggle", false);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playG1MushroomJiggle", false);
        }
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playG2MushroomJiggle", false);
        }
    }
}
