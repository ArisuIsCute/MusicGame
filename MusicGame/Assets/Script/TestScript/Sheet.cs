using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public List<float> noteLine1;
    public List<float> noteLine2;
    public List<float> noteLine3;
    public List<float> noteLine4;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetNote(float lineNumber, float noteTime)
    {
        if (lineNumber.Equals(1))
        {
            noteLine1.Add(noteTime);
        }else if (lineNumber.Equals(2))
        {
            noteLine2.Add(noteTime);
        }else if (lineNumber.Equals(3))
        {
            noteLine3.Add(noteTime);
        }else if (lineNumber.Equals(4))
        {
            noteLine4.Add(noteTime);
        }
    }
}
