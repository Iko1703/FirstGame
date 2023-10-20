using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpoint : MonoBehaviour
{
    public enemy enemy;
    private spawner spawner;
    void Start()
    {
        spawner = FindObjectOfType<spawner>();
        
        Instantiate(enemy,transform.position,transform.rotation);
        enemy.maxhealth = spawner.enemyHealth;
        enemy.damage = spawner.enemyDamage;

    }

    
    void Update()
    {
        
    }
}
