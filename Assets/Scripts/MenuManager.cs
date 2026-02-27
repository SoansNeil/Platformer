using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void loadGame()
    {
        PlayerPrefs.SetInt("Score",0);
        SceneManager.LoadScene("GameScene");
    }
}
