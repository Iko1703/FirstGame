using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_die : MonoBehaviour
{
    private HealthPlayer player;
    private Animator animator;
    private Rigidbody2D rb;
    
    
    void Start()
    {
        player = GetComponent<HealthPlayer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        if (ScoreAll.Health <= 0 && animator.GetBool("isDie") == false)
        {

            animator.SetTrigger("Dead") ;
            animator.SetBool("isDie", true);
            rb.bodyType = RigidbodyType2D.Static;
            

        }
    }
    
}
