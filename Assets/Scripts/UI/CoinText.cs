using System;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _template;
    [SerializeField] private Transform _camera;

    public void RaiseACoin(int coin)
    {
        _text.CrossFadeAlpha(1, 0.1f, false);
        
        _text.text = string.Format(_template, coin);
        
        _text.CrossFadeAlpha(0, 1.5f, false);
    }

    private void Update()
    {
        transform.LookAt(_camera);
    }
}
