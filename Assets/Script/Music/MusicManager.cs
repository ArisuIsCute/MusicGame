using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    private SheetPaser sheetPaser;
    private NoteTimeCheck noteTimeCheck;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        noteTimeCheck = GameObject.Find("NoteTimeCheck").GetComponent<NoteTimeCheck>();
        sheetPaser = GameObject.Find("SheetPaser").GetComponent<SheetPaser>();
        music = GetComponent<AudioSource>();
    }

    public void StartMusicForPlay()
    {
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }

    public void FinshMusic()
    {
        if (noteTimeCheck.isEnd)
        {
            StartCoroutine(LoadResult());
        }
    }

    private IEnumerator LoadResult()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Result");
        yield break;
    }
}
