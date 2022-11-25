using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Player")
        {
            float objectX = transform.position.x;
            objectX += 0.5f;
            transform.position = new Vector3(objectX, transform.position.y, transform.position.z);

            Debug.Log("Button moved");
        }
    }
}
