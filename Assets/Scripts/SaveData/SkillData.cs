using System;

[Serializable]
public class SkillData
{
    public int Stars;
    public string NameSkill;
    public SkillData(string nameSkill, int stars)
    {
        Stars = stars;
        NameSkill = nameSkill;
    }
}