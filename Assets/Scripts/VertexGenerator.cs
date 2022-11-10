using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class VertexGenerator : MonoBehaviour
{
    public GameObject prefab;
    public LineGenerator lineGenerator;
    public int vertexCount;
    
    // Start is called before the first frame update
    public void GenerateVertexes()
    {
        DestroyAllVertexes();
        
        Random random = new Random();
        
        for (int i = 0; i < vertexCount; i++)
        {
            Vector2 position = new Vector2(random.Next(-8, 8), random.Next(-3, 4));
            Instantiate(prefab,position, Quaternion.identity);
        }
        
        lineGenerator.CreateLines();
    }

    private void DestroyAllVertexes()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");

        if (vertexes.Length > 0)
        {
            foreach (GameObject vertex in vertexes.ToList())
            {
                Destroy(vertex);
            }
        }
    }
}
