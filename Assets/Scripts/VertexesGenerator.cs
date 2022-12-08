using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// A class that generates vertexes.
/// </summary>
public class VertexesGenerator : MonoBehaviour
{
    public GameObject prefab;
    public LinesGenerator linesGenerator;

    private PlanarGraph _planarGraph;
    private Vector2[] _positions;

    /// <summary>
    /// > The `Start()` function gets the graph from the current level and stores it in a variable
    /// </summary>
    private void Start()
    {
        _planarGraph = CurrentLevel.Instance.GetGraph();
        _positions = _planarGraph.positions;
    }
    
    /// <summary>
    /// It destroys all the vertexes, then creates new ones at the positions specified in the PlanarGraph object
    /// </summary>
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

    /// <summary>
    /// It finds all the vertexes in the scene and destroys them
    /// </summary>
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
