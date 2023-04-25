using Agava.YandexGames;
using Player.Skins;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _moneyLevels;
    [SerializeField] private int _currentMoney;
    [SerializeField] private SaveLoadMoney _saveLoadMoney;
    [SerializeField] private GameObject _advMoney;
    [SerializeField] private int _rewardRete;

    private int _currentMoneyLevel;
    
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> CurrentMoneyChanged;
    public event UnityAction<int> CurrentMoneyLevel;
    public int CurrentMoney => _currentMoney;

    private void Start()
    {
        _currentMoney = _saveLoadMoney.ReadMoney();
        CurrentMoneyChanged?.Invoke(_currentMoney);
        _currentMoneyLevel = _currentMoney;
        //AddMoney(3000);
    }

    public void IncreaseMoney(int value)
    {
        _moneyLevels += value;
        MoneyChanged?.Invoke(_moneyLevels);
    }

    public void IncreaseMoneyLevel(int value)
    {
        _currentMoneyLevel += value;
        CurrentMoneyLevel?.Invoke(_currentMoneyLevel);
    }

    public int SummMoney()
    {
        AddMoney(_moneyLevels);
        return CurrentMoney;
    }

    private void AddMoney(int value)
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

    public void BuySkins(ItemSkin itemSkin)
    {
        if (_currentMoney > 0)
        {
             _currentMoney -= itemSkin.Price;
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
