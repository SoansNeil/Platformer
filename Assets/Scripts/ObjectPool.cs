using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> availableObjects;
    
    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        availableObjects = new List<GameObject>();
        
        // Create initial pool
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Add(obj);
        }
    }
    
    public GameObject Get()
    {
        // Find an available object
        foreach (GameObject obj in availableObjects)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Reusing object from pool");
                obj.SetActive(true);
                return obj;
            }
        }
        
        // No available objects, create new one
        Debug.Log("Pool empty - instantiating new object");
        GameObject newObj = GameObject.Instantiate(prefab);
        availableObjects.Add(newObj);
        return newObj;
    }
    
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}