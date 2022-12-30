using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private string _description;
    [SerializeField] private int _basePrice;
    [SerializeField] private int _upgradeLimit = 6;

    private int _price = 0;

    public int UpgradeCount = 0;
    public Sprite Icon => _icon;
    public string Label => _label;
    public string Descrition => _description;
    public float UpgradeLimit => _upgradeLimit;
    public int Price
    {
        get
        {
            if (_price == 0)
                return _basePrice;

            return _price;
        }
        private set
        {
            Price = _price;
        }
    }

    public event Action<int> Upgraded;
    public event Action<int> UpgradePriceSkill;

    //private void Awake()
    //{
    //    Price = _basePrice;
    //}

    public void Upgrade()
    {
        if (UpgradeCount <= _upgradeLimit)
        {
            UpgradeCount++;
            Upgraded?.Invoke(UpgradeCount);
        }
    }

    public void UpgradePrice()
    {
        _price = _basePrice * (UpgradeCount + 1);
        Debug.Log(_price + "adf");
        UpgradePriceSkill?.Invoke(_price);
    }
}
