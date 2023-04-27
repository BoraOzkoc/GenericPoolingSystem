using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private ObjectPoolController objectPoolController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           GameObject obj = objectPoolController.GetFromPool();
           obj.transform.position = objectPoolController.transform.position;
        }
    }
}
