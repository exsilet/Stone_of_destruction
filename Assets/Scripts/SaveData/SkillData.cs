using System;

[Serializable]
public class SkillData
{
    public int Stars;
    public int Type;
    public SkillData(int type, int stars)
    {
        Stars = stars;
        Type = type;
    }
}