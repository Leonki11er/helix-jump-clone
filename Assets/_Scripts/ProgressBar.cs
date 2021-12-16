using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Ball Ball;
    public Transform FinishPlatform;
    public Slider Slider;
    private float _startY;
    private float _minimumReachedY;
    public float CurrentProgress;


    private void Start()
    {
        _startY = Ball.transform.position.y;
    }

    private void Update()
    {
        if (Ball == null) return;
        _minimumReachedY = Mathf.Min(_minimumReachedY, Ball.transform.position.y);
        float finishY = FinishPlatform.position.y;
        CurrentProgress = Mathf.InverseLerp(_startY, finishY+1f, _minimumReachedY);
        Slider.value = CurrentProgress;
    }
}
