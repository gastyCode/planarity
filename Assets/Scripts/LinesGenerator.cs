using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using static Math2D;

/// <summary>
/// A class that is used to generate lines.
/// </summary>
public class LinesGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject linesCrossing;

    private GameObject _linesCrossing;

    /// <summary>
    /// This function takes an array of connections and creates a line between each connection in the array
    /// </summary>
    /// <param name="connections">An array of Vector2s that represent the connections between the vertexes.</param>
    public void CreateLines(Vector2[] connections)
    {
        DestroyAllLines();

        foreach (Vector2 connection in connections)
        {
            Line line = Instantiate(prefab).GetComponent<Line>();
            line.SetLine(connection);
        }

        _linesCrossing = Instantiate(linesCrossing);
    }

    /// <summary>
    /// It destroys the lines crossing object and all the lines in the scene
    /// </summary>
    private void DestroyAllLines()
    {
        Destroy(_linesCrossing);

        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");

        foreach (GameObject line in lines.ToList())
        {
            Destroy(line);
        }
    }
}