using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OffsetUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    private OffsetNoteGenerator noteGen;

    private void Start()
    {
        noteGen = GameObject.Find("OffsetNoteGenerator").GetComponent<OffsetNoteGenerator>();
    }

    private void Update()
    {
        timeText.text = noteGen.time.ToString();
    }
}
