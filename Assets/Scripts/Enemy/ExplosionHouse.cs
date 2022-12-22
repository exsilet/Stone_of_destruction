using UnityEngine;

public class ExplosionHouse : MonoBehaviour
{
    [SerializeField] private CameraShake _camera;
    [SerializeField] private ParticleSystem _explosionParticl;

    public void HitHouse()
    {
        _explosionParticl.Play();
        _camera.StarkShake();
    }
}
