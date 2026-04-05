using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void loadGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
    }
    public void loadScores()
    {
         SceneManager.LoadScene("HighScores");
    }
}
