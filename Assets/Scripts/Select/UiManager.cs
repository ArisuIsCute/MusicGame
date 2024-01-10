using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private TextMeshProUGUI songComposer;
    [SerializeField] private GameObject[] racords;

    public int idx;
    
    private LoadSongList songList;
    private SheetPaser sheetPaser;
    private Music music;

    private void Start()
    {
        sheetPaser = SheetPaser.instance;
        songList = LoadSongList.instance;
        music = Music.instance;

        UpdateUi(0);
    }

    private void UpdateUi(int idx)
    {
        this.idx = idx;

        songName.text = songList.newSongs[idx].songName;
        songComposer.text = songList.newSongs[idx].composer;
        
        music.PlayMusicForSelect(songList.newSongs[idx].song);
    }

    public void NextList()
    {
        UpdateUi((++idx) % songList.newSongs.Count);
    }

    public void BeforeList()
    {
        UpdateUi(Math.Abs(--idx) % songList.newSongs.Count);
        racords[1].GetComponent<Animation>().Play();
        racords[0].GetComponent<Animation>().Play();
    }

    public void SelectSong()
    {
        Sheet.instance.songName = songList.newSongs[idx].songName;
        sheetPaser.StartPaserSheet(songList.newSongs[idx].sheet);
        music.PlayMusicForInGame();
    }
}
