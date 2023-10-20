using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textscore;
    void Update()
    {
        textscore.text = Convert.ToString(ScoreAll.Score);  
    }
}
