using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer.material.IsKeywordEnabled("_EMISSION"))
        {
            meshRenderer.material.DisableKeyword("_EMISSION");
        }
        else
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
        }
    }
}
