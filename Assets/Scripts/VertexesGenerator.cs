using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class VertexesGenerator : MonoBehaviour
{
    public GameObject prefab;
    public LinesGenerator linesGenerator;
    public int vertexesCount;
    
    // Start is called before the first frame update
    public void GenerateVertexes()
    {
        DestroyAllVertexes();
        
        Random random = new Random();
        
        for (int i = 0; i < vertexesCount; i++)
        {
            Vector2 position = new Vector2(random.Next(-8, 8), random.Next(-3, 4));
            Instantiate(prefab,position, Quaternion.identity);
        }
        
        linesGenerator.CreateLines();
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
