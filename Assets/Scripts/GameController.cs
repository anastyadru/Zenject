using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool CanMove { get; set; }

    public void Play()
    {
        
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