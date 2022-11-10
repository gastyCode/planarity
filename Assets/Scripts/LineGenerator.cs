using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using static Math2D;

public class LineGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject lineCrossing;

    private GameObject _lineCrossing;

    public void CreateLines()
    {
        DestroyAllLines();
        
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");
        List<Tuple<int, int>> points = GetCombinationsOfTwo(vertexes.Length);

        foreach (Tuple<int, int> point in points)
        {
            Line line = Instantiate(prefab).GetComponent<Line>();
            line.SetLine(point.Item1, point.Item2);
        }

        _lineCrossing = Instantiate(lineCrossing);
    }
    
    private void DestroyAllLines()
    {
        Destroy(_lineCrossing);
        
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");

        if (lines.Length > 0)
        {
            foreach (GameObject line in lines.ToList())
            {
                Destroy(line);
            }
        }
    }
}
