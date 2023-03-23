using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ExplosionHouse : MonoBehaviour
{
    [SerializeField] private CameraShake _camera;
    [SerializeField] private ParticleSystem _explosionParticl;
    [SerializeField] private List<Rigidbody> _fragments;

    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void HitHouse()
    {
        _explosionParticl.Play();
        _camera.StarkShake();

        _collider.enabled = false;

        foreach (var item in _fragments)
        {
            item.isKinematic = false;
        }
    }
}
