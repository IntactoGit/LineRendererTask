using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> _points = new List<Vector3>();
    private bool _isDrawing = false;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _points.Clear();
            _lineRenderer.positionCount = 0;
            _isDrawing = true;
        }

        if (Input.GetMouseButton(0) && _isDrawing) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (_points.Count == 0 || Vector3.Distance(_points[_points.Count - 1], mousePos) > 0.1f)
            {
                _points.Add(mousePos);
                _lineRenderer.positionCount = _points.Count;
                _lineRenderer.SetPositions(_points.ToArray());
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            _isDrawing = false;
        }
    }
}
