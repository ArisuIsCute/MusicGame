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
    
    private Score score;

    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();

        comboText.text = score.Combo.ToString();
        maxComboText.text = score.MaxCombo.ToString();
        missCountText.text = score.MissCnt.ToString();
        goodCountText.text = score.GoodCnt.ToString();
        greatCountText.text = score.GreatCnt.ToString();
        scoreText.text = score.MusicScore.ToString();
    }
}
