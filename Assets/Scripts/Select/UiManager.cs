using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private TextMeshProUGUI songComposer;

    public int idx;
    
    private LoadSongList songList;
    private Music music;

    private void Start()
    {
        songList = GameObject.Find("LoadSongList").GetComponent<LoadSongList>();
        music = GameObject.Find("Music").GetComponent<Music>();
        UpdateUi(0);
    }

    private void UpdateUi(int idx)
    {
        this.idx = idx;
        songName.text = songList.songNameList[idx];
        songComposer.text = songList.songComposerList[idx];
        music.PlayMusicForSelect(songList.songAudioPatchList[idx]);
    }

    public void NextList()
    {
        UpdateUi((++idx) % songList.songCnt);
        music.PlayMusicForSelect(songList.songAudioPatchList[idx]);
    }

    public void BeforeList()
    {
        UpdateUi(Math.Abs(--idx) % songList.songCnt);
        music.PlayMusicForSelect(songList.songAudioPatchList[idx]);
    }

    public void SelectSong()
    {
        
    }
}
