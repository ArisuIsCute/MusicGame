using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Title : MonoBehaviour
{
    private LoadSongList list;
    private Music music;

    private void Start()
    {
        music = GameObject.Find("Music").GetComponent<Music>();
        list = GameObject.Find("LoadSongList").GetComponent<LoadSongList>();
        music.PlayMusicForTitle(list.songAudioPatchList[Random.Range(0, list.songAudioPatchList.Count)]);
    }
}
