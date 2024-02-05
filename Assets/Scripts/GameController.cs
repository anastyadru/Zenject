using UnityEditor;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove { get; set; }
    
    [Inject]
    private TimeController _timeController;

    public void Play()
    {
        // создать игрока и оппонентов
        // создать финиш
    }
    public void Restart()
    {
        
    }
    public void Exit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}