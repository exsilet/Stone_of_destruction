using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    //[SerializeField] private GameObject _panel;

    //private void Start()
    //{
    //    Time.timeScale = 0;
    //    _panel.SetActive(true);
    //}

    //public void StartLevels()
    //{
    //    Time.timeScale = 1;
    //    _panel.SetActive(false);
    //}

    public void StartLevels()
    {
        GameScene.Load();
    }
}
