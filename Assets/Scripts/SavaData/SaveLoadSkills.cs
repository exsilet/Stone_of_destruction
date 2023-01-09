using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSkills : MonoBehaviour
{
    private const string SkillsKey = "SkillsKey";

    private DataBase _dataBase;
    private bool _initialized;
    public bool Initialized => _initialized;

    private void Awake()
    {
        _dataBase = PlayerPrefs.HasKey(SkillsKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(SkillsKey))
            : new DataBase();

        _initialized = true;
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString(SkillsKey, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }

    public void SaveStarData(string nameSkill, int amountStar)
    {
        if (_dataBase.Read(nameSkill) < amountStar)
            _dataBase.Add(nameSkill, amountStar);

        Save();
    }

    public int ReadStarData(string nameSkill) => _dataBase.Read(nameSkill);

    [ContextMenu("Очистить PlayerPrefs")]
    private void ClearPlayerPrefs() => PlayerPrefs.DeleteAll();
}
