using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Math2D;

public class LineCrossing : MonoBehaviour
{
    private int _intersections = 0;
    private List<Tuple<int, int>> _combinations;
    private List<Vector2> _positions;

    private void Start()
    {
        _combinations = new List<Tuple<int, int>>();
        _positions = new List<Vector2>();
        
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        _combinations = GetCombinationsOfTwo(lines.Length);
    }

    private void Update()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        _positions.Clear();

        foreach (Tuple<int, int> point in _combinations)
        {
            Line firstLine = lines[point.Item1].GetComponent<Line>();
            Line secondLine = lines[point.Item2].GetComponent<Line>();
            Vector2 position = new Vector2();


            bool intersection = IsLineIntersecting(firstLine.GetAPosition(), firstLine.GetBPosition(),
                secondLine.GetAPosition(), secondLine.GetBPosition(), out position);

            if (intersection)
            {
                _positions.Add(position);
            }
        }

        _intersections = _positions.Count;
        UIController.Instance.score = _intersections;
    }

    private void OnDrawGizmos()
    {
        foreach (Vector2 position in _positions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(position, 0.1f);
        }
    }
}
