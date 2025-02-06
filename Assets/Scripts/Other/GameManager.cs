using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private BallDataTransmitter ballDataTransmitter;
    public float score = 0.0f;

    public GameObject startMenuUI;
    public GameObject gameOverUI;
    public GameObject maxScoreUI;
    public TextMeshProUGUI maxScoreText;

    private void Start()
    {
        startMenuUI.SetActive(true);
        gameOverUI.SetActive(false);
        maxScoreText.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
    }

    public void AddScore()
    {
        score +=1.0f;
        //ballMovementController.ballSpeed += 0.01f;
        ballDataTransmitter.SetBallSpeed(0.01f);
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        maxScoreUI.SetActive(false);
        ballDataTransmitter.SetBallSpeed(2.0f);


        score = 0.0f;
        //ballMovementController.ballSpeed = 2.0f; 
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        maxScoreUI.SetActive(true);
        gameOverUI.SetActive(true);
        if (PlayerPrefs.GetInt("MaxScore",0)<score)
        {
            PlayerPrefs.SetInt("MaxScore", (int)score);
        }
        maxScoreText.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        startMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        maxScoreUI.SetActive(false);
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
