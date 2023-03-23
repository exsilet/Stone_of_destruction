using TMPro;
using UnityEngine;

public class ScoreBalance : MonoBehaviour
{
    [SerializeField] private WaveCounter _wave;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _failScore;

    private void OnEnable()
    {
        _wave.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _wave.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _currentScore.text = score.ToString();
        _failScore.text = score.ToString();
    }
}