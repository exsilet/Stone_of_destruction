using System;
using System.Collections.Generic;
using SaveData;

[Serializable]
public class DataBase
{ 
    public int AllMoney;
    public int AllScore;
    public List<LevelScore> ScoreLevel = new();

    public List<SkillsData> SkillsDatas = new();

    public void Add(string nameSkill, int stars)
    {
        foreach (var data in SkillsDatas)
        {
            if (data.NameSkill == nameSkill)
            {
                data.Stars = stars;
                return;
            }
        }

        SkillsDatas.Add(new SkillsData(nameSkill, stars));
    }

    public int Read(string nameSkill)
    {
        foreach (var data in SkillsDatas)
        {
            if (data.NameSkill == nameSkill)
            {
                return data.Stars;
            }
        }

        return 0;
    }
}
