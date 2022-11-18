using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    public Sprite unclicked;
    public Sprite clicked;

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
    }
}
