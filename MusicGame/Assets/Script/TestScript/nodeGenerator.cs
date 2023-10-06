using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeGenerator : MonoBehaviour
{
    private Sheet sheet;
    
    public GameObject notePrefab;

    public float scrollSpeed;

    private float noteCorrectRate = 0.001f;
    
    private float notePosY;
    private float noteStartPosY;

    public bool isGenFin;
    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        scrollSpeed = 17f;
        notePosY = scrollSpeed;
        noteStartPosY = scrollSpeed * 3.0f;
    }

    private void Update()
    {
        if (isGenFin.Equals(false))
        {
            GenNote();
            isGenFin = true;
        }
    }

    private void GenNote()
    {
        GenNoteList(sheet.noteList, notePrefab);        
    }

    private void GenNoteList(List<float> noteList, GameObject notePrefab)
    {
        float posY;
        foreach (float noteTime in noteList)
        {
            posY = noteStartPosY + notePosY * (noteTime * noteCorrectRate);
            Instantiate(notePrefab, new Vector3(0f, posY, 0f), Quaternion.identity);
        }
    }
}
