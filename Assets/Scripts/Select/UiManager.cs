using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private TextMeshProUGUI songComposer;
    [SerializeField] private TextMeshProUGUI songDifficult;
    [SerializeField] private GameObject racords;

    private bool isEnd = true;

    public int idx = 0;
    
    private LoadSongList songList;
    private SheetPaser sheetPaser;
    private Music music;

    private void Start()
    {
        sheetPaser = SheetPaser.instance;
        songList = LoadSongList.instance;
        music = Music.instance;

        UpdateUi();
    }

    private void UpdateUi()
    {
        songName.text = songList.newSongs[idx].songName;
        songComposer.text = songList.newSongs[idx].composer;
        songDifficult.text = "Difficult : " + songList.newSongs[idx].difficult;
        
        music.PlayMusicForSelect(songList.newSongs[idx].song);
    }

    public void NextList()
    {
        if(!isEnd) return;
        idx = (++idx) % songList.newSongs.Count;
        racords.GetComponent<Animation>().Play("Racord_1");
        StartCoroutine(ButtonColTime(racords.GetComponent<Animation>(), "Racord_1"));
    }

    public void BeforeList()
    {
        if(!isEnd) return;
        idx = --idx < 0 ? songList.newSongs.Count - 1 : idx;
        racords.GetComponent<Animation>().Play("Racord_2");
        StartCoroutine(ButtonColTime(racords.GetComponent<Animation>(), "Racord_2"));
    }

    public void SelectSong()
    {
        if (!isEnd) return;
        
        Sheet.instance.songName = songList.newSongs[idx].songName;
        sheetPaser.StartPaserSheet(songList.newSongs[idx].sheet);
        music.PlayMusicForInGame();

        SceneManager.LoadScene("Loading");
    }

    private IEnumerator ButtonColTime(Animation ani, string name)
    {
        isEnd = false;
        
        songName.text = "---";
        songComposer.text = "---";
        songDifficult.text = "---";
        
        yield return new WaitUntil(() => ani.IsPlaying(name) == false);
        isEnd = true;
        UpdateUi();
    }
}
