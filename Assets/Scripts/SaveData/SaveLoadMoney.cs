using UnityEngine;

public class SaveLoadMoney : MonoBehaviour
{
    private const string CoinKey = "CoinKey";

    private DataBase _dataBase;

    public void SummMoney(int money)
    {
        _dataBase.AllMoney = money;
    }

    public int ReadMoney()
    {
        return _dataBase.AllMoney;
    }

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

    private void Save()
    {
        PlayerPrefs.SetString(CoinKey, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }
}
