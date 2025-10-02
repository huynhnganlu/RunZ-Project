using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Dictionary<string, Queue<GameObject>> poolDictionary = new();

    public static ObjectPoolingManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Get Object From Pool if there is pool avaiable, if not create new pool then instance new object
    public GameObject GetObjectFromPool(GameObject gameObject, Vector3 pos, Quaternion ang)
    {
        if (!poolDictionary.ContainsKey(gameObject.name))
            poolDictionary[gameObject.name] = new Queue<GameObject>();

        Queue<GameObject> queue = poolDictionary[gameObject.name];

        if (queue.Count > 0)
        {
            GameObject obj = queue.Dequeue();
            obj.transform.position = pos;
            obj.transform.rotation = ang;
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(gameObject, pos, ang);
            obj.name = gameObject.name; // Ensure the name is consistent for pooling
            return obj;
        }
    }

    //Return Object to Pool
    public void ReturnObjectToPool(GameObject gameObject)
    {
        poolDictionary[gameObject.name].Enqueue(gameObject);
        gameObject.SetActive(false);

    }
}
