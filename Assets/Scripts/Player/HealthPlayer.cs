using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    private int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emtpyHeart;

    private void FixedUpdate()
    {
        health = ScoreAll.Health;
        if (health > ScoreAll.maxHearts * 2)
        {
            ScoreAll.Health = ScoreAll.maxHearts * 2;
        }
        
        for (int i = 0; i < ScoreAll.maxHearts; i++)
        {
            if (health % 2 == 0)
            {
                if (i < health / 2)
                {
                    hearts[i].sprite = fullHeart;

                }
                else
                {
                    hearts[i].sprite = emtpyHeart;
                }
                //hearts[health / 2 - 1].sprite = halfHeart;
            }
            else
            {
                if (i < health / 2)
                {
                    hearts[i].sprite = fullHeart;

                }
                else
                {
                    if (i * 2 + 1 == health)
                    {
                        hearts[i].sprite = halfHeart;
                    }
                    else
                    {
                        hearts[i].sprite = emtpyHeart;
                    }
                }
            }



            hearts[i].enabled = true;
            
        }
        for (int i = ScoreAll.maxHearts; i <5; i++)
        {
            hearts[i].enabled = false;
        }

    }
    
}
