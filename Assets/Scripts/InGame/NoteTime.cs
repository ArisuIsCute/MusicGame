using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTime : MonoBehaviour
{
    private float currentTime = 0f;
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
    
    private Sheet sheet;
    private Music music;
    private ScoreManager scoreManager;

    private void Start()
    {
        sheet = Sheet.instance;
        music = Music.instance;
        scoreManager = ScoreManager.instance;
        
        SetQueue();
    }

    private void Update()
    {
        currentTime = music.audio.timeSamples;

        if (noteTimeLine1.Count > 0)
        {
            currentNoteTime1 = noteTimeLine1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime1 + missRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine1.Dequeue();
            }
        }

        if (noteTimeLine2.Count > 0)
        {
            currentNoteTime2 = noteTimeLine2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime2 + missRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine2.Dequeue();
            }
        }

        if (noteTimeLine3.Count > 0)
        {
            currentNoteTime3 = noteTimeLine3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime3 + missRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine3.Dequeue();
            }
        }

        if (noteTimeLine4.Count > 0)
        {
            currentNoteTime4 = noteTimeLine4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime4 + missRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine4.Dequeue();
            }
        }
    }

    public void TapNote(int lineNum)
    {
        this.lineNum = lineNum;

        if (lineNum.Equals(1))
        {
            if (noteTimeLine1.Count == 0) return;

            if (Math.Abs(currentNoteTime1 - currentTime) <= perfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= greatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= goodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= badRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine1.Dequeue();
            }else if (currentNoteTime1 + missRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine1.Dequeue();
            }
        }

        if (lineNum.Equals(2))
        {
            if(noteTimeLine2.Count == 0) return;

            if (Math.Abs(currentNoteTime2 - currentTime) <= perfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= greatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= goodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= badRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine2.Dequeue();
            }else if (currentNoteTime2 + missRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine2.Dequeue();
            }
        }

        if (lineNum.Equals(3))
        {
            if (noteTimeLine3.Count == 0) return;

            if (Math.Abs(currentNoteTime3 - currentTime) <= perfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= greatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= goodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= badRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine3.Dequeue();
            }else if (currentNoteTime3 + missRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine3.Dequeue();
            }
        }

        if (lineNum.Equals(4))
        {
            if (noteTimeLine4.Count == 0) return;

            if (Math.Abs(currentNoteTime4 - currentTime) <= perfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= greatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= goodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= badRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine4.Dequeue();
            }else if (currentNoteTime4 + missRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine4.Dequeue();
            }
        }
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
