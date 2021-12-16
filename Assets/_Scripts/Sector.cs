using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public GameObject BadPS;
    public GameObject GoodPS;
    public GameObject BouncePS;

    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Ball ball)) return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot <= 0.4f) return;
        if (IsGood)
        {
            ball.Bounce();
            GameObject clone = Instantiate(BouncePS, collision.transform.position, collision.transform.rotation);
        }
        else
            ball.Die();
    }

    public void Die()
    {
        if (IsGood)
        {
          GameObject  clone = Instantiate(GoodPS, transform.position, transform.rotation);

        }
        else
        {
            GameObject clone = Instantiate(BadPS, transform.position, transform.rotation);

        }
        Destroy(gameObject);
        
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
