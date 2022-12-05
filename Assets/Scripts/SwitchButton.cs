using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
            denyVertexesMovement();
            ScoreSystem.SaveData(UIController.Instance);
            timer.Stop();
        }
    }

    private void denyVertexesMovement()
    {
        GameObject[] vertexes = GameObject.FindGameObjectsWithTag("Vertex");
        
        foreach (GameObject vertex in vertexes)
        {
            vertex.GetComponent<Vertex>().SetMovable(false);
        }
    }
}
