using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private PlayerMoney _wallet;

    private void OnEnable()
    {
        _wallet.CurrentMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _wallet.CurrentMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _textMoney.text = money.ToString();
    }
}
