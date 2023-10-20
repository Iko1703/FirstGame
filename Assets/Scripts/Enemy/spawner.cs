using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] variants;

    private float timeBfSpawn;
    public float startTimeBfSpawn,decreaseTime,minTime;
    public int enemyHealth;
    public int enemyDamage;
    public float Timeforupdate;
    private float time;
    void Start()
    {
        time = Timeforupdate;
    }

   
    void Update()
    {
        if (time <=0) 
        {
            enemyDamage++;
            enemyHealth++;
            time = Timeforupdate;
        }
        else
        {
            time -= Time.deltaTime;
        }
        if (timeBfSpawn <=0) 
        {
            int rand = Random.Range(0, variants.Length);
            Instantiate(variants[rand], transform.position, Quaternion.identity);
            timeBfSpawn = startTimeBfSpawn;
            if (startTimeBfSpawn > minTime)
            {
                startTimeBfSpawn -= decreaseTime;

            }
        }
        else
        {
            timeBfSpawn -= Time.deltaTime;
        }
        
    }
}
