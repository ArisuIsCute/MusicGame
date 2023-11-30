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

    private const float NoteCurrentRate = 0.001f;

    private bool isSpwanFin = false;

    public GameObject note;
    
    private Sheet sheet;

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();

        scrollSpeed = 17f;
        notePosY = scrollSpeed;
        noteStartPosY = scrollSpeed * 2.53f;
    }

    private void Update()
    {
        if (isSpwanFin) return;
        SpawnNote();
        isSpwanFin = true;
    }

    private void SpawnNote()
    {
        SpwanNoteLine(sheet.noteLine1, note, new Vector3(-2.083f, 0f, 0f));
        SpwanNoteLine(sheet.noteLine2, note, new Vector3(-0.69f, 0f, 0f));
        SpwanNoteLine(sheet.noteLine3, note, new Vector3(0.69f, 0f, 0f));
        SpwanNoteLine(sheet.noteLine4, note, new Vector3(2.083f, 0f, 0f));
    }

    private void SpwanNoteLine(List<float> noteList, GameObject notePrefab, Vector3 offset)
    {
        foreach (var noteTime in noteList)
        {
            posY = noteStartPosY + notePosY * (noteTime * NoteCurrentRate) + offset.y;
            Instantiate(notePrefab, new Vector3(offset.x, posY, offset.z), Quaternion.identity);
        }
    }
}
