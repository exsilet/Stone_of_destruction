using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Image[] _emptyIcon;
    [SerializeField] private Sprite _fillIcon;
    [SerializeField] private Button _button;

    private Skill _skills;

    //private void Start()
    //{
    //    IconUpgrade(_skills.UpgradeCount);
    //}

    public void Initialize(Skill skills)
    {
        _skills = skills;
        _skills.Upgraded += OnSkillsUpgaded;
    }

    private void OnSkillsUpgaded(int upgradeCount)
    {
        if (_skills.UpgradeCount <= _skills.UpgradeLimit)
        {
            int upgrade = upgradeCount - 1;
            _emptyIcon[upgrade].overrideSprite = _fillIcon;
        }

        if (_skills.UpgradeLimit == _skills.UpgradeCount)
        {
            _button.interactable = !_button.interactable;
        }
    }

    public void IconUpgrade(int upgradeCount)
    {
        for (int i = 0; i < upgradeCount; i++)
        {
            _emptyIcon[i].overrideSprite = _fillIcon;
        }
    }
}
