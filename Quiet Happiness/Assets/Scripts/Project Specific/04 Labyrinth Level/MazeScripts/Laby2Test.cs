using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laby2Test : MonoBehaviour
{
    public Vector3 Labyrinth2Position;
    public Vector3 rotationVector;

    void Update()
    {
        transform.position = Labyrinth2Position;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

}
