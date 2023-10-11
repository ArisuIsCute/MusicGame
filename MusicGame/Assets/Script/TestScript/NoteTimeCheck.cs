using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTimeCheck : MonoBehaviour
{
    private float currentTime;
    private float currentNoteTime1;
    private float currentNoteTime2;
    private float currentNoteTime3;
    private float currentNoteTime4;

    private float greatRate = 3025f;
    private float goodRate = 7050f;
    private float missRate = 16100f;

    private int lineNum;
    
    private Queue<float> noteTimeLine1 = new Queue<float>();
    private Queue<float> noteTimeLine2 = new Queue<float>();
    private Queue<float> noteTimeLine3 = new Queue<float>();
    private Queue<float> noteTimeLine4 = new Queue<float>();

    private Sheet sheet;
    private MusicManager musicManager;
    private Score score;
    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
        
        SetQueue();
    }

    private void Update()
    {
        currentTime = musicManager.music.timeSamples;
        if (noteTimeLine1.Count > 0)
        {
            currentNoteTime1 = noteTimeLine1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * musicManager.music.clip.frequency;
        }
        
        if (noteTimeLine2.Count > 0)
        {
            currentNoteTime2 = noteTimeLine2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * musicManager.music.clip.frequency;
        }
        
        if (noteTimeLine3.Count > 0)
        {
            currentNoteTime3 = noteTimeLine3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * musicManager.music.clip.frequency;
        }
        
        if (noteTimeLine4.Count > 0)
        {
            currentNoteTime4 = noteTimeLine4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * musicManager.music.clip.frequency;
        }
    }

    public void TapNote(int lineNum)
    {
        this.lineNum = lineNum;

        if (lineNum.Equals(1))
        {
            if (Mathf.Abs(currentNoteTime1 - currentTime) <= greatRate)
            {
                score.ProcessScore(2);
                noteTimeLine1.Dequeue();
            }else if (Mathf.Abs(currentNoteTime1 - currentTime) <= goodRate)
            {
                score.ProcessScore(1);
                noteTimeLine1.Dequeue();
            }else if (currentNoteTime1 + missRate <= currentTime)
            {
                score.ProcessScore(0);
                noteTimeLine1.Dequeue();
            }
        }

        if (lineNum.Equals(2))
        {
            if (Mathf.Abs(currentNoteTime2 - currentTime) <= greatRate)
            {
                score.ProcessScore(2);
                noteTimeLine2.Dequeue();
            }else if (Mathf.Abs(currentNoteTime2 - currentTime) <= goodRate)
            {
                score.ProcessScore(1);
                noteTimeLine2.Dequeue();
            }else if (currentNoteTime2 + missRate <= currentTime)
            {
                score.ProcessScore(0);
                noteTimeLine2.Dequeue();
            }
        }

        if (lineNum.Equals(3))
        {
            if (Mathf.Abs(currentNoteTime3 - currentTime) <= greatRate)
            {
                score.ProcessScore(2);
                noteTimeLine3.Dequeue();
            }else if (Mathf.Abs(currentNoteTime3 - currentTime) <= goodRate)
            {
                score.ProcessScore(1);
                noteTimeLine3.Dequeue();
            }else if (currentNoteTime3 + missRate <= currentTime)
            {
                score.ProcessScore(0);
                noteTimeLine3.Dequeue();
            }
        }

        if (lineNum.Equals(4))
        {
            if (Mathf.Abs(currentNoteTime4 - currentTime) <= greatRate)
            {
                score.ProcessScore(2);
                noteTimeLine4.Dequeue();
            }else if (Mathf.Abs(currentNoteTime4 - currentTime) <= goodRate)
            {
                score.ProcessScore(1);
                noteTimeLine4.Dequeue();
            }else if (currentNoteTime4 + missRate <= currentTime)
            {
                score.ProcessScore(0);
                noteTimeLine4.Dequeue();
            }
        }
    }

    private void SetQueue()
    {
        foreach (var noteTime in sheet.noteLine1)
            noteTimeLine1.Enqueue(noteTime + 100);
        foreach (var noteTime in sheet.noteLine2)
            noteTimeLine2.Enqueue(noteTime + 100);
        foreach (var noteTime in sheet.noteLine3)
            noteTimeLine3.Enqueue(noteTime + 100);
        foreach (var noteTime in sheet.noteLine4)
            noteTimeLine4.Enqueue(noteTime + 100);
    }
}
