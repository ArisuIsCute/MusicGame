using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Break : MonoBehaviour
{
    private KeyCode exitKey = KeyCode.Escape;
    private float exitTime;
    
    private void Update()
    {
        if (Input.GetKey(exitKey)) exitTime += Time.deltaTime;
        if (Input.GetKeyUp(exitKey)) exitTime = 0;
        if (!(exitTime >= .5f)) return;

        if (SceneManager.GetActiveScene().name == "InGame")
        {
            SceneManager.LoadScene("Result");
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
    }
    
}
