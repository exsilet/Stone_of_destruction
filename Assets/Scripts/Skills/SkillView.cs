using System.Collections;
using System.Collections.Generic;
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
        _skill.UpgradePriceSkill += RefrashPrice;
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClick);
        _skill.UpgradePriceSkill -= RefrashPrice;
    }

    private void RefrashPrice(int newPrice)
    {
        _price.text = newPrice.ToString();
    }

    public void Initialize(Skill skill)
    {
        _skill = skill;
        Debug.Log(_skill.Price);
        _label.text = skill.Label;
        _description.text = skill.Descrition;
        _icon.sprite = skill.Icon;
        _price.text = skill.Price.ToString();
        _upgrade.Initialize(skill);
        _skill.UpgradeCount = 0;

        _isInitialized = true;
        OnEnable();
    }

    public void OnClick()
    {
        Debug.Log("Onclic");
        SellButtonClick?.Invoke(_skill, this);
    }
}
