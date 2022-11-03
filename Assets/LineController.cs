using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static Math2D;

public class LineController : MonoBehaviour
{
    public GameObject prefab;
    public GameObject lineCrossing;

    private void Start()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");
        List<Tuple<int, int>> points = GetCombinationsOfTwo(vertexes.Length);

        foreach (Tuple<int, int> point in points)
        {
            Line line = Instantiate(prefab).GetComponent<Line>();
            line.SetLine(point.Item1, point.Item2);
        }

        Instantiate(lineCrossing);
    }
}
