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
            case "����� ����":
                
                //workSpace = ScoreAll.maxScoreOfArrow;
                price = ScoreAll.priceOfArrowMax;
                textForNC = $"������ ��������� ���������� ����������� ������� �����?\n��� ����� ������ {price} ��������";
                break;
            case "��":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceDamageBySword;
                textForNC = $"������ ��������� ��������� ����?\n��� ����� ������ {price} ��������";
                break;
            case "����":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceOfHealth;
                textForNC = $"������ ��������� ���������� �����������? \n��� ����� ������ {price} ��������, ������ ������ �����������";
                break;
            case "�����":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceOfStamina;
                textForNC = $"��� ���, ������ ������ ��� �����?\n ������ ���� �������\n��� ����� ������ {price} ��������";
                break;
            case "������":
                //workSpace = ScoreAll.damageBySword;
                price = ScoreAll.priceDamageByBow;
                textForNC = $"���, ���, ������ �������� � ����, ��� � ���� �����-�����?\n ������ ���1 ���� ��  �����\n��� ����� ������ {price} ��������";
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
            sentence = $"������ ���� ��������? ����������!";
            isTryToBreak = false;           
        }
        else if (isTryToMax)
        {
            sentence = $"�� �� ��������� ����� ���� � ���� ����������! ��� ����������!";
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
                case "����� ����":
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
                case "��":
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
                case "����":
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
                case "�����":
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
                case "������":
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
