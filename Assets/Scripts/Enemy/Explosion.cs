using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _forceValue;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwModifier;
    //[SerializeField] private ParticleSystem _explosionParticl;
    
    private Rigidbody _targetRigidbody;

    private void Awake()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent(out Player player))
    //    {
    //        _targetRigidbody.AddExplosionForce(_forceValue, transform.position, _radius, _upwModifier);
    //        // _explosionParticl.Play();
    //    }
    //}

    public void Explode()
    {
        _targetRigidbody.AddExplosionForce(_forceValue, transform.position, _radius, _upwModifier);
        // _explosionParticl.Play();
    }
}
