using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;

    public int ObjectNumber = 1;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;


    void Start()    
    {
        for(int i = 0; i < ObjectNumber; i++)
        {
            SpawnObjectRandom();
        }
    }

    void SpawnObjectRandom()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ,maxZ));

        Instantiate(ItemPrefab, randomSpawnPosition, Quaternion.identity);
    }
}
