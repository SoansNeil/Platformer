using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public event Action<int> onScoreChanged;
    public event Action<int> onHealthChanged;
    public event Action onGameOver;
    
    public int score = 0;
    public float completionTime { get; private set; }  // ← added
    
    private int health = 100;
    private bool timerRunning = false;  // ← added

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

    void Update()
    {
        if (timerRunning)
        {
            completionTime += Time.deltaTime;  // ← counts gameplay time
        }
    }

    public void StartGame()
    {
        timerRunning = true;  // ← call this when gameplay begins
    }

    public void AddScore(int points)
    {
        score += points;
        onScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChanged?.Invoke(health);
        if (health <= 0)
        {
            timerRunning = false;  // ← stop timer on game over
            onGameOver?.Invoke();
        }
    }

    public void ResetGame()
    {
        score = 0;
        health = 100;
        completionTime = 0f;  // ← reset timer
        timerRunning = false;
    }
}
