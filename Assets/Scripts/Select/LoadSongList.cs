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
            using (StreamReader streamReader = new StreamReader(patch + di.Name + "/" + di.Name + "_data.txt"))
            {
                while ((data = streamReader.ReadLine()) != null)
                {
                    string[] splitData = data.Split(':');

                    if (splitData[0] == "SongName")
                        songList.songName = splitData[1];
                    else if (splitData[0] == "Composer")
                        songList.composer = splitData[1];
                    else if (splitData[0] == "AudioPatch")
                        songList.song = Resources.Load<AudioClip>("Songs/" + di.Name + "/" + di.Name + "_audio");
                    else if (splitData[0] == "SheetPatch")
                        songList.sheet = Resources.Load<TextAsset>("Songs/" + di.Name + "/" + di.Name + "_sheet");
                }
            }
            
            newSongs.Add(new AddNewSong(songList.songName, songList.composer, songList.song, songList.sheet));
        }
    }
}
