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
        int lineNumber;
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

                    int.TryParse(textSplit[0], out lineNumber);
                    float.TryParse(textSplit[2], out noteTime);

                    if(lineNumber == 64) lineNumber = 1;
                    else if (lineNumber == 192) lineNumber = 2;
                    else if (lineNumber == 320) lineNumber = 3;
                    else if (lineNumber == 448) lineNumber = 4;

                    sheet.SetNote(lineNumber, noteTime);
                    
                    sheetText = strReader.ReadLine();
                }
            }
            sheetText = strReader.ReadLine();
        }
    }
}
