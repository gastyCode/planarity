using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _lr;
    private int _vertexA;
    private int _vertexB;
    private Vector2 _vertexAPosition;
    private Vector2 _vertexBPosition;

    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        
        _vertexAPosition = Vector2.zero;
        _vertexBPosition = Vector2.zero;
    }

    private void Update()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");

        _vertexAPosition = vertexes[_vertexA].transform.position;
        _vertexBPosition = vertexes[_vertexB].transform.position;

        _lr.SetPosition(0, _vertexAPosition);
        _lr.SetPosition(1, _vertexBPosition);
    }

    public void SetLine(int vertexA, int vertexB)
    {
        _vertexA = vertexA;
        _vertexB = vertexB;
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
