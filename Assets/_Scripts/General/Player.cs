using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Womp> _womps = new();
    public Player Instance { get; private set; }

    private int _bonus = 0;
    
    private void Start()
    {
        Instance = this;
        
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
        Debug.Log("You lox");
    }
}