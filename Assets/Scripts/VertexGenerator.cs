using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

public class VertexGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int vertexCount;
    
    // Start is called before the first frame update
    void Awake()
    {
        Random random = new Random();
        
        for (int i = 0; i < vertexCount; i++)
        {
            Vector2 position = new Vector2(random.Next(-8, 5), random.Next(-3, 3));
            Instantiate(prefab,position, Quaternion.identity);
        }
    }
}
