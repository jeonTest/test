using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlaceDoor : MonoBehaviour
{
    public bool inRange;

    void Start()
    {
        StartCoroutine(WallGo());
    }

    IEnumerator WallGo()
    {
        yield return new WaitForSeconds(0.1f);

        if (inRange == true)
        {
            gameObject.SetActive(false);
            if (inRange == false)
            {
                gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Door")
        {
            inRange = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Door")
        {
            inRange = true;
        }
    }
}
