using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static LineCrossing;

public class Vertex : MonoBehaviour
{
    public Color baseColor;
    public Color collisionColor;
    
    private Vector3 _mousePositionOffset;
    private Vector3 _startPosition;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseDown()
    {
        _startPosition = gameObject.transform.position;
        
        _mousePositionOffset = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + _mousePositionOffset;
    }
}
