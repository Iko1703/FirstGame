using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScale : MonoBehaviour
{
    public GameObject bow;
    public GameObject sword;


    private void OnMouseOver()
    {
        bow.SetActive(false);
        
    }


    public void OnMouseExit()
    {
        if (sword.activeInHierarchy == false)
        {
            bow.SetActive(true);
        }
        
    }
}
