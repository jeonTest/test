using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnimation : MonoBehaviour
{
    public Animator animator;

    //Note: Animator Parameter die dieses Script benutzen, müssen alle den Namen "playJiggle" haben, da es sonst eine Warning gibt

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("playJiggle", true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("playJiggle", false);
        }
    }
}
