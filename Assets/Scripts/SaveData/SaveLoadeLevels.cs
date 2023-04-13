using UnityEngine;

namespace SaveData
{
    public class SaveLoadeLevels : MonoBehaviour
    {
        private const string ScoreKey = "LevelsKey";
        private DataBase dataBase;
        
        public void UnLockLevel(int levelID)
        {
            dataBase.CurrentLevelGameID = levelID;
        }
        
        public int ReadLevel()
        {
            return dataBase.CurrentLevelGameID;
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
}