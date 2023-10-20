using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Swith : MonoBehaviour
{
    public GameObject Bow;
    public GameObject Sword;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Bow.activeInHierarchy == true)
            {
                Bow.SetActive(false);
                Sword.SetActive(true);
            }
            else if (Bow.activeInHierarchy == false)
            {
                Bow.SetActive(true);
                Sword.SetActive(false);
            }
        }
    }
}
