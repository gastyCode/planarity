using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public static CurrentLevel Instance { get; private set; }
    private PlanarGraph _planarGraph;
    
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
}
