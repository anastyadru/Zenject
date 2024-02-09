using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove { get; set; }
    
    [Inject] private TimeController _timeController;
    [Inject] private UnitPositionController _positionController;
    [Inject] private UIController _uiController;

    public void Start()
    {
        _uiController.HideGamePanel();
    }

    public void Play()
    {
        _uiController.HideMenuPanel();
        _uiController.ShowGamePanel();
    }
    public void Restart()
    {
        _uiController.ShowMenuPanel();
        _uiController.HideGamePanel();
    }
    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}