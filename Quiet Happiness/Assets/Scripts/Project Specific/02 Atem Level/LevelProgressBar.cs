using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    public Transform _player;
    public Transform _finish;
    public Transform _start;
    public Slider gameProgressSlider;
    public float progress;
   
    public void Update()
    {
        Distance();
        gameProgressSlider.value = progress;
    }

    public void Distance()
    {
        float distanceToFinish = Vector3.Distance(_player.position, _finish.position);
        float startToFinish = Vector3.Distance(_start.position, _finish.position);

        progress = (1-(distanceToFinish / startToFinish))*100;
    }

}
