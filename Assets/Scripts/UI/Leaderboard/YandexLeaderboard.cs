using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class YandexLeaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardElement[] _liderboars;
    [SerializeField] private Transform _langues;
    [SerializeField] private Transform _leaderBoard;
    [SerializeField] private Transform _listleaderBoard;
    [SerializeField] private Transform _notLogin;
    [SerializeField] private SaveLoadScore _score;
    [SerializeField] private Converter _converter;
    [SerializeField] private int _topPlayersCount = 3;
    [SerializeField] private int _competingPlayersCount = 5;

    private const string WavesLeader = "Leader";
    private const string Anonymous = "Anonymous";

    private void Start()
    {
        SetScore(_score.ReadScore());
    }

    public void Show()
    {
        _leaderBoard.gameObject.SetActive(true);
        _langues.gameObject.SetActive(false);

#if !UNITY_EDITOR

        if (PlayerAccount.IsAuthorized)
        {
            _listleaderBoard.gameObject.SetActive(true);
            _notLogin.gameObject.SetActive(false);

            PlayerAccount.RequestPersonalProfileDataPermission();

            Leaderboard.GetEntries(WavesLeader, (result) =>
            {
                for (int i = 0; i < result.entries.Length; i++)
                {
                    //if(result.entries[i] != null)

                    var entry = result.entries[i];

                    string name = entry.player.publicName;
                    if (string.IsNullOrEmpty(name))
                        name = Anonymous;

                    _liderboars[i].gameObject.SetActive(true);
                    _liderboars[i].Render(_converter.ToLeaderboardElemetData(entry.rank, entry.player.lang, name, entry.score));
                }
            }, null, _topPlayersCount, _competingPlayersCount);
        }
        else
        {
            _notLogin.gameObject.SetActive(true);
            _listleaderBoard.gameObject.SetActive(false);
            _langues.gameObject.SetActive(false);

        }
#endif
    }

    public void Avtorized()
    {
#if !UNITY_EDITOR
        PlayerAccount.Authorize();
#endif
    }

    public void SetScore(int scoreEmaunt)
    {
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            Leaderboard.SetScore(WavesLeader, scoreEmaunt);
        }
#endif
    }

    public void OnClosetButtonClick()
    {
        _leaderBoard.gameObject.SetActive(false);
        _langues.gameObject.SetActive(true);

        for (int i = 0; i < _liderboars.Length; i++)
        {
            _liderboars[i].gameObject.SetActive(false);
        }
    }
}
