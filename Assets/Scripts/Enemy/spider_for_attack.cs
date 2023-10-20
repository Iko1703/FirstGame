using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_for_attack : MonoBehaviour
{
    private float TimeBeforeShots;
    private float startTimeShots = 3f;
    
    public Animator anim;
    private void Start()
    {
        TimeBeforeShots = startTimeShots;
       
    }
    private void FixedUpdate()
    {
        if (TimeBeforeShots >= 0)
        {
            TimeBeforeShots -= Time.deltaTime;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && TimeBeforeShots <= 0)
        {
            anim.SetTrigger("isAttack");

            TimeBeforeShots = startTimeShots;


        }

    }
}
