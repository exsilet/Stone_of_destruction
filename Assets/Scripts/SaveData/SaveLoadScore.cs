using UnityEngine;

public class SaveLoadScore : MonoBehaviour
{
    private const string ScoreKey = "ScoreKey";

    private DataBase _dataBase;

    public void SumScore(int score)
    {
        _dataBase.AllScore += score;
    }

    public int ReadScore()
    {
        return _dataBase.AllScore;
    }
    
    private void OnEnable()
    {
        _dataBase = PlayerPrefs.HasKey(ScoreKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(ScoreKey))
            : new DataBase();
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetString(ScoreKey, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }
}
