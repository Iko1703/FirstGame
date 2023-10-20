using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    private float lifetime;
    public float startLifeTime;
    public float distance;
    
    public LayerMask whatIsSolid;
    

    private void Start()
    {
        
        lifetime = startLifeTime;
    }
    private void Update()
    {
        
        
            
            if (lifetime <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                lifetime -= Time.deltaTime;
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy") == true)
                {
                    hit.collider.GetComponent<enemy>().TakeDamage(ScoreAll.damageByBow);
                    Destroy(gameObject);
                }
                if (hit.collider.CompareTag("spider") == true)
                {
                    hit.collider.GetComponent<enemy_spider>().TakeDamage(ScoreAll.damageByBow);
                    Destroy(gameObject);
                }
            if (hit.collider.CompareTag("NotBroke") == true)
                {

                    Destroy(gameObject);
                }
            }
       
    }
}
