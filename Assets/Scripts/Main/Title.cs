using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Title : MonoBehaviour
{
    private void Start()
    {
        Music.instance.PlayMusicForTitle(LoadSongList.instance.songAudioPatchList[Random.Range(0, LoadSongList.instance.songAudioPatchList.Count)]);
    }
}
