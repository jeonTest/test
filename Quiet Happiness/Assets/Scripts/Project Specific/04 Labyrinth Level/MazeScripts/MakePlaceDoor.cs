using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlaceDoor : MonoBehaviour
{
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag=="Wall")
        {
            Destroy(col.gameObject);
            Debug.Log("Wall destroyed");
        }
    }
}
