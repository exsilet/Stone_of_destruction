using UnityEngine;

public class EndLevels : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _player;
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        _panel.SetActive(false);
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
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
}
