using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemy_spider : MonoBehaviour
{
    private float TimeBeforeShots;
    private float startTimeShots = 3f;
    public GameObject arrow;
    public Transform shotPoint;
    private Animator anim;

    public int healpoint = 3;


    public float offset;

    private void Start()
    {
        TimeBeforeShots = startTimeShots;
        anim = GetComponent<Animator>();
    }
    /*private void FixedUpdate()
    {
        if (TimeBeforeShots >= 0)
        {
            TimeBeforeShots -= Time.deltaTime;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && TimeBeforeShots<=0)
        {
            anim.SetTrigger("isAttack");
            
            TimeBeforeShots = startTimeShots;
            

        }
        
    }*/
    public void EndAttack()
    {
        anim.SetTrigger("endAttack");
    }
    public void Attack()
    {
        Instantiate(arrow, shotPoint.transform.position, Quaternion.identity);
    }
    public void TakeDamage(int damage)
    {

        healpoint -= damage;
        anim.SetTrigger("isHeat");
        //anim.SetTrigger("");
        if (healpoint <= 0)
            {
                Die();
            }       
    }
    public void HeatEnd()
    {
        anim.SetTrigger("andHeat");
    }
    private void Die()
    {
        anim.SetTrigger("isDead");
        
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        //GetComponent<patrol>().enabled = false;
        //this.enabled = false;

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //GetComponent<NavMeshAgent>().enabled = false;
        
        
        
    }
}

