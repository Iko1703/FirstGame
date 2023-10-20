using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_for_attak : MonoBehaviour
{    
    public Animator animator;    
    public Animator playerAnimatordead;
    private float timeBeforeAttack;
    public float startTimeBeforeAttack = 3f;
    

   

    private void OnTriggerStay2D(Collider2D other)
    {
        if (animator.GetBool("isDead") == false && playerAnimatordead.GetBool("isDie") == false)
        {
            if (other.CompareTag("Player"))
            {
                if (timeBeforeAttack <= 0)
                {
                    animator.SetTrigger("attack");
                    timeBeforeAttack = startTimeBeforeAttack;
                }
                else
                {
                    timeBeforeAttack -= Time.deltaTime;
                }
            }
        }


    }
}
