using System;
using System.Collections.Generic;
using System.Linq;
using SaveData;

[Serializable]
public class DataBase
{
    public int AllMoney;
    public int AllScore;
    public int CurrentLevelGameID = 2;
    public bool IsFirstStartGame = true;

    public List<SkillData> SkillsData = new();
    public List<SkinData> SkinsData = new ();

    public void AddBuySkin(string nameSkin, bool buySkin, bool selectSkin)
    {
        foreach (var data in SkinsData)
        {
            data.SelectedBuy = false;
            
            if (data.NameSkin == nameSkin)
            {
                data.IsBuySkin = buySkin;
                data.SelectedBuy = selectSkin;
                return;
            }
        }
        
        SkinsData.Add(new SkinData(nameSkin, buySkin, selectSkin));
    }

    public bool ReadSelectSkin(string nameSkin)
    {
        foreach (var data in SkinsData)
        {
            if (data.NameSkin == nameSkin)
            {
                return data.SelectedBuy;
            }
        }

        return false;
    }

    public bool ReadBuySkin(string nameSkin)
    {
        foreach (var data in SkinsData)
        {
            if (data.NameSkin == nameSkin)
            {
                return data.IsBuySkin;
            }
        }
        
        return false;
    }

    public void ChangeSelectedSkin(string nameSkin, bool selectSkin)
    {
        foreach (var data in SkinsData)
        {
            data.SelectedBuy = false;
        }

        foreach (var data in SkinsData.Where(data => data.NameSkin == nameSkin))
        {
            data.SelectedBuy = true;
        }
    }

    public void Add(int type, int stars)
    {
        foreach (var data in SkillsData.Where(data => data.Type == type))
        {
            data.Stars = stars;
            return;
        }

        SkillsData.Add(new SkillData(type, stars));
    }

    public int Read(int type)
    {
        foreach (var data in SkillsData)
        {
            if (data.Type == type)
            {
                return data.Stars;
            }
        }

        return 0;
    }
}