using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void OnEnable()
    {
        GameManager.Instance.onScoreChanged += UpdateScore;
        GameManager.Instance.onHealthChanged += UpdateHealth;
        GameManager.Instance.onGameOver += HandleGameOver;
    }
    void OnDisable()
    {
        GameManager.Instance.onScoreChanged -= UpdateScore;
        GameManager.Instance.onHealthChanged -= UpdateHealth;
        GameManager.Instance.onGameOver -= HandleGameOver;
    }
    void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
        Debug.Log("Score: " + newScore);
    }
    void UpdateHealth(int newHealth)
    { 
        healthText.text = "Health: " + newHealth;
        Debug.Log("Health: " + newHealth);
    } 
    void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
