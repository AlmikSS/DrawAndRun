using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> pointsList;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        pointsList = new List<Vector3>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointsList.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
                lineRenderer.positionCount = pointsList.Count;
                lineRenderer.SetPosition(pointsList.Count - 1, mousePos);
            }
        }
    }
}