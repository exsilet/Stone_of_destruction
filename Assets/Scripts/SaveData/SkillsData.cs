using System;

[Serializable]
public class SkillsData
{
    public int Stars;
    public string NameSkill;
    public SkillsData(string nameSkill, int stars)
    {
        Stars = stars;
        NameSkill = nameSkill;
    }
}