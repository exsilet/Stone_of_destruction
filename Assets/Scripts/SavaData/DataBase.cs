using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataBase
{ 
    public int AllMoney;
    public List<SkillsData> SkillsDatas = new List<SkillsData>();

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
