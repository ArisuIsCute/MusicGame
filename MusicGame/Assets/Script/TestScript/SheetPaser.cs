using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetPaser : MonoBehaviour
{
    [SerializeField] private TextAsset textAsset;
    private StringReader strReader;
    
    private Sheet sheet;

    private string sheetText = "";
    private string[] textSplit;

    private void Awake()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();

        strReader = new StringReader(textAsset.text);
        
        ParserSheet();
    }

    private void ParserSheet()
    {
        int laneNumber;
        float noteTime;

        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();
                while (sheetText != null && !sheetText.StartsWith("["))
                {
                    textSplit = sheetText.Split(',');

                    int.TryParse(textSplit[0], out laneNumber);
                    float.TryParse(textSplit[2], out noteTime);

                    if (laneNumber == 192)
                    {
                        sheet.SetNote(noteTime);
                    }

                    sheetText = strReader.ReadLine();
                }
            }
            sheetText = strReader.ReadLine();
        }
    }
}
