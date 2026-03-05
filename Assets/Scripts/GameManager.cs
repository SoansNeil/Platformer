using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;
    public int score = 0;
    private int health = 100;
    private int finalScore;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(int points)
    {
        score += points;
        onScoreChanged?.Invoke(score);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChanged?.Invoke(health);
        if(health <= 0)
        {
            onGameOver?.Invoke();
        }
    }
    public void ResetGame()
    {
        score = 0;
        health = 100;
    }
}
