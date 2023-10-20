using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScoreForPlayer : MonoBehaviour
{  
    public Text textscoreArrow;
    private Move bow;
    private int score;

    private void Start()
    {
        bow = FindAnyObjectByType<Move>();
        score = 0;
    }
    void Update()
    { 
        textscoreArrow.text = Convert.ToString(score) + "/" + ScoreAll.maxScoreOfArrow;
        score = ScoreAll.ScoreOfArrow;
    }
}
