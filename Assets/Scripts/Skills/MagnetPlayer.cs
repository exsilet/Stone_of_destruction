using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPlayer : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Skill _magnet;
    [SerializeField] private float _normalizeRadius;
    [SerializeField] private float _averageValue;

    private Rigidbody _rigidbody;
    private SphereCollider _colliderMagnet;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colliderMagnet = GetComponent<SphereCollider>();
        IncreaseRadius();
    }

    private void IncreaseRadius()
    {
        _radius += _magnet.CountLevelSkills();

        if (_radius > _normalizeRadius)
        {
            _colliderMagnet.radius = (_radius / _normalizeRadius)- _averageValue;
        }
        else
        {
            _colliderMagnet.radius = _radius / _normalizeRadius;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
