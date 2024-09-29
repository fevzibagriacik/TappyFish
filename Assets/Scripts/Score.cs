using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    public Text scoreText;
    public Text panelScoreText;
    public Text highScoreText;
    public GameObject New;
    void Start()
    {
        score = 0;

        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        highScoreText.text = highScore.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScoreText.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            New.SetActive(true);
        }
    }

    public int getScore()
    {
        return score;
    }
}
