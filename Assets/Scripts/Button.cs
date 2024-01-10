using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadSelect()
    {
        SceneManager.LoadScene("Select");
    }

    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
