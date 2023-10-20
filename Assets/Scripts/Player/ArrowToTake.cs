using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowToTake : MonoBehaviour
{  
    private void OnTriggerEnter2D(Collider2D collision)
    {        
            if (collision.gameObject.tag == "Player")
            {
                if (ScoreAll.ScoreOfArrow < ScoreAll.maxScoreOfArrow)
                {
                    ScoreAll.ScoreOfArrow++;
                    Destroy(gameObject);
                }
            }          
    }
    
}
