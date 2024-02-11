using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove;
    
    [Inject] private TimeController _timeController;
    [Inject] private UnitPositionController _positionController;
    [Inject] private UIController _uiController;
    [Inject] private GameObject _finishPrefab;
	[Inject] private GameConfig _gameConfig;
	[Inject] private OpponentController.OpponentFabrik _opponentFabrik;
	[Inject] private PlayerController.PlayerFabrik _playerFabrik;
	[Inject] private PlayerWonSignal _playerWonSignal;
	[Inject] private OpponentWonSignal _opponentWonSignal;

	private GameObject 

    public void Start()
    {
        _uiController.HideGamePanel();
		_playerWonSignal.Listen(PlayerWonEvent);
		_opponentWonSignal.Listen(OpponentWonEvent);
    }

	public void PlayerWonEvent()
	{
		Debug.Log("Player won");
		_timeController.SetPauseOn();
		OnGameEnd();
	}

	public void OpponentWonEvent()
	{
		Debug.Log("Opponent won");
		_timeController.SetPauseOn();
		OnGameEnd();
	}

	private void OnGameEnd()
	{
		_uiController.ShowMenuPanel();
	}

	void OnApplicationQuit()
	{
		_playerWonSignal.UnListen(PlayerWonEvent);
		_opponentWonSignal.UnListen(OpponentWonEvent);
	}

    public void Play()
    {
        _uiController.HideMenuPanel();
        _uiController.ShowGamePanel();

        CreateFinish();

		CreatePlayers();
		CreateOpponents();

		_timeController.SetPauseOff();
    }

	private void CreateOpponents()
	{
		for (int i = 0; i < _gameConfig.OpponentsCount; i++)
		{
			var opponent = _opponentFabrik.Create(Random.Range(_gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed),
			_gameConfig.FinishPos.y, this);
			opponent.transform.position = _positionController.GetNewPos();
		}
	}

	private void CreatePlayers()
	{
		var player = _playerFabrik.Create(_gameConfig.PlayerSpeed, _gameConfig.FinishPos.y, this);
		player.transform.position = _positionController.GetNewPos();
	}
    
    private void CreateFinish()
    {
        GameObject.Instantiate(_finishPrefab, _gameConfig.FinishPos, Quaternion.identity);
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