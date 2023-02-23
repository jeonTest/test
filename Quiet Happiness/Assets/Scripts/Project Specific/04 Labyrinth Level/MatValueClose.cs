using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatValueClose : MonoBehaviour
{
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.EnableKeyword("_EMISSION");
    }

    public void MatValueCloseChange()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.DisableKeyword("_EMISSION");
    }

    public void MatValueOpenChange()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.EnableKeyword("_EMISSION");
    }
}
