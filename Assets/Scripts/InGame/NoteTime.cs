using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteTime : MonoBehaviour
{
    private float currentTime = 0f;
    private float currentNoteTime1;
    private float currentNoteTime2;
    private float currentNoteTime3;
    private float currentNoteTime4;

    private const float PerfectRate = 2500f;
    private const float GreatRate = 5000f;
    private const float GoodRate = 7000f;
    private const float BadRate = 10000f;
    private const float MissRate = 13000f;

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

            if (currentNoteTime1 + MissRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine1.Dequeue();
            }
        }

        if (noteTimeLine2.Count > 0)
        {
            currentNoteTime2 = noteTimeLine2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime2 + MissRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine2.Dequeue();
            }
        }

        if (noteTimeLine3.Count > 0)
        {
            currentNoteTime3 = noteTimeLine3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime3 + MissRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine3.Dequeue();
            }
        }

        if (noteTimeLine4.Count > 0)
        {
            currentNoteTime4 = noteTimeLine4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime4 + MissRate < currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine4.Dequeue();
            }
        }
        
        // if (Math.Abs(currentNoteTime2 - currentTime) <= PerfectRate)
        // {
        //     EditorApplication.isPaused = true;
        // }
        //if((currentNoteTime2 - currentTime) >= PerfectRate) EditorApplication.isPaused = true;
    }

    public void TapNote(int lineNum)
    {
        this.lineNum = lineNum;
        
        if (lineNum.Equals(1))
        {
            if (noteTimeLine1.Count == 0) return;
                    
            if (Math.Abs(currentNoteTime1 - currentTime) <= PerfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= GreatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= GoodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= BadRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine1.Dequeue();
            }else if (currentNoteTime1 + MissRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine1.Dequeue();
            }
            else
            {
                scoreManager.AddScore(5);
            }
        }

        if (lineNum.Equals(2))
        {
            if(noteTimeLine2.Count == 0) return;

            if (Math.Abs(currentNoteTime2 - currentTime) <= PerfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= GreatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= GoodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= BadRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine2.Dequeue();
            }else if (currentNoteTime2 + MissRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine2.Dequeue();
            }
            else
            {
                scoreManager.AddScore(5);
            }
        }

        if (lineNum.Equals(3))
        {
            if (noteTimeLine3.Count == 0) return;

            if (Math.Abs(currentNoteTime3 - currentTime) <= PerfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= GreatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= GoodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= BadRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine3.Dequeue();
            }else if (currentNoteTime3 + MissRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine3.Dequeue();
            }
            else
            {
                scoreManager.AddScore(5);
            }
        }

        if (lineNum.Equals(4))
        {
            if (noteTimeLine4.Count == 0) return;

            if (Math.Abs(currentNoteTime4 - currentTime) <= PerfectRate)
            {
                scoreManager.AddScore(1);
                noteTimeLine4.Dequeue();
            }
            else if (Math.Abs(currentNoteTime4 - currentTime) <= GreatRate)
            {
                scoreManager.AddScore(2);
                noteTimeLine4.Dequeue();
            }
            else if (Math.Abs(currentNoteTime4 - currentTime) <= GoodRate)
            {
                scoreManager.AddScore(3);
                noteTimeLine4.Dequeue();
            }
            else if (Math.Abs(currentNoteTime4 - currentTime) <= BadRate)
            {
                scoreManager.AddScore(4);
                noteTimeLine4.Dequeue();
            }
            else if (currentNoteTime4 + MissRate <= currentTime)
            {
                scoreManager.AddScore(5);
                noteTimeLine4.Dequeue();
            }
            else
            {
                scoreManager.AddScore(5);
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
