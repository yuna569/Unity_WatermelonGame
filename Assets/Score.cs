using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    private int prevCount = 0;
    private int presCount = 0;

    private GameObject fruits;

    //public TMP_Text txt;
    private TMP_Text txt;

    void Awake()
    {
        score = 0;
        prevCount = 0;
        presCount = 0;

        fruits = GameObject.Find("Fruits");
        txt = GetComponent<TMP_Text>();
    }

    private void CheckInstance()
    {
        Transform instance = fruits.transform.GetChild(presCount - 1);
 
        switch (instance.name)
        {
            case "02_Strawberry(Clone)":
                score += 2;
                break;
            case "03_Grape2(Clone)":
                score += 4;
                break;
            case "04_Orange(Clone)":
                score += 6;
                break;
            case "05_Apple(Clone)":
                score += 8;
                break;
            case "06_Pear(Clone)":
                score += 10;
                break;
            case "07_Lemon(Clone)":
                score += 12;
                break;
            case "08_Peach(Clone)":
                score += 14;
                break;
            case "09_Pineapple(Clone)":
                score += 16;
                break;
            case "10_Coconut(Clone)":
                score += 18;
                break;
            case "11_Watermelon(Clone)":
                score += 20;
                break;
            default:
                break;
        }

    }

    void Update()
    {
        presCount = fruits.transform.childCount;

        if ( presCount < prevCount )
        {
            CheckInstance();
        }

        txt.text = "Score: " + score;

        prevCount = presCount;
    }

    public int SetScore(int bonus)
    {
        score += bonus;

        return score;
    }

    public int GetScore()
    {
        return score;
    }
    
}