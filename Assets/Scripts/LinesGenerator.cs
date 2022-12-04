using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using static Math2D;

public class LinesGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject linesCrossing;

    private GameObject _linesCrossing;

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