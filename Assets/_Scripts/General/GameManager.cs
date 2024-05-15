using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private ParticleSystem _winParticleSystem;
    [SerializeField] private GameObject _winUIPanel;
    [SerializeField] private GameObject _drawingLines;
    
    [Header("StartGame")]
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _startGameCanvas;
    
    public static GameManager Instance { get; private set; }
    public bool GameStarted { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        _winParticleSystem.Play();
        _winUIPanel.SetActive(true);
        _drawingLines.SetActive(false);
        GameStarted = false;
    }

    public void StartGame()
    {
        _player.GetComponent<SplineFollower>().enabled = true;
        _startGameCanvas.SetActive(false);
        GameStarted = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}