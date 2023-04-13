using UnityEngine;

namespace SaveData
{
    public class SaveAndLoadSkinSkills : MonoBehaviour
    {
        private const string SkinsAndSkillKey = "SkinsAndSkillKey";

        private DataBase dataBase;
        private bool _initialized;
        public bool Initialized => _initialized;

        private void OnEnable()
        {
            dataBase = PlayerPrefs.HasKey(SkinsAndSkillKey)
                ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(SkinsAndSkillKey))
                : new DataBase();
        
            _initialized = true;
        }

        private void OnDisable()
        {
            Save();
        }

        public void SaveStarData(string nameSkill, int amountStar)
        {
            if (dataBase.Read(nameSkill) < amountStar)
                dataBase.Add(nameSkill, amountStar);

            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetString(SkinsAndSkillKey, JsonUtility.ToJson(dataBase));
            PlayerPrefs.Save();
        }

        public int ReadStarData(string nameSkill) => dataBase.Read(nameSkill);

        public void SaveBuyData(string nameSkin, bool buySkin, bool selectSkin)
        {
            switch (dataBase.ReadSelectSkin(nameSkin))
            {
                case false:
                    dataBase.AddBuySkin(nameSkin, buySkin, selectSkin);
                    break;
                case true:
                    dataBase.ChangeSelectedSkin(nameSkin, selectSkin);
                    break;
            }

            Save();
        }

        public void ChangeSelectedSkin(string itemName)
        {
            dataBase.ChangeSelectedSkin(itemName, true);
        }

        public bool ReadSelect(string nameSkin) => dataBase.ReadSelectSkin(nameSkin);
        public bool ReadBuy(string nameSkin) => dataBase.ReadBuySkin(nameSkin);

        public void SaveFirstStarLevel(bool saveFirstStar)
        {
            dataBase.IsFirstStartGame = saveFirstStar;
            
            Save();
        }
        public bool FirstStarLevel() => dataBase.IsFirstStartGame;
    }
}
