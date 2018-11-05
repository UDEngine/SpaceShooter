using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text scoreText;
    public Text restartText;
    public Text gameoverText;

    private int score;

	void Start ()
    {
        score = 0;
        UpdateScoreText();

        restartText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);
    }

    public void AddScore(int increaseSocre)
    {
        score += increaseSocre;
        UpdateScoreText();
    }

    public void ShowGameOverUI()
    {
        restartText.text = "Press 'R' To Restart!";
        gameoverText.text = "GAME OVER!";
        restartText.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score:" + score;
    }
}