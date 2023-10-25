using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note_TEST : MonoBehaviour
{
    private nodeGenerator node;
    
    [SerializeField] private float speed;

    private void Start()
    {
        node = GameObject.Find("nodeGenerator").GetComponent<nodeGenerator>();
        speed = node.scrollSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.smoothDeltaTime));
    }

    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y <= -4.5f)
        {
            Destroy(gameObject);
        }
    }
}
