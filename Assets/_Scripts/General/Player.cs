using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Womp> _womps = new();
    
    private int _bonus;

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
            womp.GetBonusEvent += OnBonusGet;
        }
    }

    private void OnBonusGet()
    {
        _bonus++;
        Debug.Log(_bonus);
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
        Debug.Log("Ты есть лох");
        GetComponent<SplineFollower>().enabled = false;
    }
}