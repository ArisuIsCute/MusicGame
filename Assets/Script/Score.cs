using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int MusicScore { private set; get; }
    public int Combo { private set; get; }
    public int MaxCombo { private set; get; }
    public int MissCnt { private set; get; }
    public int GoodCnt { private set; get; }
    public int GreatCnt { private set; get; }

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
            Combo = 0;
            MusicScore -= 30;
            MissCnt++;
        }else if (rank.Equals(1))
        {
            Combo++;
            MusicScore += 50;
            GoodCnt++;
        }else if (rank.Equals(2))
        {
            Combo++;
            MusicScore += 100;
            GreatCnt++;
        }
        SetMaxCombo();
    }

    private void SetMaxCombo()
    {
        if (Combo > MaxCombo)
        {
            MaxCombo = Combo;
        }
    }
}
