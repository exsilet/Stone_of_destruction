using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _panelShop;
    [SerializeField] private GameObject _panelUpgrade;
    [SerializeField] private Transform _langues;
    [SerializeField] private Transform _commonPanel;

    private void Start()
    {
        _panelShop.SetActive(false);
        _panelMenu.SetActive(true);
        _panelUpgrade.SetActive(true);
        _commonPanel.gameObject.SetActive(true);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        _panelMenu.SetActive(false);
        _panelUpgrade.SetActive(false);
        _langues.gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        _panelMenu.SetActive(true);
        _panelUpgrade.SetActive(true);
        _langues.gameObject.SetActive(true);
    }
}
