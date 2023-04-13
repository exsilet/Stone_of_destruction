using UnityEngine;

public class PathPoints : MonoBehaviour
{
    [SerializeField] private WaveCounter _wave;
    [SerializeField] private int _coefficient;

    private float _distance;
    private bool _stopDistance = true;
    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    private void UpdateDistance()
    {
        if (_stopDistance)
            _distance = Mathf.Abs(transform.position.z - _currentPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FactorMoney factor))
        {
            UpdateDistance();
            _stopDistance = false;
            _distance /= _coefficient;
            _wave.AddPoints((int)_distance);
        }
    }
}
