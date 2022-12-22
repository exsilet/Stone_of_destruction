using UnityEngine;
using IJunior.TypedScenes;
using TMPro;

public class NextLevels : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private TMP_Text _money;
    [SerializeField] private MoneyBalance _balance;
    [SerializeField] private SaveLoadMoney _saveMoney;

    public void LoadScene()
    {
        _saveMoney.SummMoney(_balance.SummMoney());
        Menu.Load();
    }
}
