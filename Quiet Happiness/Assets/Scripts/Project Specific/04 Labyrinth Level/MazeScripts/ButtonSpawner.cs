using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public int collisions = 0;
    public Vector3 randomSpawnPosition;


    void Start()    
    {       
        randomSpawnPosition = new Vector3(Random.Range(minX, maxX), 0.04f, Random.Range(minZ, maxZ));
        transform.position = randomSpawnPosition;
    }

    void Update()
    {
        ButtonPosition();
    }

    void ButtonPosition()
    {
        if(collisions != 0)
        {
            randomSpawnPosition = new Vector3(Random.Range(minX, maxX), 0.04f, Random.Range(minZ, maxZ));
            transform.position = randomSpawnPosition;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        collisions++;

        if(col.tag == "Player")
        {
            collisions--;
        }
    }

    void OnTriggerExit(Collider col)
    {
        collisions--;
    }
}
