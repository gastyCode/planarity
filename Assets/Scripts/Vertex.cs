using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static LinesCrossing;

public class Vertex : MonoBehaviour
{
    private Vector3 _mousePositionOffset;
    private Vector3 _startPosition;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseDown()
    {
        UIController.Instance.moves++;
        
        _startPosition = gameObject.transform.position;
        _mousePositionOffset = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + _mousePositionOffset;
    }
}
