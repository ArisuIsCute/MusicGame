using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    public KeyCode key1 = KeyCode.A;
    public KeyCode key2 = KeyCode.S;
    public KeyCode key3 = KeyCode.K;
    public KeyCode key4 = KeyCode.L;

    private NoteTime noteTime;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        noteTime = GameObject.Find("NoteTime").GetComponent<NoteTime>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(key1)) noteTime.TapNote(1);
        if(Input.GetKeyDown(key2)) noteTime.TapNote(2);
        if(Input.GetKeyDown(key3)) noteTime.TapNote(3);
        if(Input.GetKeyDown(key4)) noteTime.TapNote(4);
    }
}
