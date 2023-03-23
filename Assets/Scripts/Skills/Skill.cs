using Lean.Localization;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private LeanPhrase _phrase;
    [SerializeField] private LeanPhrase _phraseDescrition;
    [SerializeField] private int _basePrice;
    [SerializeField] private float _baseCoffecient;
    [SerializeField] private int _upgradeLimit = 6;
    [SerializeField] private SaveLoadSkills _saveLoadSkills;

    private int _price = 0;

    public int UpgradeCount = 0;
    public Sprite Icon => _icon;
    public string Label => LeanLocalization.GetTranslationText(_phrase.name);

    public string Descrition => LeanLocalization.GetTranslationText(_phraseDescrition.name);

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

    private void Start()
    {
        UpgradeCount = _saveLoadSkills.ReadStarData(Label);
        StartCoroutine(StartIncrese());
    }

    private IEnumerator StartIncrese()
    {
        yield return null;
        UpgradePrice();
    }    

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
        UpgradePriceSkill?.Invoke(_price);
    }

    public float CountLevelSkills()
    {
        return UpgradeCount > 0 ? _baseCoffecient * UpgradeCount : 0;
    }
}
