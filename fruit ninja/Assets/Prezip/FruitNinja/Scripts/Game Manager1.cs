using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button HomeButton;
    public bool gameIsOver;
    public float timeRemaining = 60;
    public bool timerIsRunning = true;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Main Game Mode")
        {
            lives = 3;
        }
        else
        {
            lives = 1;
        }

        score = 0;
        UpdateScoreDisplay();
        livesText.text = "Lives: " + lives;
        UpdateTimerDisplay();
    }

    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        UpdateScoreDisplay();
    }

 

    public void UpdateLives()
    {
        if(gameIsOver == false)
        {
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives <= 0)
            {
                GameOver();
            }
        }
    }
    void UpdateTimer()
    {
        if (timerIsRunning && !gameIsOver)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 10f)
        {
            timerText.color = Color.red;
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }
}

