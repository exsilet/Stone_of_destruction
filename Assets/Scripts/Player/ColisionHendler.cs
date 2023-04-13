using UnityEngine;

public class ColisionHendler : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private EndLevels _endLevels;

    private int currentFactor;
    private float currentScale;

    private void Start()
    {
        currentScale = transform.localScale.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out VolumeGrowth growth))
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x + growth.Volume, localScale.y + growth.Volume, localScale.z + growth.Volume);
            transform.localScale = localScale;
        }

        if (other.gameObject.TryGetComponent(out DecreaseSize decrease))
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x - decrease.Size, localScale.y - decrease.Size, localScale.z - decrease.Size);
            transform.localScale = localScale;
        }

        if (other.gameObject.TryGetComponent(out FactorMoney factorMoney))
        {
            _endLevels.SetCollision();
            currentFactor += (int)factorMoney.Factor;
        }

        if (other.gameObject.TryGetComponent(out Explosion explosion))
        {
            explosion.Explode();
        }

        if (other.gameObject.TryGetComponent(out BouncingOnTheTrack bouncing))
        {
            bouncing.Tossing();
        }

        if (other.gameObject.TryGetComponent(out ExplosionHouse house))
        {
            house.HitHouse();
        }
    }
}
