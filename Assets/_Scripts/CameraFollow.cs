using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Ball Ball;
    public Vector3 PlatformToCameraOffset;
    public float Speed;
    private void Update()
    {
        if (Ball.CurrenPlatform == null) return;
        Vector3 targetPosition = Ball.CurrenPlatform.transform.position + PlatformToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed*Time.deltaTime);
    }
}
