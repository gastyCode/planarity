using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static LinesCrossing;

/// <summary>
/// A class that is used to create a vertex object.
/// </summary>
public class Vertex : MonoBehaviour
{
    private Vector3 _mousePositionOffset;
    private Vector3 _startPosition;
    private Boolean _isMovable = true;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    /// <summary>
    /// When the mouse is clicked on the game object, if the game object is movable, then the game object's start position
    /// is set to the game object's current position, and the mouse position offset is set to the game object's current
    /// position minus the mouse position
    /// </summary>
    private void OnMouseDown()
    {
        if (_isMovable)
        {
            UIController.Instance.moves++;
        
            _startPosition = gameObject.transform.position;
            _mousePositionOffset = gameObject.transform.position - GetMousePosition();
        }
    }

    /// <summary>
    /// If the object is movable, then move the object to the mouse position plus the mouse position offset
    /// </summary>
    private void OnMouseDrag()
    {
        if (_isMovable)
        {
            transform.position = GetMousePosition() + _mousePositionOffset;
        }
    }

    public void SetMovable(bool isMovable)
    {
        _isMovable = isMovable;
    }
}
