using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyLevels;
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private TMP_Text _currentMoney;

    private int _amountMoney;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    public int SummMoney()
    {
        _amountMoney += int.Parse(_moneyLevels.text);
        _currentMoney.text = (float.Parse(_currentMoney.text) + _amountMoney).ToString();
        _player.AddMoney(_amountMoney);
        return _player.CurrentMoney;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyLevels.text = money.ToString();
    }
}
