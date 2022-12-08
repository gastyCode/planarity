using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A class that is used to switch the state of the button.
/// </summary>
public class SwitchButton : MonoBehaviour
{
    public Sprite unclicked;
    public Sprite clicked;

    public VertexesGenerator vertexesGenerator;
    public Timer timer;

    private Image _button;
    private bool _isClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _button.sprite = _isClicked ? clicked : unclicked;
    }

    /// <summary>
    /// It's a function that switches the button state between "clicked" and "unclicked"
    /// </summary>
    public void Switch()
    {
        _isClicked = !_isClicked;

        if (_isClicked)
        {
            vertexesGenerator.GenerateVertexes();
            timer.ResetTimer();
            timer.Run();
            UIController.Instance.moves = 0;
        }
        else
        {
            DenyVertexesMovement();
            ScoreSystem.SaveData(UIController.Instance);
            timer.Stop();
        }
    }

    /// <summary>
    /// It finds all the vertexes in the scene and sets their movable property to false
    /// </summary>
    private void DenyVertexesMovement()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");
        
        foreach (GameObject vertex in vertexes)
        {
            vertex.GetComponent<Vertex>().SetMovable(false);
        }
    }
}
