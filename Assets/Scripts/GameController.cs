using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove { get; set; }
    
    [Inject] private TimeController _timeController;
    [Inject] private UnitPositionController _positionController;
    [Inject] private UIController _uiController;
    [Inject] private GameObject _finishPrefab;

    public void Start()
    {
        _uiController.HideGamePanel();
    }

    public void Play()
    {
        _uiController.HideMenuPanel();
        _uiController.ShowGamePanel();
        createFinish();
    }
    
    private void CreateFinish()
    {
        GameObject.Instantiate(_finishPrefab);
    }
    
    public void Restart()
    {
        _uiController.ShowMenuPanel();
        _ uiController.HideGamePanel();
    }
    
    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}