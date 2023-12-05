using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI combo;
    [SerializeField] private TextMeshProUGUI maxCombo;
    [SerializeField] private TextMeshProUGUI perfect;
    [SerializeField] private TextMeshProUGUI great;
    [SerializeField] private TextMeshProUGUI good;
    [SerializeField] private TextMeshProUGUI bad;
    [SerializeField] private TextMeshProUGUI miss;
    
    private ScoreManager scoreManager;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        scoreManager = ScoreManager.instance;

        score.text = $"{Math.Truncate(scoreManager.score):#,###}";

        combo.text += $"{scoreManager.combo}";
        maxCombo.text += $"{scoreManager.maxCombo}";

        perfect.text += $"{scoreManager.perfectCnt}";
        great.text += $"{scoreManager.greatCnt}";
        good.text += $"{scoreManager.goodCnt}";
        bad.text += $"{scoreManager.badCnt}";
        miss.text += $"{scoreManager.missCnt}";
    }

    public void Exit()
    {
        Destroy(scoreManager.gameObject);
        SceneManager.LoadScene("Select");
    }
}
