using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderStuff : MonoBehaviour
{
    public ComputeShader computeShader;
    private RenderTexture rtt;

    int width = 512;
    int height = 512;

    private void Awake()
    {
        rtt = new RenderTexture(width, height, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
        rtt.enableRandomWrite = true;
        rtt.Create();
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        int kernel = computeShader.FindKernel("CSMain");

        int workgroupsX = Mathf.CeilToInt(width/8);
        int workgroupsY = Mathf.CeilToInt(height/8);

        computeShader.Dispatch(kernel, workgroupsX, workgroupsY, 1);
        computeShader.SetTexture(0, "Result", rtt);
        Graphics.Blit(rtt, destination);

    }
}
