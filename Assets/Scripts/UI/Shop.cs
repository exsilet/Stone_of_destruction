using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillPrefabs;
    [SerializeField] private SkillView _skillViewPrefab;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Upgrade _buttonUpgrade;
    [SerializeField] private SaveLoadMoney _loadPlayerMoney;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SaveLoadSkills _saveLoadSkills;

    private int currentCostOfGold;
    private List<SkillView> _skillViews = new List<SkillView>();
    private int _currentMoney;

    private void Awake()
    {
        for (int i = 0; i < _skillPrefabs.Count; i++)
        {
            SkillView view = Instantiate(_skillViewPrefab, _itemContainer.transform);
            _skillViews.Add(view);
            view.Initialize(_skillPrefabs[i]);
        }
    }

    private void Start()
    {
        foreach (var skill in _skillPrefabs)
        {
            skill.UpgradeCount = _saveLoadSkills.ReadStarData(skill.Label);
        }
    }

    private void Update()
    {
        _currentMoney = _playerMoney.CurrentMoney;
    }

    private void OnEnable()
    {
        foreach (var view in _skillViews)
        {
            view.SellButtonClick += TrySellBuy;
            Debug.Log("покупка в подписке");
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
        Debug.Log("покупка");
        currentCostOfGold = skills.Price;

        if (_currentMoney > 0)
        {
            if (currentCostOfGold <= _currentMoney)
            {
                _playerMoney.BuyUpgrade(skills);
                skills.Upgrade();
                _saveLoadSkills.SaveStarData(skills.Label, skills.UpgradeCount);
            }
        }
    }
}
