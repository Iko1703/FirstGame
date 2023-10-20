using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_spider_arrow : MonoBehaviour
{
    public float lifeTime;
    public float speed;
    public float distance;
    private Transform player;
    public LayerMask whatIsSolid;
    Vector2 playerPosition;
    private CircleCollider2D collider;
    private float collidersize;
    private bool isTransform = true;

    public float timeForcollider = 2f;
    private void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPosition = new Vector2(player.position.x, player.position.y);
        collider = GetComponent<CircleCollider2D>();
        collider.radius = 0.2f;
    }
    private void Update()
    {

        while(timeForcollider >=0)
        {
            timeForcollider-= Time.deltaTime;
            
        }

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
        
        
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        
        
        
             
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 0 ;
            Move.speed = 15f;
            ScoreAll.Health--;
        }
        
    }

}
