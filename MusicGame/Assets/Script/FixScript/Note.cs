using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private NoteMaker noteMaker;
    private float speed;
    
    private void Start()
    {
        noteMaker = GameObject.Find("NoteMaker").GetComponent<NoteMaker>();
        speed = noteMaker.scrollSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.smoothDeltaTime));
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
