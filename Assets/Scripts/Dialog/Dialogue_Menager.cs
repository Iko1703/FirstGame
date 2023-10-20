using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search.Providers;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Menager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public Animator boxAnim;
    //public Animator startAnim;

    private Queue<string> sentences;

    public GameObject yes;
    public GameObject no;
    public GameObject resume;
    private bool isTryToBreak = false;
    private bool isTryToMax = false;
    string textForNC;
    
    int price;
    string name;
    private void Start()
    {
        sentences = new Queue<string>();
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        
        boxAnim.SetBool("Dialog_Open",true);
        Dialogue_Animation.animforeveoneNPC.SetBool("Start_Open",false);
        
        nameText.text = dialogue.name;
        name = dialogue.name;
        switch (nameText.text)
            {
            case "лютый негр":
                
                //workSpace = ScoreAll.maxScoreOfArrow;
                price = ScoreAll.priceOfArrowMax;
                textForNC = $"хочешь увеличить количество максимально носимых стрел?\nэто будет стоить {price} эссенций";
                break;
            case "тп":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceDamageBySword;
                textForNC = $"хочешь увеличить наносимый урон?\nэто будет стоить {price} эссенций";
                break;
            case "ящер":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceOfHealth;
                textForNC = $"хочешь увеличить здоровьице богатырское? \nэто будет стоить {price} эссенций, хлебни водицы байкальской";
                break;
            case "карыч":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceOfStamina;
                textForNC = $"кар кар, хочешь летать как ворон?\n повысь свою стамину\nэто будет стоить {price} эссенций";
                break;
            case "снуппи":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceDamageByBow;
                textForNC = $"йоу, мен, хочешь стрелять с лука, как с моей пушки-бейби?\n повысь сво1 урон со  стрел\nэто будет стоить {price} эссенций";
                break;

        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        if (isTryToBreak)
        {                     
            sentence = $"хочешь меня обмануть? Проваливай!";
            isTryToBreak = false;           
        }
        else if (isTryToMax)
        {
            sentence = $"Ты на максимуме своей силы в моем снаряжении! Еще встретимся!";
            isTryToMax= false;
        }
        else
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            if (sentences.Count == 2)
            {
                ChoiseDialogue();
                resume.SetActive(false);
                sentence = textForNC;
            }
        }    
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        boxAnim.SetBool("Dialog_Open", false);       
    }

    public void ChoiseDialogue()
    {

        yes.SetActive(true);
        no.SetActive(true);
    }

    public void ChoiseYes()
    {
        if (ScoreAll.Score >= price)
        {   
            int Scorebefor = ScoreAll.Score;
            ScoreAll.Score= ScoreAll.Score - price;
            
            switch (name)
            {
                case "лютый негр":
                    if (ScoreAll.maxScoreOfArrow < ScoreAll.MaxmaxArrow)
                    {
                        ScoreAll.maxScoreOfArrow++;
                        ScoreAll.priceOfArrowMax += 2;
                    }
                    else
                    {
                        ScoreAll.Score = Scorebefor;
                        isTryToMax = true;
                    }                       
                    break;
                case "тп":
                    if (ScoreAll.damageBySword < ScoreAll.MaxmaxDamageBySword)
                    {
                        ScoreAll.damageBySword++;
                        ScoreAll.priceDamageBySword += 4;
                    }
                        
                    else
                    {
                        ScoreAll.Score = Scorebefor;
                        isTryToMax = true;
                    }
                    break;
                case "ящер":
                    if (ScoreAll.maxHearts < ScoreAll.Maxmaxheart)
                    {
                        ScoreAll.Health += 2;
                        ScoreAll.maxHearts++;
                        ScoreAll.priceOfHealth += 20;
                    }
                    else
                    {
                        ScoreAll.Score = Scorebefor;
                        isTryToMax = true;
                    }
                    break;
                case "карыч":
                    if (ScoreAll.timeOfStamina < ScoreAll.MaxmaxTimeStamina)
                    {
                        ScoreAll.timeOfStamina++;
                        ScoreAll.priceOfStamina += 10;
                    }
                    else
                    {
                        ScoreAll.Score = Scorebefor;
                        isTryToMax = true;
                    }
                    break;
                case "снуппи":
                    if (ScoreAll.damageByBow < ScoreAll.MaxmaxDamageByBow)
                    {
                        ScoreAll.damageByBow++;
                        ScoreAll.priceDamageByBow += 5;
                    }
                    else
                    {
                        ScoreAll.Score = Scorebefor;
                        isTryToMax = true;
                    }
                    break;
            }
            
            DisplayNextSentence();
            yes.SetActive(false);
            no.SetActive(false);
            resume.SetActive(true);
        }
        else
        {
            isTryToBreak = true;
            DisplayNextSentence();
            yes.SetActive(false);
            no.SetActive(false);
            resume.SetActive(true);
        }
    }
    public void ChoiseNo()
    {
        DisplayNextSentence();
        yes.SetActive(false);
        no.SetActive(false);
        resume.SetActive(true);
        
    }
}
