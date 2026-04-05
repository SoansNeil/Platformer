using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TMP_InputField playerNameInput;

    void Start()
    {
    int finalScore = GameManager.Instance.GetScore();
    
    finalScoreText.text = "Final Score: " + finalScore.ToString();
    }
    public void Retry()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void loadScore()
    {
        SceneManager.LoadScene("HighScores");
    }
    public void OnSubmitScore()
    {
        string player = playerNameInput.text;
        
        if (string.IsNullOrEmpty(player))
        {
            player = "Anonymous";
        }
        int finalScore = GameManager.Instance.score;
        float completionTime = GameManager.Instance.completionTime;
        
        DatabaseManager.Instance.SaveHighScore(player, finalScore, completionTime);
    }
}