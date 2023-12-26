using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour
{
    public string songName;
    public string composer;
    public AudioClip song;
    public TextAsset sheet;
}

[Serializable]
public class AddNewSong
{
    public string songName;
    public string composer;
    public AudioClip song;
    public TextAsset sheet;

    public AddNewSong(string name, string composer, AudioClip audio, TextAsset text)
    {
        songName = name;
        this.composer = composer;
        song = audio;
        sheet = text;
    }
}
