using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _moneyLevels;
    [SerializeField] private int _currentMoney;
    [SerializeField] private SaveLoadMoney _saveLoadMoney;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> CurrentMoneyChanged;
    public int CurrentMoney => _currentMoney;

    private void Start()
    {
        _currentMoney = _saveLoadMoney.ReadMoney();
        CurrentMoneyChanged?.Invoke(_currentMoney);
    }

    public void IncreaseMoney(int value)
    {
        _moneyLevels += value;
        MoneyChanged?.Invoke(_moneyLevels);
    }

    public void ResetPlayer()
    {
        _moneyLevels = 0;
        MoneyChanged?.Invoke(_moneyLevels);
    }

    public void FactorMoney(int factor)
    {
        _moneyLevels *= factor;
        MoneyChanged?.Invoke(_moneyLevels);
    }

    public void AddMoney(int value)
    {
        _currentMoney += value;
    }

    public void BuyUpgrade(Skill skills)
    {
        Debug.Log("покупка обновления");
        if (_currentMoney > 0)
        {
            _currentMoney -= skills.Price;
            CurrentMoneyChanged?.Invoke(_currentMoney);
            _saveLoadMoney.SummMoney(_currentMoney);
        }
    }
}
