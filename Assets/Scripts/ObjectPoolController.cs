using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    private Queue<GameObject> pooledObjectQueue;

    private void Awake()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        pooledObjectQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject spawnedObject = Instantiate(objectPrefab,transform);
            spawnedObject.SetActive(false);
            
            pooledObjectQueue.Enqueue(spawnedObject);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject spawnedObject = pooledObjectQueue.Dequeue();
        spawnedObject.SetActive(true);
        if (pooledObjectQueue.Count <= 1)
        {
            SpawnObjects();
        }
        
        
        return spawnedObject;
    }

    public void PushToPool(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjectQueue.Enqueue(obj);
    }
}
