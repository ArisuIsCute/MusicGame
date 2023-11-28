using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float speed;

    private NoteGenerator noteGenerator;

    private void Start()
    {
        noteGenerator = GameObject.Find("NoteGenerator").GetComponent<NoteGenerator>();

        speed = noteGenerator.scrollSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.smoothDeltaTime));
        if(transform.position.y < - 10f) Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        if(transform.position.y <= -5.3f) Destroy(gameObject);
    }
}
