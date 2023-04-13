using IJunior.TypedScenes;
using SaveData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ReturnMenu : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _balance;
        [SerializeField] private SaveLoadMoney _saveMoney;
        [SerializeField] private SaveLoadScore _saveScore;
        [SerializeField] private SaveLoadeLevels _saveLevels;
        [SerializeField] private WaveCounter _wave;

        private int sceneIndexLoad;

        public void LoadMenu()
        {
            _saveMoney.SummMoney(_balance.SummMoney());
            _saveScore.SumScore(_wave.GetScore);

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndexLoad = _saveLevels.ReadLevel();

            if (sceneIndex >= sceneIndexLoad)
            {
                _saveLevels.UnLockLevel(sceneIndex + 1);
            }

            Menu.Load();
        }

        public void FaildToMenu()
        {
            _saveMoney.SummMoney(_balance.SummMoney());
            Menu.Load();
        }
    }
}