using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;

    void OnValidate()
    {
        _menuPanel = transform.Find("pnl_MainMenu").gameObject;
        _gamePanel = transform.Find("pnl_GamePanel").gameObject;
    }
}