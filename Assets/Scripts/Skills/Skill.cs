using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private string _description;
    [SerializeField] private int _price;
    [SerializeField] private int _upgradeLimit = 6;

    public int UpgradeCount = 0;
    public Sprite Icon => _icon;
    public string Label => _label;
    public string Descrition => _description;
    public int Price => _price;
    public float UpgradeLimit => _upgradeLimit;

    public event Action<int> Upgraded;

    public void Upgrade()
    {
        if (UpgradeCount <= _upgradeLimit)
        {
            UpgradeCount++;
            Upgraded?.Invoke(UpgradeCount);
        }
    }
}
