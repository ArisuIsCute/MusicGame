using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadSceneAsync("InGame");
    }
}
