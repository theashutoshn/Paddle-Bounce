using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip ballBounceClip;
    private AudioSource _AudioSource;

    void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BallBounce()
    {
        _AudioSource.PlayOneShot(ballBounceClip);
    }
}
