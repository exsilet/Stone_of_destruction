using UnityEngine;

public class SaveLoadScore : MonoBehaviour
{
    private const string ScoreKey = "ScoreKey";

    private DataBase dataBase;

    public void SumScore(int score)
    {
        dataBase.AllScore += score;
    }

    public int ReadScore()
    {
        return dataBase.AllScore;
    }
    
    private void OnEnable()
    {
        dataBase = PlayerPrefs.HasKey(ScoreKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(ScoreKey))
            : new DataBase();
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetString(ScoreKey, JsonUtility.ToJson(dataBase));
        PlayerPrefs.Save();
    }
}
