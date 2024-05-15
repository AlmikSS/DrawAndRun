using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private ParticleSystem _winParticleSystem;
    [SerializeField] private GameObject _winUIPanel;
    
    public void Win()
    {
        _winParticleSystem.Play();
        _winUIPanel.SetActive(true);
    }
}