using UnityEngine;

public class SaveLoadMoney : MonoBehaviour
{
    private const string CoinKey = "CoinKey";

    private DataBase dataBase;

    public void SummMoney(int money)
    {
        dataBase.AllMoney = money;
    }

    public int ReadMoney()
    {
        return dataBase.AllMoney;
    }

    private void OnEnable()
    {
        dataBase = PlayerPrefs.HasKey(CoinKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(CoinKey))
            : new DataBase();
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetString(CoinKey, JsonUtility.ToJson(dataBase));
        PlayerPrefs.Save();
    }
}
