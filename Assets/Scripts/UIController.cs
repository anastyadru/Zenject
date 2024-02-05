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
        
    }
    public void OnPlayBtnClicked()
    {
        
    }
    public void OnRestartBtnClicked()
    {
        
    }
}