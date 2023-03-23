using System;
using UnityEngine;

public class EndLevels : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _player;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Transform _gameOverPanel;
    [SerializeField] private GameObject _joystick;
    
    private bool _isFinished = false;

    private void Start()
    {
        _panel.SetActive(false);
        _joystick.SetActive(true);
    }

    private void OnEnable()
    {
        _player.EndLevels += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.EndLevels -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        if (_isFinished)
        {
            _panel.SetActive(true);
            _joystick.SetActive(false);
            Time.timeScale = 0;
        }
        if (!_isFinished)
        {
            _gameOverPanel.gameObject.SetActive(true);
            _joystick.SetActive(false);
            Time.timeScale = 0;
        }

    }

    public void SetCollision()
    {
        _isFinished = true;
    }
}
