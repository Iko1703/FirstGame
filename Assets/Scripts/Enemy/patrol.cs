using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class patrol : MonoBehaviour
{

    List<Transform> points = new List<Transform>();
    public NavMeshAgent agent;
    public Rigidbody2D rb;
    public Transform player;
    private Transform target;
    public float speed, agro,vertspeed;
    private float waitTime, startWaittime = 3;
    private int rSpot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GetComponent<Transform>();
        waitTime = startWaittime;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform i in pointsObject)
        {
            points.Add(i);
        }
        rSpot = UnityEngine.Random.Range(0, points.Count); 
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updatePosition = true;
        agent.updateUpAxis = false;
        agent.speed = 1f;
    }

    
    void Update()
    {
        
        agent.speed = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float disttopl = Vector2.Distance(transform.position,player.position );

        

        
        if (disttopl <= agro)
        {
            StartHunting();
            
        }
        else
        {
            if (waitTime <= 0)
            {               
                StopHunting();               
            }
            else
            {
                waitTime -= Time.deltaTime;
            }            
        }        
    }
    public void StartHunting()
    {
        Flip();
        if (Vector2.Distance(transform.position, player.position) < 1f)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y);
            transform.position = this.transform.position;
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            agent.SetDestination(player.position);
            rb.bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    private void StopHunting()
    {
        //transform.position = Vector2.MoveTowards(transform.position, points[rSpot].position, speed * Time.deltaTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        agent.SetDestination(points[rSpot].position);
        if (Vector2.Distance(transform.position, points[rSpot].position) < 2f)
        {
            if (waitTime <= 0)
            {
                rSpot = UnityEngine.Random.Range(0, points.Count);
                waitTime = startWaittime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void Flip()
    {

        if (player.position.x -target.position.x <0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.position.x - target.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
