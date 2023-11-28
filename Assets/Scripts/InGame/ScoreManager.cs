using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;
    private float combo;
    private float maxCombo = 0;
    
    private float baseScore;
    private float perfectScore;
    private float greatScore;
    private float goodScore;
    
    private SheetPaser sheetPaser;
    
    private void Start()
    {
        sheetPaser = GameObject.Find("SheetPaser").GetComponent<SheetPaser>();

        baseScore = 1000000f / sheetPaser.noteCount;
        perfectScore = baseScore;
        greatScore = baseScore * 0.33f;
        goodScore = baseScore * 0.042f;
    }

    public void AddScore(int rank)
    {
        if (rank.Equals(1))
        {
            score += perfectScore;
            rankText.text = "PERFECT";
            combo++;
        }else if (rank.Equals(2))
        {
            score += greatScore;
            rankText.text = "GREAT";
            combo++;
        }else if (rank.Equals(3))
        {
            rankText.text = "GOOD";
            score += goodScore;
        }else if (rank.Equals(4))
        {
            rankText.text = "BAD";
        }else if (rank.Equals(5))
        {
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
    }
}
