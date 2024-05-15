using System.Collections.Generic;
using UnityEngine;

public class DrawingLines : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _constractionLayerMask;
    [SerializeField] private GameObject _point;
    [SerializeField] private LineRenderer _line;
    
    private List<Vector3> _positions = new();
    
    public bool EnableDraw { private get; set; } = true;
    public void UpdateLine()
    {
        if (Input.touchCount == 1 && EnableDraw)
        {
            _positions.Add(Input.GetTouch(0).position);
            _line.positionCount = _positions.Count;
            _line.SetPositions(_positions.ToArray());
        }
    }

    public void DestroyLine()
    {
        _line.positionCount = 0;
        _positions = new List<Vector3>();
        EnableDraw = false;
    }

    public void Constroction()
    {
        Debug.Log("constract");

        int index = 0;

        foreach (var womp in _player.Womps)
        {
            Ray ray = Camera.main.ScreenPointToRay(_positions[index]);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _constractionLayerMask))
            {
                if (_positions.Count > _player.Womps.Count)
                {
                    int a = _positions.Count / _player.Womps.Count;
                    Vector3 pos = new Vector3
                    {
                        x = hit.point.x,
                        y = womp.transform.position.y,
                        z = hit.point.z
                    };
                    // GameObject gm = Instantiate(_point, pos, Quaternion.identity, _player.transform);
                    // StartCoroutine(womp.Move(gm.transform));
                    womp.transform.position = pos;
                    index += a;
                }
                else
                {
                    Vector3 pos = new Vector3
                    {
                        x = hit.point.x,
                        y = womp.transform.position.y,
                        z = hit.point.z
                    };
                    // GameObject gm = Instantiate(_point, pos, Quaternion.identity, _player.transform);
                    // StartCoroutine(womp.Move(gm.transform));
                    womp.transform.position = pos;
                    index++;
                }
            }
        }
    }
}