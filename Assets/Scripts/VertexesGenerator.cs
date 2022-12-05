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

    private PlanarGraph _planarGraph;
    private Vector2[] _positions;

    private void Start()
    {
        _planarGraph = CurrentLevel.Instance.GetGraph();
        _positions = _planarGraph.positions;
    }
    
    public void GenerateVertexes()
    {
        DestroyAllVertexes();
        
        Random random = new Random();

        foreach (Vector2 position in _positions)
        {
            Instantiate(prefab,position, Quaternion.identity);
        }

        linesGenerator.CreateLines(_planarGraph.connections);
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
