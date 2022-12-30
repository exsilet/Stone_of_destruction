using UnityEngine;

public class Magnet : PassiveSkills
{
    [SerializeField] private string _product;
    [SerializeField] private Upgrade _upgrade;

    public string Product => _product;
    public int CountLevelSkill;

    public override void ToMyself()
    {

    }
}
