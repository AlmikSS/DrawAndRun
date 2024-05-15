using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Womp> _womps = new();

    public static Player Instance { get; private set; }

    private int _bonus;
    
    public bool CanDraw { get; private set; }

    private void Awake()
    {
        Instance = this;

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

    public void OnInputRectPointerDown() => CanDraw = true;

    public void OnInputRectPointerExit() => CanDraw = false;

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
    }
}