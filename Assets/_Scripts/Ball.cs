using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameController GameController;
    public Platform CurrenPlatform;
    [SerializeField]
    private float _bounceSpeed;
    [SerializeField]
    private Rigidbody _rigidbody;
    public GameObject DeathPS;
    private AudioSource _audioSource;
    public AudioClip PlatformBreak;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ReachFinish()
    {
        _rigidbody.velocity = Vector3.zero;
        GameController.OnPlayerReachFinish();
    }

    public void IncrementScore()
    {
        _audioSource.PlayOneShot(PlatformBreak);
        GameController.IncrementScore();
    }

    public void Bounce()
    {
        if(GameController.CurrentState == GameController.State.Playing)
        _rigidbody.velocity = new Vector3(0, _bounceSpeed, 0);
        _audioSource.Play();
    }

    public void Die()
    {
        _rigidbody.velocity = Vector3.zero;
        GameController.OnPlayerDied();
        GameObject clone = Instantiate(DeathPS, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
