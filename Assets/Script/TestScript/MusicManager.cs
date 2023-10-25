using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    public string musicName;
    public bool isGameEnd;

    private int previewTime;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        music = GetComponent<AudioSource>();

        previewTime = 30;
    }

    public void PlayAudioForPlayScene() 
    {
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }

    public void FinishMusic()
    {
        isGameEnd = music.isPlaying;

        if (!isGameEnd)
            SceneManager.LoadScene("MainMenuTest");
    }

    public void SelectMusic(string musicName)
    {
        this.musicName = musicName;
        music.Stop();
    }

    public void PlayAudioPreview(string musicName)
    {
        clip = Resources.Load(this.musicName+"/"+musicName) as AudioClip;
        music.clip = clip;
        music.timeSamples = 0;
        music.timeSamples += music.clip.frequency * previewTime;
        
        music.Play();
    }
}
