using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Image[] _emptyIcon;
    [SerializeField] private Sprite _fillIcon;
    [SerializeField] private Button _button;

    private Skill _skills;

    public void Initialize(Skill skills)
    {
        _skills = skills;
        _skills.Upgraded += OnSkillsUpgraded;
        ButtonLimitUpgrade();
    }

    private void OnSkillsUpgraded(int upgradeCount)
    {
        if (_skills.UpgradeCount <= _skills.UpgradeLimit)
        {
            int upgrade = upgradeCount - 1;
            _emptyIcon[upgrade].overrideSprite = _fillIcon;
        }

        ButtonLimitUpgrade();
    }

    private void ButtonLimitUpgrade()
    {
        if (_skills.UpgradeLimit == _skills.UpgradeCount)
            _button.interactable = !_button.interactable;
    }

    public void IconUpgrade(int upgradeCount)
    {
        for (int i = 0; i < upgradeCount; i++)
            _emptyIcon[i].overrideSprite = _fillIcon;
    }
}
