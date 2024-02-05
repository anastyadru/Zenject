using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    
    [Inject]
    private GameController _gameController;

    void OnValidate()
    {
        _menuPanel = transform.Find("pnl_MainMenu").gameObject;
        _gamePanel = transform.Find("pnl_GamePanel").gameObject;
    }

    public void ShowMenuPanel()
    {
        _menuPanel.SetActive(true);
    }
    public void HideMenuPanel()
    {
        _menuPanel.SetActive(false);
    }
    
    public void ShowGamePanel()
    {
        _gamePanel.SetActive(true);
    }
    public void HideGamePanel()
    {
        _gamePanel.SetActive(false);
    }

    public void OnExitBtnClicked()
    {
        _gameController.Exit();
    }
    public void OnPlayBtnClicked()
    {
        _gameController.Play();
    }
    public void OnRestartBtnClicked()
    {
        _gameController.Restart();
    }
}