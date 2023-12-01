using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetInput : MonoBehaviour
{
    public KeyCode key1 = KeyCode.A;
    public KeyCode key2 = KeyCode.S;
    public KeyCode key3 = KeyCode.K;
    public KeyCode key4 = KeyCode.L;

    [SerializeField] private GameObject[] inputs;
    [SerializeField] private GameObject[] effects;
    
    private NoteTime noteTime;

    private void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

        noteTime = GameObject.Find("NoteTime").GetComponent<NoteTime>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            OnInput(0);
            noteTime.TapNote(1);
        }

        if (Input.GetKeyDown(key2))
        {
            OnInput(1);
            noteTime.TapNote(2);
        }

        if (Input.GetKeyDown(key3))
        {
            OnInput(2);
            noteTime.TapNote(3);
        }

        if (Input.GetKeyDown(key4))
        {
            OnInput(3);
            noteTime.TapNote(4);
        }
        
        if(Input.GetKeyUp(key1)) OffInput(0);
        if(Input.GetKeyUp(key2)) OffInput(1);
        if(Input.GetKeyUp(key3)) OffInput(2);
        if(Input.GetKeyUp(key4)) OffInput(3);

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Result");
    }

    private void OnInput(int line)
    {
        effects[line].SetActive(true);
        inputs[line].SetActive(true);
    }

    private void OffInput(int line)
    {
        effects[line].SetActive(false);
        inputs[line].SetActive(false);
    }
}
