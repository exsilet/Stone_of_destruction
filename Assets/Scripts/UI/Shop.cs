using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillPrefabs;
    //[SerializeField] private SkillView _skillViewPrefab;
    //[SerializeField] private GameObject _itemContainer;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SaveLoadSkills _saveLoadSkills;

    [SerializeField] private List<SkillView> _skillViewPrefab;

    private int currentCostOfGold;
    private List<SkillView> _skillViews = new List<SkillView>();
    private int _currentMoney;
    private bool _isStarted;

    private void Start()
    {
        for (int i = 0; i < _skillPrefabs.Count; i++)
        {
            //SkillView view = Instantiate(_skillViewPrefab, _itemContainer.transform);
            //_skillViews.Add(view);
            //view.Initialize(_skillPrefabs[i]);

            _skillViews.Add(_skillViewPrefab[i]);
            _skillViewPrefab[i].Initialize(_skillPrefabs[i]);
        }

        foreach (var skill in _skillPrefabs)
        {
            skill.UpgradeCount = _saveLoadSkills.ReadStarData(skill.Label);
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

    public void TrySellBuy(Skill skills, SkillView view)
    {
        currentCostOfGold = skills.Price;

        if (_currentMoney <= 0)
            return;

        if (currentCostOfGold <= _currentMoney)
        {
            _playerMoney.BuyUpgrade(skills);
            skills.Upgrade();
            skills.UpgradePrice();
            _saveLoadSkills.SaveStarData(skills.Label, skills.UpgradeCount);
        }
    }
}
