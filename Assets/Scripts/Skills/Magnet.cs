using UnityEngine;

public class Magnet : PassiveSkills
{
    [SerializeField] private string _product;
    [SerializeField] private Upgrade _upgrade;

    public string Product => _product;
    private int magnetUpgrade;

    public override void ToMyself()
    {
        magnetUpgrade = PlayerPrefs.GetInt(_product);
    }
}
