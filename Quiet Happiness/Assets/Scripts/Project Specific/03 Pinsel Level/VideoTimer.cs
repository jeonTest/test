using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimer : MonoBehaviour
{
    public float videoTime;
    public bool videoActive = false;

    public void Update()
    {
        if (videoActive == true)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<VideoPlayer>().Play();
            StartCoroutine(StartVideo());
        }
        else if (videoActive == false)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator StartVideo()
    {
        yield return new WaitForSeconds(videoTime);
        videoActive = false;
    }
}
