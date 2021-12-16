using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Ball ball)) return;
        ball.CurrenPlatform = this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Ball ball)) return;
        ball.IncrementScore();
        
        foreach (Transform child in transform)
        {
            Sector sector = child.GetComponent<Sector>();
            sector.Die();
        }
        Destroy(gameObject);
    }
}
