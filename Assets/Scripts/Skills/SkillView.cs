using Lean.Localization;
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
        _label.text = skill.Label;
        _description.text = skill.Descrition;
        _icon.sprite = skill.Icon;
        _price.text = skill.Price.ToString();
        _upgrade.Initialize(skill);
        _label.text = LeanLocalization.GetTranslationText(_label.text);
        Debug.Log(skill.Label);
        _skill.UpgradeCount = 0;
        _label.gameObject.AddComponent<LeanLocalizedTextMeshProUGUI>();
        _description.gameObject.AddComponent<LeanLocalizedTextMeshProUGUI>();

        TranslationText();

        _isInitialized = true;
        OnEnable();
    }

    public void OnClick()
    {
        SellButtonClick?.Invoke(_skill, this);
    }

    public void TranslationText()
    {
        //LeanLocalization.GetTranslation(_label.text);
        Debug.Log(Lean.Localization.LeanLocalization.GetTranslationText(_label.text));
        //Debug.Log(LeanPhrase.DataType.Text.ToString());
        //Debug.Log(LeanLocalization.CurrentTokens.Count);
        //Debug.Log(LeanLocalization.CurrentTokens.Keys.ToString());
        //Debug.Log(LeanLocalization.CurrentTokens.Values.ToString());

        //foreach (var item in LeanLocalization.CurrentTokens)
        //{
        //    Debug.Log(item.Key + " " + item.Value);
        //    Debug.Log(item.Value.ToString());
        //}

        //switch (LeanLocalization.CurrentTokens.Keys.ToString())
        //{
        //    case "Speed":
        //        _label.text = LeanLocalization.CurrentTokens.Keys.ToString();
        //        _description.text = Lean.Localization.LeanLocalization.GetTranslationText("SpeedDescription");
        //        break;
        //    case "Magnet":
        //        _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Magnet");
        //        _description.text = Lean.Localization.LeanLocalization.GetTranslationText("MagnetDescription");
        //        break;
        //    case "Money":
        //        _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Magnet");
        //        _description.text = Lean.Localization.LeanLocalization.GetTranslationText("MagnetDescription");
        //        break;
        //    case "Size":
        //        _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Size");
        //        _description.text = Lean.Localization.LeanLocalization.GetTranslationText("SizeDescription");
        //        break;
        //}
    }
}
