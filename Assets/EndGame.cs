using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private float stayCount = 0;     
    
    private bool gameover = false;

    public GameObject gameoverText;
    public TMP_Text recordText;

    private GameObject scoreText;
    private Score sco;

    private GameObject fruits;
    private PopFruits pop;

    private Color originalColor;
    private Color changeColor;
    private SpriteRenderer renderer;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText (TMP)");
        sco = scoreText.GetComponent<Score>();

        //fruits = GameObject.Find("Fruits");
        //pop = GetComponent<PopFruits>();

        renderer = GetComponent<SpriteRenderer>();
        originalColor = new Color(255f / 255f, 133f / 255f, 240f / 255f);
        changeColor = new Color(250f / 255f, 136f / 255f, 0f / 255f);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        renderer.color = Color.cyan;

        stayCount += Time.deltaTime;
        //Debug.Log("stayCount: " + stayCount + ", Stay: " + collider.name);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        renderer.color = originalColor;
        stayCount = 0;

        //Debug.Log("stayCount: " + stayCount + ", Exit: " + collider.name);
    }

    void Update()
    {
        if ( stayCount >= 3 )
        {
            End();
        }
        
        if( gameover )
        {
            Debug.Log("Game Over");
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void End()           
    {
        gameover = true;

        //pop.Pop();

        gameoverText.SetActive(true);

        //int score = sco.SetScore(pop.bonus);
        int score = sco.GetScore();

        float bestScore = PlayerPrefs.GetFloat("BestScore");     // 키 존재하지 않을시 기본값(0) 반환

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);     // 로컬에 파일로 값 저장(키-값)
        }

        recordText.text = "Best Record: " + (int)bestScore;

    }
}
