using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSongList : MonoBehaviour
{
    public static LoadSongList instance = null;
    
    private readonly string patch = Application.dataPath + "/Resources/Songs/";

    public int songCnt = 0;

    public SongList songList;
    public List<AddNewSong> newSongs = new List<AddNewSong>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AddSongInfo();
    }

    private void AddSongInfo()
    {
        string data = "";
        DirectoryInfo directoryInfo = new DirectoryInfo(patch);

        foreach (DirectoryInfo di in directoryInfo.GetDirectories())
        {
            songCnt++;
            using (StreamReader streamReader = new StreamReader(patch + di.Name + "/" + di.Name + "_sheet.txt"))
            {
                while ((data = streamReader.ReadLine()) != "[HitObjects]")
                {
                    string[] splitData = data.Split(':');

                    if (splitData[0] == "SongName")
                        songList.songName = splitData[1];
                    else if (splitData[0] == "Composer")
                        songList.composer = splitData[1];
                    else if (splitData[0] == "Difficult")
                        songList.difficult = splitData[1];
                }
                
                songList.song = Resources.Load<AudioClip>("Songs/" + di.Name + "/" + di.Name + "_audio");
                songList.sheet = Resources.Load<TextAsset>("Songs/" + di.Name + "/" + di.Name + "_sheet");
            }
            
            newSongs.Add(new AddNewSong(songList.songName, songList.composer, songList.difficult, songList.song, songList.sheet));
        }
    }
}
