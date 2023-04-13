using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyLevels;
    [SerializeField] private TMP_Text _moneyGameOver;
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private TMP_Text _currentAllMoney;

    private void OnEnable()
    {
        _player.MoneyChanged += OnMoneyChanged;
        _player.CurrentMoneyLevel += OnMoneyChangedLevel;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
        _player.CurrentMoneyLevel -= OnMoneyChangedLevel;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyLevels.text = money.ToString();
        _moneyGameOver.text = money.ToString();
    }

    private void OnMoneyChangedLevel(int money)
    {
        _currentAllMoney.text = money.ToString();
    }
}
