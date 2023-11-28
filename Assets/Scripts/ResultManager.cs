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
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        
        score.text = Math.Truncate(scoreManager.score).ToString();
        combo.text = scoreManager.combo.ToString();
        maxCombo.text = scoreManager.maxCombo.ToString();

        perfect.text = scoreManager.perfectCnt.ToString();
        great.text = scoreManager.greatCnt.ToString();
        good.text = scoreManager.goodCnt.ToString();
        bad.text = scoreManager.badCnt.ToString();
        miss.text = scoreManager.badCnt.ToString();
    }

    public void Exit()
    {
        Destroy(scoreManager.gameObject);
        SceneManager.LoadScene("Select");
    }
}
