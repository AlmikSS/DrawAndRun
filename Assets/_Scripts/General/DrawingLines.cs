using System.Collections.Generic;
using UnityEngine;

public class DrawingLines : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    private List<Vector3> positions = new();
    public bool EnableDraw { private get; set; } = true;
    public void UpdateLine()
    {
        if (Input.touchCount == 1 && EnableDraw)
        {
            positions.Add(Input.GetTouch(0).position);
            _line.positionCount = positions.Count;
            _line.SetPositions(positions.ToArray());
        }
    }

    public void DestroyLine()
    {
        _line.positionCount = 0;
        positions = new List<Vector3>();
        EnableDraw = false;
    }
}
