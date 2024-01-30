using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteGenerator : MonoBehaviour
{
    [SerializeField] private GameObject note;
    private float offsetY;

    public float time;
    
    private float posY;
    private float noteStartPosY;
    private float notePosY;
    
    private void Start()
    {
        notePosY = Sheet.instance.speed;
        noteStartPosY = notePosY * Sheet.instance.noteOffset;

        time = 0f;
    }

    private void Update()
    {
        time += Time.smoothDeltaTime;
        if(time >= 3f) SpwanNote();
    }

    private void SpwanNote()
    {
        posY = noteStartPosY + notePosY * 0.001f;
        Instantiate(note, new Vector3(0f, posY, 0f), Quaternion.identity);
        time = 0f;
    }
}
