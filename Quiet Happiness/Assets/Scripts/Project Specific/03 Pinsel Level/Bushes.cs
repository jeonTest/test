using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    public Animator bushesGone;
    public GameObject[] coloredObj;
    public GameObject whiteBridge;
    IsColored[] isColored;
    private int i = 0;

    void Update()
    {
        BushColored();
    }

    public void BushColored()
    {
        isColored = new IsColored[coloredObj.Length];
        int colorNum = coloredObj.Length;

        if (i < colorNum)
        {
            isColored[i] = coloredObj[i].GetComponent<IsColored>();
            if (isColored[i].finished == true)
            {
                i += 1;
            }
        }

        if (i >= colorNum)
        {
            bushesGone.SetBool("Colored", true);
            Destroy(whiteBridge);
        }
    }
}
