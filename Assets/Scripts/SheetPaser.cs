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

    public void StartPaserSheet(string patch)
    {
        textAsset = Resources.Load<TextAsset>(patch);
        strReader = new StringReader(textAsset.text);
        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();
                if (sheetText != null) textSplit = sheetText.Split(",");
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
            }

            sheetText = strReader.ReadLine();
        }
    }
}
