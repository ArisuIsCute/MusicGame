using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetPaser : MonoBehaviour
{
    public static SheetPaser instance = null;
    
    [SerializeField] private TextAsset textAsset;

    private StringReader strReader;

    private string[] textSplit;
    private string sheetText = "";

    private int lineNum;
    private float noteTime;
    public int noteCount;

    private Sheet sheet;

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
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
    }

    public void StartPaserSheet(TextAsset text)
    {
        sheet.ResetSheet();
        noteCount = 0;
        textAsset = text;
        strReader = new StringReader(textAsset.text);
        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();
                while (sheetText != null && !sheetText.StartsWith("["))
                {
                    textSplit = sheetText.Split(',');
                    lineNum = textSplit[0] switch
                    {
                        "64" => 1,
                        "192" => 2,
                        "320" => 3,
                        "448" => 4,
                        _ => lineNum
                    };
                    noteCount++;
                    noteTime = int.Parse(textSplit[2]);
                    sheet.SetNote(lineNum, noteTime);
                    sheetText = strReader.ReadLine();
                }
            }
            sheetText = strReader.ReadLine();
        }
    }
}
