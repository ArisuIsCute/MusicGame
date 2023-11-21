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

    private void SetNdte(int line, float noteTime)
    {
        switch (line)
        {
            case 1:
                noteLine1.Add(noteTime);
                break;
            case 2:
                noteLine2.Add(noteTime);
                break;
            case 3:
                noteLine3.Add(noteTime);
                break;
            case 4:
                noteLine4.Add(noteTime);
                break;
        }
    }
}
