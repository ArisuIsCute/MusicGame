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
    public int MaxPerfectCnt { private set; get; }
    public int PerfectCnt { private set; get; }
    public int MissCnt { private set; get; }
    public int GoodCnt { private set; get; }
    public int GreatCnt { private set; get; }

    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI maxComboText;

    private SheetPaser sheetPaser;

    private float maxScore = 10000f;

    private float baseScore;

    private int maxPerfectScore;
    private int perfectScore;
    private int greatScore;

    private string rankStr = "";
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Combo = 0;
        MaxCombo = 0;
        MusicScore = 0;
        
        MaxPerfectCnt = 0;
        PerfectCnt = 0;
        MissCnt = 0;
        GoodCnt = 0;
        GreatCnt = 0;

        sheetPaser = GameObject.Find("SheetPaser").GetComponent<SheetPaser>();

        baseScore = maxScore / sheetPaser.noteCount;

        maxPerfectScore = (int)baseScore;
        perfectScore = (int)Math.Ceiling(baseScore * 0.33f);
        greatScore = (int)Math.Ceiling(baseScore * 0.042f);

        SetTexts();
    }

    public void SetScore(int rank)
    {
        if (rank.Equals(0))
        {
            //miss
            rankStr = "MISS";
            Combo = 0;
            MissCnt++;
        }else if (rank.Equals(1))
        {
            //good
            rankStr = "GOOD";
            GoodCnt++;
        }else if (rank.Equals(2))
        {
            //great
            rankStr = "GREAT";
            MusicScore += greatScore;
            GreatCnt++;
        }else if (rank.Equals(3))
        {
            //perfect
            rankStr = "PERFECT";
            MusicScore += perfectScore;
            Combo++;
            PerfectCnt++;
        }else if (rank.Equals(4))
        {
            //maxperfect
            rankStr = "MAXPERFECT";
            MusicScore += maxPerfectScore;
            Combo++;
            MaxPerfectCnt++;
        }
        SetMaxCombo();
        SetTexts();
    }

    private void SetMaxCombo()
    {
        if (Combo > MaxCombo) MaxCombo = Combo;
    }

    private void SetTexts()
    {
        rankText.text = rankStr;
        comboText.text = Combo.ToString();
        maxComboText.text = MaxCombo.ToString();
        scoreText.text = MusicScore.ToString();
    }
}
