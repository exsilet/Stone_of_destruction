using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    [SerializeField] private MagnetPlayer _player;
    [SerializeField] private float _speedMagnet;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out MagnetPlayer magnet))
        {
            _rigidbody.velocity = (magnet.transform.position - transform.position).normalized * _speedMagnet;
        }
    }
}
