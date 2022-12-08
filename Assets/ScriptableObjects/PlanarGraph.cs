using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It's a graph of points in 2D space, where each point is connected to other points
/// </summary>
[CreateAssetMenu]
public class PlanarGraph : ScriptableObject
{
    public int level;
    public Vector2[] positions;
    public Vector2[] connections;
}
