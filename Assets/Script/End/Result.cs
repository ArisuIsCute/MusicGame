using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI maxComboText;
    [SerializeField] private TextMeshProUGUI missCountText;
    [SerializeField] private TextMeshProUGUI goodCountText;
    [SerializeField] private TextMeshProUGUI greatCountText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rankText;
    
    private Score score;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();

        if (score.GreatCnt > score.GoodCnt + score.MissCnt)
        {
            rankText.text = "S";
        }else if (score.GoodCnt > score.MissCnt)
        {
            rankText.text = "A";
        }
        else
        {
            rankText.text = "B";
        }
        
        
        comboText.text = "Combo : " + score.Combo.ToString();
        maxComboText.text = "MaxCombo : " + score.MaxCombo.ToString();
        missCountText.text = "Miss : " + score.MissCnt.ToString();
        goodCountText.text = "Good : " + score.GoodCnt.ToString();
        greatCountText.text = "Perfect : " + score.GreatCnt.ToString();
        scoreText.text = "Score : " + score.MusicScore.ToString();
    }
}
