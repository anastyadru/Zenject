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
	[Inject] private GameConfig _gameConfig;
	[Inject] private OpponentController.OpponentFabrik _opponentFabrik;
	[Inject] private PlayerController.PlayerFabrik _playerFabrik;

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
        GameObject.Instantiate(_finishPrefab, _gameConfig.FinishPos, Quaternion.identity);
    }

	private void CreateOpponents()
	{
		var opponent = _opponentFabrik.Create(Random.Range(_gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed), _gameConfig.FinishPos.y, this);
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