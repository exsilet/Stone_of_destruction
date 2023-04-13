using UnityEngine;

public class OpenPanelLevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private Transform _PanelLevelGame;

    private void Start()
    {
        _panelMenu.SetActive(true);
        _PanelLevelGame.gameObject.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        _panelMenu.SetActive(false);
    }
    
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        _panelMenu.SetActive(true);
    }
}
