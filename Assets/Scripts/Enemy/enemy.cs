using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int maxhealth = 2;
    [NonSerialized]public int currentHealth;
    public Animator animator;
    public GameObject playerAnimator;
    Animator playerAnimatordead;
    private float timeBeforeAttack;
    public float startTimeBeforeAttack = 3f;
    public int damage =1;
    public float stopTime, startStopTime;
    public HealthPlayer player;
    private Transform playerforposition;
    public float speed, normalSpeed;
    
    public GameObject effectPlayer;
    public GameObject effectEnemy;
    private Rigidbody2D rb;
    public GameObject esence;
    public GameObject arrowToTake;
    public GameObject apple;
    public GameObject bread;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        currentHealth = maxhealth;
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<HealthPlayer>();
        playerAnimator = GameObject.FindGameObjectWithTag ("Player" );
        playerAnimatordead = playerAnimator.GetComponent<Animator>();
        normalSpeed = speed;
        timeBeforeAttack = 0.5f;
    }

   
    void Update()
    {
        playerforposition = GameObject.FindGameObjectWithTag("Player").transform;
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime-=Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        
        if (animator.GetBool("isDead") == false)
        {
            stopTime = startStopTime;
            currentHealth -= damage;
            Instantiate(effectEnemy, transform.position, Quaternion.identity);
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
        
    }
    private void Die()
    {
        
        animator.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        GetComponent<patrol>().enabled = false;
        this.enabled = false;
        
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<NavMeshAgent>().enabled = false;
        float randX = UnityEngine.Random.Range(-0.5f, 0.5f);
        float randY = UnityEngine.Random.Range(-0.5f, 0.5f);
        Vector2 randPositionForEsence = new Vector2(transform.position.x - randX, transform.position.y - randY);
        Vector2 randPositionForArrow = new Vector2(transform.position.x + randX, transform.position.y + randY);
        Instantiate(esence, randPositionForEsence, transform.rotation);
        Instantiate(arrowToTake, randPositionForArrow, arrowToTake.transform.rotation);
        RandomFoodDrope();
    }
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
    public void OnEnemyAttack()
    {
        if (animator.GetBool("isDead") == false)
        {
            ScoreAll.Health -= damage;
            Instantiate(effectPlayer, playerforposition.position, Quaternion.identity);
            timeBeforeAttack = startTimeBeforeAttack;
        }
        
    }
    public void TheEnd()
    {
        animator.SetTrigger("andAttack");
    }
    private void RandomFoodDrope()
    {
        int proccent = UnityEngine.Random.Range(0, 100);
        if (proccent > 50)
        {
            float randX = UnityEngine.Random.Range(-0.5f, 0.5f);
            float randY = UnityEngine.Random.Range(-0.5f, 0.5f);           
            Vector2 randPosition = new Vector2(transform.position.x + randX, transform.position.y + randY);
            int proccentfood = UnityEngine.Random.Range(0, 100);
            if(proccentfood > 66)
            {
                Instantiate(bread, randPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(apple, randPosition, Quaternion.identity);
            }
        }
    }
        
}


