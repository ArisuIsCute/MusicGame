using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    public bool isGameEnd;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void StartMusicForPlay()
    {
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }

    public void FinshMusic()
    {
        isGameEnd = !music.isPlaying;
        if (isGameEnd)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
