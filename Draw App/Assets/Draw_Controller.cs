using System.Collections.Generic;
using UnityEngine;

public class Draw_Controller : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private EdgeCollider2D _edgeCollider;
    [SerializeField] private Camera _cam;


    private List<Vector3> _pointsForLine = new List<Vector3>();
    private List<Vector2> _pointsForEdge = new List<Vector2>();
    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            DrawLine();
        }    
    }

    private void DrawLine() {
        var _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            transform.position.z
        ));

        _mousePos.z = 0f;

        _pointsForEdge.Add(_mousePos);
        _pointsForLine.Add(_mousePos);

        _lineRenderer.positionCount = _pointsForLine.Count;
        _lineRenderer.SetPositions(_pointsForLine.ToArray());

        _edgeCollider.points = _pointsForEdge.ToArray();

    }
}
