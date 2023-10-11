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
        musicManager.PlayAudioForPlayScene();
    }

    private void Update()
    {
        musicManager.FinishMusic();
    }
}
