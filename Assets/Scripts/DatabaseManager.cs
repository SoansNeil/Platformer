using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;
using System.IO;

public class HighScore
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public float CompletionTime { get; set; }
}

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }
    
    private string dbPath;
    private SQLiteConnection dbConnection;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        SetDatabasePath();
        InitializeDatabase();
    }
    
    void SetDatabasePath()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "gamedata.db");
    }
    
    void InitializeDatabase()
    {
        SQLitePCL.Batteries_V2.Init();
        dbConnection = new SQLiteConnection(dbPath);
        CreateHighScoresTable();
    }
    
    void CreateHighScoresTable()
    {
        dbConnection.CreateTable<HighScore>();
        Debug.Log("High Scores table created at: " + dbPath);
    }
    public void SaveHighScore(string playerName, int score, float completionTime)
{
   Debug.Log($"Attempting to save: {playerName}, {score}, {completionTime}");
    try
    {
        HighScore newScore = new HighScore
        {
            PlayerName = playerName,
            Score = score,
            CompletionTime = completionTime
        };

        dbConnection.Insert(newScore);
        Debug.Log("High score saved: " + playerName + " - " + score);
    }
    catch (System.Exception e)
    {
        Debug.LogError("SaveHighScore failed: " + e.Message);
    }
}
public List<HighScore> GetTopHighScores(int count)
{
    List<HighScore> topScores = dbConnection.Table<HighScore>()
        .OrderByDescending(score => score.Score)
        .Take(count)
        .ToList();
    
    return topScores;
}
}