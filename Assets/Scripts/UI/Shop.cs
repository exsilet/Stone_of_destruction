using System.Collections.Generic;
using SaveData;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillPrefabs;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SaveAndLoadSkinSkills saveAndLoadSkinSkills;

    [SerializeField] private List<SkillView> _skillViewPrefab;

    private int currentCostOfGold;
    private List<SkillView> _skillViews = new List<SkillView>();
    private int _currentMoney;
    private bool _isStarted;

    private void Start()
    {
        for (int i = 0; i < _skillPrefabs.Count; i++)
        {
            _skillViews.Add(_skillViewPrefab[i]);
            _skillViewPrefab[i].Initialize(_skillPrefabs[i]);
        }

        foreach (var skill in _skillPrefabs)
        {
            skill.UpgradeCount = saveAndLoadSkinSkills.ReadStarData(skill.Label);
        }

        _isStarted = true;
        OnEnable();
    }

    private void Update()
    {
        _currentMoney = _playerMoney.CurrentMoney;
    }

    private void OnEnable()
    {
        if (_isStarted == false)
            return;

        foreach (var view in _skillViews)
        {
            view.SellButtonClick += TrySellBuy;
        }
    }

    private void OnDisable()
    {
        foreach (var view in _skillViews)
        {
            view.SellButtonClick -= TrySellBuy;
        }
    }

    private void TrySellBuy(Skill skills, SkillView view)
    {
        currentCostOfGold = skills.Price;

        if (_currentMoney <= 0)
            return;

        if (currentCostOfGold <= _currentMoney)
        {
            _playerMoney.BuyUpgrade(skills);
            skills.Upgrade();
            skills.UpgradePrice();
            saveAndLoadSkinSkills.SaveStarData(skills.Label, skills.UpgradeCount);
        }
    }
}
