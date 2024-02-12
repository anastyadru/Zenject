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

	public GameObject Player;
	public GameObject[] Opponents;

	private void Start()
    {
        _uiController.HideGamePanel();
		_playerWonSignal.Listen(PlayerWonEvent);
		_opponentWonSignal.Listen(OpponentWonEvent);
    }

	private void PlayerWonEvent()
	{
		Debug.Log("Player won");
		_timeController.SetPauseOn();
		OnGameEnd();
	}

	private void OpponentWonEvent()
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

		_positionController.Reset();
		CreatePlayers();
		CreateOpponents();

		_timeController.SetPauseOff();
    }

	private void CreateOpponents()
	{
		if (_opponents == null)
		{
			_opponents = new GameObject[_gameConfig.OpponentsCount];
			for (int i = 0; i < _gameConfig.OpponentsCount; i++)
			{
				_opponents[i] = _opponentFabrik.Create(Random.Range(_gameConfig.OpponentMinSpeed, _gameConfig.OpponentMaxSpeed),
				_gameConfig.FinishPos.y, this).gameObject;
			}
		}

		for (int i = 0; i < _gameConfig.OpponentsCount; i++)
		{
			_opponent[i].transform.position = _positionController.GetNewPos();
		}

	}

	private void CreatePlayers()
	{
		if (_player == null)
		{
			_player = _playerFabrik.Create(_gameConfig.PlayerSpeed, _gameConfig.FinishPos.y, this).gameObject;
		}
		_player.transform.position = _positionController.GetNewPos();
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