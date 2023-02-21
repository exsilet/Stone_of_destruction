using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkinPlayer : MonoBehaviour
{
    [SerializeField] private Transform _panelMenu;
    [SerializeField] private Transform _panelStart;
    [SerializeField] private Transform _panelSkin;

    private void Start()
    {
        _panelStart.gameObject.SetActive(true);
        _panelMenu.gameObject.SetActive(true);
        _panelSkin.gameObject.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        _panelMenu.gameObject.SetActive(false);
        _panelStart.gameObject.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        _panelMenu.gameObject.SetActive(true);
        _panelStart.gameObject.SetActive(true);
    }
}
