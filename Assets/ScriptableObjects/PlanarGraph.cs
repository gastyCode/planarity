using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlanarGraph : ScriptableObject
{
    public int level;
    public Vector2[] positions;
    public Vector2[] connections;
}
