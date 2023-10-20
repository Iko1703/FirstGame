using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public GameObject apple, bread;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }
    private void Update()
    {
        if (transform.childCount <=0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void UseItem()
    {
        foreach(Transform child in transform)
        {
            if (ScoreAll.Health != ScoreAll.maxHearts * 2)
            {
                GameObject.Destroy(child.gameObject);
                if (child.gameObject.tag == "apple")
                {
                    ScoreAll.Health++;
                }
                else if (child.gameObject.tag == "bread")
                {
                    ScoreAll.Health += 2;
                }

                inventory.isFull[i] = false;
            }
                   
            
        }
    }
}
