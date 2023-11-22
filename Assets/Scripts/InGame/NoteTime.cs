using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTime : MonoBehaviour
{
    private float currentTime;
    private float currentNoteTime1;
    private float currentNoteTime2;
    private float currentNoteTime3;
    private float currentNoteTime4;

    private float perfectRate = 2500f;
    private float greatRate = 5000f;
    private float goodRate = 7000f;
    private float badRate = 11000f;
    private float missRate = 16000f;

    private int lineNum;

    private Queue<float> noteTimeLine1 = new Queue<float>();
    private Queue<float> noteTimeLine2 = new Queue<float>();
    private Queue<float> noteTimeLine3 = new Queue<float>();
    private Queue<float> noteTimeLine4 = new Queue<float>();
    public bool isEnd = false;

    private Sheet sheet;
    private Music music;

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        music = GameObject.Find("Music").GetComponent<Music>();
        
        SetQueue();
    }


    private void SetQueue()
    {
        foreach(var noteTime in sheet.noteLine1)
            noteTimeLine1.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine2)
            noteTimeLine2.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine3)
            noteTimeLine3.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine4)
            noteTimeLine4.Enqueue(noteTime);
    }
}
