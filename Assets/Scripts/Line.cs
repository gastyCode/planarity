using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that is used to create a line between two points.
/// </summary>
public class Line : MonoBehaviour
{
    private LineRenderer _lr;
    private int _vertexA;
    private int _vertexB;
    private Vector2 _vertexAPosition;
    private Vector2 _vertexBPosition;
    
    /// <summary>
    /// We get the LineRenderer component and set the vertex positions to zero
    /// </summary>
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        
        _vertexAPosition = Vector2.zero;
        _vertexBPosition = Vector2.zero;
    }

    /// <summary>
    /// Find all the vertexes in the scene, then set the line renderer's positions to the actual positions of
    /// the vertexes every update cycle.
    /// </summary>
    private void Update()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");

        _vertexAPosition = vertexes[_vertexA].transform.position;
        _vertexBPosition = vertexes[_vertexB].transform.position;

        _lr.SetPosition(0, _vertexAPosition);
        _lr.SetPosition(1, _vertexBPosition);
    }

    public void SetLine(Vector2 connection)
    {
        _vertexA = (int)connection.x - 1;
        _vertexB = (int)connection.y - 1;
    }

    public Vector2 GetAPosition()
    {
        return _vertexAPosition;
    }
    
    public Vector2 GetBPosition()
    {
        return _vertexBPosition;
    }
}
