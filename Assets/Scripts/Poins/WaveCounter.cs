using UnityEngine;
using UnityEngine.Events;

public class WaveCounter : MonoBehaviour
{
    private int _scoring;
    public int GetScore => _scoring;

    public event UnityAction<int> ScoreChanged;

    public void AddPoints(int points)
    {
        _scoring += points;
        ScoreChanged?.Invoke(_scoring);
    }
}
