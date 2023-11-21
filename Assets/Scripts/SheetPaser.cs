using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetPaser : MonoBehaviour
{
    private TextAsset textAsset;

    private StringReader strReader;

    private string[] textSplit;
    private string sheetText = "";

    private int lineNum;
    private float noteTime;
    public int noteCount;

    private Sheet sheet;

    private void Awake()
    {
        strReader = new StringReader(textAsset.text);
    }

    private void Start()
    {
        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();
            }   
        }
    }
}
