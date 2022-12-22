using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMoney : MonoBehaviour
{
    private const string CoinKey = "CoinKey";

    private DataBase _dataBase;

    private void OnEnable()
    {
        _dataBase = PlayerPrefs.HasKey(CoinKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(CoinKey))
            : new DataBase();
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString(CoinKey, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }

    public void SummMoney(int money)
    {
        _dataBase.AllMoney = money;
    }

    public int ReadMoney()
    {
        return _dataBase.AllMoney;
    }
}
