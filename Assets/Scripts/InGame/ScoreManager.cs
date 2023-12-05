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

    private const float MaxScore = 1000000f;

    public float score = 0000;
    public int combo = 0;
    public int maxCombo = 0;
    
    private float baseScore;
    private float perfectScore;
    private float greatScore;
    private float goodScore;
    private float missScore;

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
        
        baseScore = MaxScore / SheetPaser.instance.noteCount;
        perfectScore = baseScore;
        greatScore = baseScore * 0.33f;
        goodScore = baseScore * 0.042f;
        missScore = baseScore * -0.3f;
    }

    private void ResetText()
    {
        textBackground.SetActive(false);
        rankText.text = "";
        comboText.text = "";
        maxComboText.text = "0";
        scoreText.text = "0,000";
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
            score += missScore;
            combo = 0;
        }
        
        UpdateUi();
        GetMaxCombo();
    }

    private void UpdateUi()
    {
        comboText.text = combo.ToString();
        scoreText.text = $"{Math.Truncate(score):#,###}";
    }

    private void GetMaxCombo()
    {
        if (combo > maxCombo) maxCombo = combo;
        maxComboText.text = maxCombo.ToString();
    }
}
