using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSongList : MonoBehaviour
{
    private string patch = Application.dataPath + "/Resources/Songs/";

    public List<string> songNameList = new List<string>();
    public List<string> songComposerList = new List<string>();
    public List<string> songAudioPatchList = new List<string>();
    public List<string> songSheetPatchList = new List<string>();
    public int songCnt = 0;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
                    
                    if(splitData[0] == "SongName") songNameList.Add(splitData[1]);
                    if(splitData[0] == "Composer") songComposerList.Add(splitData[1]);
                    if(splitData[0] == "AudioPatch") songAudioPatchList.Add(splitData[1]);
                    if(splitData[0] == "SheetPatch") songSheetPatchList.Add(splitData[1]);
                }
            }
        }
    }
}
