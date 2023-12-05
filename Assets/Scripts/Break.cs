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
        if (!(exitTime >= 1f)) return;
        var sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "Select":
                SceneManager.LoadScene("Title");
                break;
            case "InGame":
                SceneManager.LoadScene("Result");
                break;
        }
    }
    
}
