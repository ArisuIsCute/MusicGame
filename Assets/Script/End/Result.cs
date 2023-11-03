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
    [SerializeField] private TextMeshProUGUI perfectCountText;
    [SerializeField] private TextMeshProUGUI maxPerfectCountText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rankText;

    private SheetPaser sheetPaser;
    private Score score;
    private int note;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
        score = GameObject.Find("Score").GetComponent<Score>();

        comboText.text = "Combo : " + score.Combo.ToString();
        maxComboText.text = "MaxCombo : " + score.MaxCombo.ToString();
        missCountText.text = "Miss : " + score.MissCnt.ToString();
        goodCountText.text = "Good : " + score.GoodCnt.ToString();
        greatCountText.text = "Great : " + score.GreatCnt.ToString();
        perfectCountText.text = "Perfect : " + score.PerfectCnt.ToString();
        maxPerfectCountText.text = "MaxPerfect : " + score.MaxPerfectCnt.ToString();
        scoreText.text = "Score : " + score.MusicScore.ToString();
    }
}
