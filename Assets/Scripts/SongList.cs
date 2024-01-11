using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongList : MonoBehaviour
{
    public string songName;
    public string composer;
    public string difficult;
    public AudioClip song;
    public TextAsset sheet;
}

[Serializable]
public class AddNewSong
{
    public string songName;
    public string composer;
    public string difficult;
    public AudioClip song;
    public TextAsset sheet;

    public AddNewSong(string name, string composer, string difficult, AudioClip audio, TextAsset text)
    {
        songName = name;
        this.composer = composer;
        this.difficult = difficult;
        song = audio;
        sheet = text;
    }
}
