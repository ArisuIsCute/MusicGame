using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public List<float> noteList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetNote(float noteTime)
    {
        noteList.Add(noteTime);
    }
}
