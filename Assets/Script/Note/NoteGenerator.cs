using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public float scrollSpeed;

    private float posY;
    private float notePosY;
    private float noteStartPosY;

    private float noteCurrentRate = 0.001f;

    private bool isSpawnFin = false;
    
    public GameObject note;
    
    private Sheet sheet;

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();

        scrollSpeed = 17f;
        notePosY = scrollSpeed;
        noteStartPosY = scrollSpeed * 3f;
    }

    private void Update()
    {
        if (isSpawnFin) return;
        SpawnNote();
        isSpawnFin = true;
    }

    private void SpawnNote()
    {
        SpawnNoteList(sheet.noteLine1, note, new Vector3(0f, 0f, 0f));
        SpawnNoteList(sheet.noteLine2, note, new Vector3(0f, 0f, 0f));
        SpawnNoteList(sheet.noteLine3, note, new Vector3(0f, 0f, 0f));
        SpawnNoteList(sheet.noteLine4, note, new Vector3(0f, 0f, 0f));
    }

    private void SpawnNoteList(List<float> noteList, GameObject notePrefab, Vector3 offset)
    {
        foreach (var noteTime in noteList)
        {
            posY = noteStartPosY + notePosY * (noteTime * noteCurrentRate) + offset.y;
            Instantiate(notePrefab, new Vector3(offset.x, posY, offset.z), Quaternion.identity);
        }
    }
}
