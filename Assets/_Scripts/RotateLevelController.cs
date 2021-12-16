using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevelController : MonoBehaviour
{
    private Vector3 _previousMousePosition;
    [SerializeField]
    private Transform _level;
    [SerializeField]
    private float _sensitivity;


    void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _level.Rotate(0, -delta.x* _sensitivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
