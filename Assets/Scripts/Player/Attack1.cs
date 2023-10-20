using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attack1 : MonoBehaviour
{    
    public Animator animator;
    public GameObject trail;
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f,timeBeforeAttack,startTimeBeforeAttack;
    public int attackDamage;
    public GameObject bow;
    public GameObject sword;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        timeBeforeAttack = startTimeBeforeAttack;
    }

    private void Update()
    {
        attackDamage = ScoreAll.damageBySword;
        if (timeBeforeAttack <= 0 && animator.GetBool("isDie") == false )
        {
            if (Input.GetMouseButton(0) && bow.activeSelf || Input.GetMouseButton(0) && sword.activeSelf)
            {
                if (bow.activeInHierarchy == false)
                { 
                    trail.GetComponent<TrailRenderer>().enabled = true; 
                }

                
                animator.SetTrigger("attack");

                
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
                
                for (int i = 0; i < hitEnemies.Length; i++)
                {
                    
                    
                        if (hitEnemies[i].tag == ("Enemy"))
                        {
                            hitEnemies[i].GetComponent<enemy>().TakeDamage(ScoreAll.damageBySword);
                        }
                        if (hitEnemies[i].tag == ("spider"))
                        {
                            hitEnemies[i].GetComponent<enemy_spider>().TakeDamage(ScoreAll.damageBySword);
                        }
                    
                    
                       
                }
                /*foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<enemy>().TakeDamage(ScoreAll.damageBySword);
                    
                }*/
                
                timeBeforeAttack = startTimeBeforeAttack;
            }
            
        }
        else
        {
            timeBeforeAttack -= Time.deltaTime;
        }
        
    }
    

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

    public void TheEndOFTrail()
    {
        trail.GetComponent<TrailRenderer>().enabled = false;
    }
}
