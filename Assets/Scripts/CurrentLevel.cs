using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a singleton class that holds the current level.
/// </summary>
public class CurrentLevel : MonoBehaviour
{
    public static CurrentLevel Instance { get; private set; }
    private PlanarGraph _planarGraph;
    
    /// <summary>
    /// If there is already an instance of this object, destroy this one. Otherwise, set the instance to this one
    /// </summary>
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetGraph(PlanarGraph planarGraph)
    {
        Instance._planarGraph = planarGraph;
    }

    public PlanarGraph GetGraph()
    {
        return _planarGraph;
    }

    public int GetLevel()
    {
        return _planarGraph.level;
    }
}
