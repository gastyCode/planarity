using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Math2D;

/// <summary>
/// A class that scans intersections of the lines.
/// </summary>
public class LinesCrossing : MonoBehaviour
{
    private int _intersections = 0;
    private List<Tuple<int, int>> _combinations;
    private List<Vector2> _positions;

    private void Start()
    {
        StartCoroutine(LateStart(0.1f));
    }

    /// <summary>
    /// For each combination of lines, check if they intersect and if they do, add the intersection point to a list.
    /// Then count intersection points and send it to the UIController.
    /// </summary>
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

    /// <summary>
    /// "For each position in the list of positions, draw a red sphere at that position."
    /// 
    /// Now, if you run the game, you'll see a bunch of red spheres in the scene view
    /// </summary>
    private void OnDrawGizmos()
    {
        foreach (Vector2 position in _positions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(position, 0.1f);
        }
    }

    /// <summary>
    /// It waits for a certain amount of time, then it creates a list of combinations of two lines, and a list of positions
    /// </summary>
    /// <param name="waitTime">The time to wait before starting the script.</param>
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _combinations = new List<Tuple<int, int>>();
        _positions = new List<Vector2>();
        
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        _combinations = GetCombinationsOfTwo(lines.Length);
    }
}
