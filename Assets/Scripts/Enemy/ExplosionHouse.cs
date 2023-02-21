using System.Collections.Generic;
using UnityEngine;

public class ExplosionHouse : MonoBehaviour
{
    [SerializeField] private CameraShake _camera;
    [SerializeField] private ParticleSystem _explosionParticl;
    [SerializeField] private List<Rigidbody> _fragments;

    public void HitHouse()
    {
        _explosionParticl.Play();
        _camera.StarkShake();

        foreach (var item in _fragments)
        {
            item.isKinematic = false;
        }
    }
}
