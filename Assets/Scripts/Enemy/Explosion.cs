using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _forceValue;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwModifier;
    
    private Rigidbody _targetRigidbody;

    private void Awake()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }


    public void Explode()
    {
        _targetRigidbody.AddExplosionForce(_forceValue, transform.position, _radius, _upwModifier);
    }
}
