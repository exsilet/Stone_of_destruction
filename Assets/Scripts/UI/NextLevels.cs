using Agava.YandexGames;
using SaveData;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevels : MonoBehaviour
{
    [SerializeField] private PlayerMoney _balance;
    [SerializeField] private SaveLoadMoney _saveMoney;
    [SerializeField] private SaveLoadScore _saveScore;
    [SerializeField] private SaveLoadeLevels _saveLevels;
    [SerializeField] private WaveCounter _wave;

    private int sceneIndexLoad;

    public void NextLoadScene()
    {
        InterstitialAd.Show(null, OnCloseCallback, OnErrorCallback);
        //NextScene();
    }
    
    private void OnErrorCallback(string obj)
    {
        NextScene();
    }

    private void OnCloseCallback(bool obj)
    {
        NextScene();
    }

    private void NextScene()
    {
        _saveMoney.SummMoney(_balance.SummMoney());
        _saveScore.SumScore(_wave.GetScore);

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndexLoad = _saveLevels.ReadLevel();

        if (sceneIndex >= sceneIndexLoad)
        {
            _saveLevels.UnLockLevel(sceneIndex + 1);
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
}