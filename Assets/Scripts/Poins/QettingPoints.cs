using UnityEngine;

public class QettingPoints : MonoBehaviour
{
    [SerializeField] private WaveCounter _wave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnvironmentalDestruction destruction))
        {
            _wave.AddPoints(destruction.GetScore);
        }
    }
}
