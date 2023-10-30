using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rankText;

    private string rankStr = "";
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Combo = 0;
        MusicScore = 0;
        MaxCombo = 0;
        MissCnt = 0;
        GoodCnt = 0;
        GreatCnt = 0;
    }

    public void SetScore(int rank)
    {
        if (rank.Equals(0))
        {
            rankStr = "MISS";
            Combo = 0;
            MusicScore -= 30;
            MissCnt++;
        }else if (rank.Equals(1))
        {
            rankStr = "GOOD";
            Combo++;
            MusicScore += 50;
            GoodCnt++;
        }else if (rank.Equals(2))
        {
            rankStr = "PERFECT";
            Combo++;
            MusicScore += 100;
            GreatCnt++;
        }
        SetMaxCombo();
        SetTexts();
    }

    private void SetMaxCombo()
    {
        if (Combo > MaxCombo)
        {
            MaxCombo = Combo;
        }
    }

    private void SetTexts()
    {
        rankText.text = rankStr;
        scoreText.text = MusicScore.ToString();
        comboText.text = Combo.ToString();
    }
}
