using Lean.Localization;
using System;
using System.Collections;
using SaveData;
using UnityEngine;
using UnityEngine.Events;

public class Skill : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private LeanPhrase _phrase;
    [SerializeField] private LeanPhrase _phraseDescription;
    [SerializeField] private int _basePrice;
    [SerializeField] private float _baseCoffecient;
    [SerializeField] private int _upgradeLimit = 6;
    [SerializeField] private SaveAndLoadSkinSkills saveAndLoadSkinSkills;

    private int _price = 0;

    public int UpgradeCount = 0;
    public Sprite Icon => _icon;
    public string Label => LeanLocalization.GetTranslationText(_phrase.name);

    public string Description => LeanLocalization.GetTranslationText(_phraseDescription.name);

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
        UpgradeCount = saveAndLoadSkinSkills.ReadStarData(Label);
        StartCoroutine(StartIncrease());
    }

    private IEnumerator StartIncrease()
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
        _price = (int)(_basePrice * ((UpgradeCount + 1)*1.5f));
        UpgradePriceSkill?.Invoke(_price);
    }

    public float CountLevelSkills()
    {
        return UpgradeCount > 0 ? _baseCoffecient * UpgradeCount : 0;
    }
}
