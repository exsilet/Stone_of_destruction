using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Upgrade _upgrade;

    private Skill _skill;
    private bool _isInitialized;

    public event UnityAction<Skill, SkillView> SellButtonClick;

    private void OnEnable()
    {
        if (_isInitialized == false)
            return;

        _sellButton.onClick.AddListener(OnClick);
        _skill.UpgradePriceSkill += RefreshPrice;
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClick);
        _skill.UpgradePriceSkill -= RefreshPrice;
    }

    private void RefreshPrice(int newPrice)
    {
        _price.text = newPrice.ToString();
    }

    public void Initialize(Skill skill)
    {
        _skill = skill;
        _label.text = skill.Label;
        _description.text = skill.Description;
        _icon.sprite = skill.Icon;
        _price.text = skill.Price.ToString();
        _upgrade.Initialize(skill);
        _upgrade.IconUpgrade(skill.UpgradeCount);
        _skill.UpgradeCount = 0;

        _isInitialized = true;
        OnEnable();
    }

    private void OnClick()
    {
        SellButtonClick?.Invoke(_skill, this);
    }
}
