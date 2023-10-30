using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    private NoteTimeCheck noteTimeCheck;
    private GameObject[] notes;

    private KeyCode key1;
    private KeyCode key2;
    private KeyCode key3;
    private KeyCode key4;

    private void Start()
    {
        noteTimeCheck = GameObject.Find("NoteTimeCheck").GetComponent<NoteTimeCheck>();
        
        key1 = KeyCode.A;
        key2 = KeyCode.S;
        key3 = KeyCode.K;
        key4 = KeyCode.L;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            noteTimeCheck.TapNote(1);
        }

        if (Input.GetKeyDown(key2))
        {
            noteTimeCheck.TapNote(2);
        }
        
        if (Input.GetKeyDown(key3))
        {
            noteTimeCheck.TapNote(3);
        }
        
        if (Input.GetKeyDown(key4))
        {
            noteTimeCheck.TapNote(4);
        }
    }
}
