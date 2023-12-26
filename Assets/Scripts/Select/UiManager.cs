using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private TextMeshProUGUI songComposer;
    [SerializeField] private TextMeshProUGUI songSpeed;

    private float speed;
    public int idx;
    
    private LoadSongList songList;
    private SheetPaser sheetPaser;
    private Music music;

    private void Start()
    {
        sheetPaser = SheetPaser.instance;
        songList = LoadSongList.instance;
        music = Music.instance;

        speed = Sheet.instance.speed;
        songSpeed.text = speed.ToString();
        UpdateUi(0);
    }

    private void UpdateUi(int idx)
    {
        this.idx = idx;
        Sheet.instance.songName = songList.newSongs[idx].songName;
        songName.text = songList.newSongs[idx].songName;
        songComposer.text = songList.newSongs[idx].composer;
        music.PlayMusicForSelect(songList.newSongs[idx].song);
        sheetPaser.StartPaserSheet(songList.newSongs[idx].sheet);
    }

    public void NextList()
    {
        UpdateUi((++idx) % songList.songCnt);
        music.PlayMusicForSelect(songList.newSongs[idx].song);
    }

    public void BeforeList()
    {
        UpdateUi(Math.Abs(--idx) % songList.songCnt);
        music.PlayMusicForSelect(songList.newSongs[idx].song);
    }

    public void SelectSong()
    {
        music.PlayMusicForInGame();
    }

    public void SpeedUp()
    {
        speed += 1f;
        speed = Math.Clamp(speed, 5f, 20f);
        songSpeed.text = speed.ToString();
        Sheet.instance.speed = speed;
    }

    public void SpeedDown()
    {
        speed -= 1f;
        speed = Math.Clamp(speed, 5f, 20f);
        songSpeed.text = speed.ToString();
        Sheet.instance.speed = speed;
    }
}
