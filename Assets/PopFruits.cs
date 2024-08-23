using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopFruits : MonoBehaviour
{
    private GameObject fruits;
    private int children;

    private Score score;

    public int bonus = 0;

    void Awake()
    {
        fruits = GameObject.Find("Fruits");
        score = GameObject.Find("ScoreText (TMP)").GetComponent<Score>();
    }

    private void OnEnable()
    {
        Pop();
    }

    public void Pop()
    {
        children = fruits.transform.childCount;
        do
        {
            Transform kid = fruits.transform.GetChild(children - 1);

            switch (kid.name)
            {
                case "01_Cherry(Clone)":
                    bonus += 1;
                    break;
                case "02_Strawberry(Clone)":
                    bonus += 2;
                    break;
                case "03_Grape2(Clone)":
                    bonus += 4;
                    break;
                case "04_Orange(Clone)":
                    bonus += 6;
                    break;
                case "05_Apple(Clone)":
                    bonus += 8;
                    break;
                case "06_Pear(Clone)":
                    bonus += 10;
                    break;
                case "07_Lemon(Clone)":
                    bonus += 12;
                    break;
                case "08_Peach(Clone)":
                    bonus += 14;
                    break;
                case "09_Pineapple(Clone)":
                    bonus += 16;
                    break;
                case "10_Coconut(Clone)":
                    bonus += 18;
                    break;
                case "11_Watermelon(Clone)":
                    bonus += 20;
                    break;
                default:
                    break;
            }
            
            Destroy(kid.gameObject);
            children--;

            score.score += bonus;

        } while (children > 0);
        StartCoroutine(WaitForPop());
    }

    IEnumerator WaitForPop()
    {
        yield return new WaitForSeconds(0.1f);
    }
}