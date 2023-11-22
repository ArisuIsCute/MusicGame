using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusicForSelect(string patch)
    {
        audio.clip = Resources.Load<AudioClip>(patch);
        audio.Play();
    }

    public void PlayMusicForTitle(string patch)
    {
        audio.clip = Resources.Load<AudioClip>(patch);
        audio.Play();
    }

    public void PlayMusicForInGame()
    {
        audio.Stop();
        audio.PlayDelayed(3.0f);
    }
    
    public void StopThisSong()
    {
        if (audio.clip == null) return;
        audio.Stop();
    }
}
