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
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        List<Vector2> intersections = new List<Vector2>();

        int crossings = 0;

        foreach (Tuple<int, int> point in _combinations)
        {
            Line firstLine = lines[point.Item1].GetComponent<Line>();
            Line secondLine = lines[point.Item2].GetComponent<Line>();
            Vector2 position = new Vector2();


            bool intersection = IsLineIntersecting(firstLine.GetAPosition(), firstLine.GetBPosition(),
                secondLine.GetAPosition(), secondLine.GetBPosition(), out position);

            if (intersection)
            {
                crossings++;
            }
        }
        
        _intersections = crossings;
        UIController.Instance.score = _intersections;
    }
}
