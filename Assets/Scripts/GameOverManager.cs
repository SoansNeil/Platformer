using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore",0);
        finalScoreText.text = "Final Score: " + finalScore;
    }
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}