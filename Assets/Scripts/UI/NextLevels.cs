using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevels : MonoBehaviour
{
    [SerializeField] private MoneyBalance _balance;
    [SerializeField] private SaveLoadMoney _saveMoney;
    [SerializeField] private SaveLoadScore _saveScore;
    [SerializeField] private WaveCounter _wave;

    public void LoadScene(int sceneId)
    {
        _saveMoney.SummMoney(_balance.SummMoney());
        _saveScore.SumScore(_wave.GetScore);
        
        SceneManager.LoadScene(sceneId);
    }

    public void FaildToMenu(int sceneId)
    {
        _saveMoney.SummMoney(_balance.SummMoney());
        SceneManager.LoadScene(sceneId);
    }
}
