using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI musicName;
    [SerializeField] private TextMeshProUGUI maxComboText;
    [SerializeField] private GameObject textBackground;

    public float score;
    public int combo;
    public int maxCombo;
    
    private float baseScore;
    private float perfectScore;
    private float greatScore;
    private float goodScore;

    public int perfectCnt;
    public int greatCnt;
    public int goodCnt;
    public int badCnt;
    public int missCnt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ResetText();
        
        baseScore = 1000000f / SheetPaser.instance.noteCount;
        perfectScore = baseScore;
        greatScore = baseScore * 0.33f;
        goodScore = baseScore * 0.042f;
    }

    private void ResetText()
    {
        textBackground.SetActive(false);
        rankText.text = "";
        comboText.text = "";
        maxComboText.text = "";
        scoreText.text = "";
        musicName.text = Sheet.instance.songName;
    }

    public void AddScore(int rank)
    {
        textBackground.SetActive(true);
        if (rank.Equals(1))
        {
            score += perfectScore;
            rankText.text = "PERFECT";
            perfectCnt++;
            combo++;
        }else if (rank.Equals(2))
        {
            score += greatScore;
            rankText.text = "GREAT";
            greatCnt++;
            combo++;
        }else if (rank.Equals(3))
        {
            rankText.text = "GOOD";
            goodCnt++;
            score += goodScore;
        }else if (rank.Equals(4))
        {
            badCnt++;
            rankText.text = "BAD";
        }else if (rank.Equals(5))
        {
            missCnt++;
            rankText.text = "MISS";
            combo = 0;
        }
        
        UpdateUi();
        GetMaxCombo();
    }

    private void UpdateUi()
    {
        comboText.text = combo.ToString();
        scoreText.text = Math.Truncate(score).ToString();
    }

    private void GetMaxCombo()
    {
        if (combo > maxCombo) maxCombo = combo;
        maxComboText.text = maxCombo.ToString();
    }
}
