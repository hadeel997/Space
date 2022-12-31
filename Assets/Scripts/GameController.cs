using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    private float sliderCurrentFillAmount= 1f;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [Header("Game over Components")]
    [SerializeField] private GameObject gameOverScreen;
    [Header("High Score Components")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;
    
    
    private int playerscore;
    public enum GameState
    {
        waiting,
        Playing,
        GameOver
    }

    public static GameState currentGameStatus;
    private void Awake()
    {
        currentGameStatus = GameState.waiting;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text=PlayerPrefs.GetInt("HightScore").ToString();
        }

    }
    private void Update()
    {
       if (currentGameStatus== GameState.Playing)
        AdjustTimer();
    }

    private void AdjustTimer()
    {
       
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);
        sliderCurrentFillAmount = timerImage.fillAmount;

        if (sliderCurrentFillAmount <= 0f)
        {
            GameOver();
        }
    }
 
    public void UpdatePlayerScore(int astroidHitPoints)
    {
        if (currentGameStatus != GameState.Playing)
            return;
        playerscore+=astroidHitPoints;
        scoreText.text= playerscore.ToString();
    }
    public void StartGame()
    {
       currentGameStatus= GameState.Playing;
    }
    private void GameOver()
    {
        currentGameStatus= GameState.GameOver;
        gameOverScreen.SetActive(true);

        if (playerscore>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerscore);
            highScoreText.text = playerscore.ToString();
        }
    }

    public void RestGame()
    {
        currentGameStatus=GameState.waiting;
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;
        playerscore=0;
        scoreText.text = "0";
    }
    
}
