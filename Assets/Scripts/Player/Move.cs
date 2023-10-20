using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public static float speed = 30, horizontalspeed = 5;

    private Rigidbody2D rb;
    public GameObject panel;
    public Animator animator;
    private float waittime, starttime = 1.9f;
    
    float timeForUseShift = ScoreAll.timeOfStamina;
    float timeForAFKReload = 2f;
    public Slider slider;
    public Vector3 offset;
    public float maxStamina = ScoreAll.timeOfStamina;

    public float timeStan = 3f;

    public Information pos;
    private void Awake()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waittime = starttime;
        SetStamina(timeForUseShift);
    }

    public void SetStamina(float stamina)
    {
        //slider.gameObject.SetActive(true);
        slider.value = stamina;
        slider.maxValue = maxStamina;
    }
    private void FixedUpdate()
    {
        if (speed !=30)
        {
            if (timeStan >= 0)
            {
                timeStan -= Time.deltaTime;
            }
            else
            {
                timeStan = 3f;
                speed = 30;
            }
        }
        //slider.transform.position = UnityEngine.Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        float needToDevelopment = ScoreAll.timeOfStamina;
        maxStamina = needToDevelopment;
        float constAJust = 1f;
        SetStamina(timeForUseShift);
        if (Input.GetKey(KeyCode.LeftShift) && timeForUseShift >=0)
        {
            timeForUseShift -= Time.deltaTime;
            constAJust = 1.65f;
            timeForAFKReload = 2f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && timeForUseShift <= needToDevelopment)
        {
            
            timeForAFKReload -= Time.deltaTime;
            if (timeForAFKReload <=0)
            {
                timeForUseShift += Time.deltaTime;
                if(timeForUseShift >= needToDevelopment - 0.2f) 
                {
                    timeForAFKReload = 2f;

                }
            }
            
        }                                  
        /*if (timeForUseShift <= 0)
        {
            timeToReloadStamina -= Time.deltaTime;
            if (timeToReloadStamina <= 0 )
            {
                timeToReloadStamina = ScoreAll.timeOfStamina;
                timeForUseShift = needToDevelopment;
            }
        }*/


        if (animator.GetBool("isDie") == false)
        {
            float h = Input.GetAxis("Horizontal") * horizontalspeed * speed * Time.fixedDeltaTime * constAJust;
            float v = Input.GetAxis("Vertical") * horizontalspeed * speed * Time.fixedDeltaTime * constAJust;

            rb.velocity = transform.TransformDirection(new Vector2(h, v));

            if (Input.GetAxis("Horizontal") != 0)
            {
                Flip();
            }
            if ((Input.GetAxis("Vertical") > 0))
            {
                animator.SetFloat("speedUpDown", Mathf.Abs(v));
            }
            if ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0))
            {
                animator.SetFloat("speed", Mathf.Abs(h));
            }
            if ((Input.GetAxisRaw("Vertical") < 0))
            {
                float x = Input.GetAxis("Vertical") * horizontalspeed * speed * Time.fixedDeltaTime;
                animator.SetFloat("speedDown", Mathf.Abs(x));

            }
        }
        

    }
    private void Update()
    {
        
        
        waittime -= Time.deltaTime;
        if (waittime <= 0)
        {
            animator.SetFloat("speedDown", Mathf.Abs(0));
            waittime = starttime;
            animator.SetFloat("speedUpDown", Mathf.Abs(0));
        }
    }
    private void Flip()
    {
        
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Panel()
    {
       
        
        panel.SetActive(true);
    }
    public void ArrowPlus()
    {
        ScoreAll.ScoreOfArrow++;
    }
}
  