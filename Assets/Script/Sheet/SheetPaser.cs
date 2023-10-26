using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetPaser : MonoBehaviour
{
    [SerializeField] private TextAsset textAsset;
    
    private StringReader strReader;

    private string[] textSplit;
    private string sheetText = "";

    private int lineNumber;
    private float noteTime;

    private Sheet sheet;

    private void Awake()
    {
        strReader = new StringReader(textAsset.text);
    }

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
    }

    private void PaserSheet()
    {
        sheetText = strReader.ReadLine();

        while (sheetText != null)
        {
            if (sheetText == "[HitObjects]")
            {
                sheetText = strReader.ReadLine();

                while (sheetText != null && !sheetText.StartsWith("["))
                {
                    textSplit = sheetText.Split(',');
                    
                    int.TryParse(textSplit[0],out lineNumber);
                    float.TryParse(textSplit[2], out noteTime);

                    lineNumber = lineNumber switch
                    {
                        64 => 1,
                        192 => 2,
                        320 => 3,
                        448 => 4,
                        _ => lineNumber
                    };

                    sheet.SetNote(lineNumber, noteTime);
                    
                    sheetText = strReader.ReadLine();
                }
            }

            sheetText = strReader.ReadLine();
        }
    }
}
