using UnityEngine;
using Agava.YandexGames;

public class YandexLeaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardElement[] _leaderboards;
    [SerializeField] private Transform _languages;
    [SerializeField] private Transform _leaderBoard;
    [SerializeField] private Transform _listleaderBoard;
    [SerializeField] private Transform _notLogin;
    [SerializeField] private SaveLoadScore _score;
    [SerializeField] private Converter _converter;
    [SerializeField] private int _topPlayersCount = 3;
    [SerializeField] private int _competingPlayersCount = 5;

    private const string WavesLeader = "BestInTheGame";
    private const string Anonymous = "Anonymous";

    private void Start()
    {
        SetScore(_score.ReadScore());
    }

    public void Show()
    {
        _leaderBoard.gameObject.SetActive(true);
        _languages.gameObject.SetActive(false);

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

                    _leaderboards[i].gameObject.SetActive(true);
                    _leaderboards[i].Render(_converter.ToLeaderboardElementData(entry.rank, entry.player.lang, name, entry.score));
                }
            }, null, _topPlayersCount, _competingPlayersCount);
        }
        else
        {
            _notLogin.gameObject.SetActive(true);
            _listleaderBoard.gameObject.SetActive(false);
            _languages.gameObject.SetActive(false);

        }
#endif
    }

    public void Authorized()
    {
#if !UNITY_EDITOR
        PlayerAccount.Authorize();
#endif
    }

    public void OnClosetButtonClick()
    {
        _leaderBoard.gameObject.SetActive(false);
        _languages.gameObject.SetActive(true);

        foreach (var element in _leaderboards)
        {
            element.gameObject.SetActive(false);
        }
    }

    private void SetScore(int scoreAmount)
    {
#if !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
        {
            Leaderboard.SetScore(WavesLeader, scoreAmount);
        }
#endif
    }
}
