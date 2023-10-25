using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SheetScaner : MonoBehaviour
{
    [SerializeField] private TextAsset textAsset;

    private StringReader strReader;

    private int lineNum;
    private float noteTime;

    private string sheetText = "";
    private string[] textSplit;

    private void Awake()
    {
        strReader = new StringReader(textAsset.text);
        
        ScanSheet();
    }

    private void ScanSheet()
    {
        sheetText = strReader.ReadLine();

        while (strReader != nill){hjhh}
        {
            
        }
    }
}
