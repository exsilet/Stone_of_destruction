using UnityEngine;

public class BouncingOnTheTrack : MonoBehaviour
{
    [SerializeField] private float _forceValue;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwModifier;
    [SerializeField] private ParticleSystem _explosionParticl;

    private Rigidbody _targetRigidbody;
    private Collider _targetCollider;

    private void Awake()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
        _targetCollider = GetComponent<BoxCollider>();
    }

    public void Tossing()
    {
        _targetRigidbody.isKinematic = false;
        _targetRigidbody.AddExplosionForce(_forceValue, transform.position, _radius, _upwModifier);
        _explosionParticl.Play();
        _targetCollider.isTrigger = false;
    }
}
