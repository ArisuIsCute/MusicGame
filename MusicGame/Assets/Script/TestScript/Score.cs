using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int MusicScore { private set; get; }
    public int Combo { private set; get; }
    public int MaxCombo { private set; get; }
    public int MissCnt { private set; get; }
    public int GoodCnt { private set; get; }
    public int GreatCnt { private set; get; }

    private string rankStr;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI comboText;
    private TextMeshProUGUI rankText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = GameObject.Find("ComboText").GetComponent<TextMeshProUGUI>();
        rankText = GameObject.Find("RankText").GetComponent<TextMeshProUGUI>();
        
        MusicScore = 0;
        Combo = 0;
        MaxCombo = 0;
        MissCnt = 0;
        GoodCnt = 0;
        GreatCnt = 0;

        SetScoreText();
    }

    public void ProcessScore(int rank)
    {
        if (rank.Equals(0))
        {
            rankStr = "MISS";
            Combo = 0;
            MusicScore -= 30;
            MissCnt++;
        }
        else if (rank.Equals(1))
        {
            rankStr = "GOOD";
            MusicScore += 50;
            Combo++;
            GoodCnt++;
        }else if (rank.Equals(2))
        {
            rankStr = "PERFECT";
            MusicScore += 100;
            Combo++;
            GreatCnt++;
        }
        SetMaxCombo();
        SetScoreText();
    }

    private void SetMaxCombo()
    {
        if (Combo > MaxCombo)
            MaxCombo = Combo;
    }

    private void SetScoreText()
    {
        rankText.text = rankStr;
        scoreText.text = MusicScore.ToString();
        comboText.text = Combo.ToString();
    }
}
