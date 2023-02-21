using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RastTransleter : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;

    private void Start()
    {
        TranslationText();
    }

    public void TranslationText()
    {
        Debug.Log("cozdanie");

        switch (_label.text)
        {
            case "Speed":
                _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Speed");
                _description.text = Lean.Localization.LeanLocalization.GetTranslationText("SpeedDescription");
                break;
            case "Magnet":
                _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Magnet");
                _description.text = Lean.Localization.LeanLocalization.GetTranslationText("MagnetDescription");
                break;
            case "Money":
                _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Magnet");
                _description.text = Lean.Localization.LeanLocalization.GetTranslationText("MagnetDescription");
                break;
            case "Size":
                _label.text = Lean.Localization.LeanLocalization.GetTranslationText("Size");
                _description.text = Lean.Localization.LeanLocalization.GetTranslationText("SizeDescription");
                break;
        }

        //Lean.Localization.LeanLocalization.GetTranslationText("Size");
        //Lean.Localization.LeanLocalization.GetTranslationText("SizeDescription");
        //Lean.Localization.LeanLocalization.GetTranslationText("Magnet");
        //Lean.Localization.LeanLocalization.GetTranslationText("MagnetDescription");
        //Lean.Localization.LeanLocalization.GetTranslationText("Money");
        //Lean.Localization.LeanLocalization.GetTranslationText("MoneyDescription");
    }
}
