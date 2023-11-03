using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackGroundMusic : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!audiosource.isPlaying) PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        audiosource.clip = clips[Random.Range(0, clips.Length)];
        audiosource.Play();
    }
}
