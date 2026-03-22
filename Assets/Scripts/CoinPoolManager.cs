using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }
    
    public GameObject coinPrefab;
    
    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        // Find all existing coins in the scene
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        coinStartPositions = new List<Vector3>();
        
        foreach (GameObject coin in existingCoins)
        {
            coinStartPositions.Add(coin.transform.position);
            Destroy(coin); // Remove scene-placed coins
        }
        
        // Create pool
        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);
        activeCoins = new List<GameObject>();
        
        // Spawn all coins from pool
        SpawnAllCoins();
    }
    
    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();
            coin.transform.position = position;
            activeCoins.Add(coin);
        }
    }
    
    public void ReturnCoin(GameObject coin)
    {
        coinPool.Return(coin);
        activeCoins.Remove(coin);
    }
    
    public void ResetAllCoins()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

