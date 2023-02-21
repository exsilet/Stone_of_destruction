using Agava.YandexGames;
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
    [SerializeField] private GameObject _advMoney;
    [SerializeField] private int _rewardRete;

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
        if (_currentMoney > 0)
        {
            _currentMoney -= skills.Price;
            CurrentMoneyChanged?.Invoke(_currentMoney);
            _saveLoadMoney.SummMoney(_currentMoney);
        }
    }

    public void AddAdMoney()
    {
        VideoAd.Show(null, ADVMoney);
    }

    private void ADVMoney()
    {
        _moneyLevels *= _rewardRete;
        MoneyChanged?.Invoke(_moneyLevels);
        _advMoney.SetActive(false);
    }
}
