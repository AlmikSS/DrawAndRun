using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Womp> _womps = new();
    [SerializeField] private GameObject _restartCanvas;
    
    public List<Womp> Womps => _womps;
    
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Womp womp))
                _womps.Add(womp);
        }
    }
    
    private void Start()
    {
        foreach (var womp in _womps)
        {
            womp.DeathEvent += OnWompDeth;
        }
    }

    private void OnWompDeth(Womp womp)
    {
        if (_womps.Contains(womp))
            _womps.Remove(womp);

        if (_womps.Count <= 0)
            GameOver();
    }
  
    private void GameOver()
    {
        GetComponent<SplineFollower>().enabled = false;
        _restartCanvas.SetActive(true);
    }
}