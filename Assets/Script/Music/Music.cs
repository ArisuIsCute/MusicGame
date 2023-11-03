using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private MusicManager musicManager;
    
    private void Start()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        musicManager.StartMusicForPlay();
    }

    private void Update()
    {
        musicManager.FinshMusic();
    }
}
