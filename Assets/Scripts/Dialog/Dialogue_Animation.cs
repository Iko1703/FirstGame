using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Dialogue_Animation : MonoBehaviour
{
    public Animator startAnim;
    public static Animator animforeveoneNPC;
    public Dialogue_Menager dm;
     

    public void OnTriggerEnter2D(Collider2D collision)
    {
        animforeveoneNPC = startAnim;
        if (collision.gameObject.CompareTag("Player"))
        {
            startAnim.SetBool("Start_Open", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        startAnim.SetBool("Start_Open", false);
        dm.EndDialogue();
    }


}
