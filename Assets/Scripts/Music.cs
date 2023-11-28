using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public static Music instance = null;
    
    public AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
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
        StartCoroutine(CheckEnd());
    }

    private IEnumerator CheckEnd()
    {
        if (audio.isPlaying)
        {
            yield return new WaitForSeconds(.5f);
            StartCoroutine(CheckEnd());
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }
    
    public void StopThisSong()
    {
        if (audio.clip == null) return;
        audio.Stop();
    }
}
