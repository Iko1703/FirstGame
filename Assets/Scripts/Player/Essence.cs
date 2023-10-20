using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Essence : MonoBehaviour
{
    private Rigidbody2D rb;
    private Score ScoreSlime;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreSlime = FindObjectOfType<Score>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreAll.Score++;
            Destroy(gameObject);
        }
    }
}
