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

    private Skill _skills;

    public TMP_Text Price => _price;

    public event UnityAction<Skill, SkillView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClick);
    }

    public void Initialize(Skill skills)
    {
        _skills = skills;

        _label.text = skills.Label;
        _description.text = skills.Descrition;
        _icon.sprite = skills.Icon;
        _price.text = skills.Price.ToString();
        _upgrade.Initialize(skills);
        _skills.UpgradeCount = 0;
    }

    public void OnClick()
    {
        Debug.Log("Onclic");
        SellButtonClick?.Invoke(_skills, this);
    }
}
