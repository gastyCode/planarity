using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Math2D;

public class LineCrossing : MonoBehaviour
{
    private int _intersections = 0;
    private List<Tuple<int, int>> _combinations;
    public GameObject debug;
    public bool debugMode;

    private void Start()
    {
        _combinations = new List<Tuple<int, int>>();
        
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        _combinations = GetCombinationsOfTwo(lines.Length);
    }

    private void Update()
    {
        List<GameObject> debugCircles = new List<GameObject>();
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        Vector2 position = new Vector2();
        
        _intersections = 0;
        
        foreach (Tuple<int, int> point in _combinations)
        {
            Line firstLine = lines[point.Item1].GetComponent<Line>();
            Line secondLine = lines[point.Item2].GetComponent<Line>();

            
            bool intersection = IsLineIntersecting(firstLine.GetAPosition(), firstLine.GetBPosition(),
                secondLine.GetAPosition(), secondLine.GetBPosition(), out position);

            if (intersection)
            {
                debugCircles.Add(Instantiate(debug, position, Quaternion.identity));
                _intersections++;
            }
        }

        Debug.Log(_intersections / 2);
    }
}
