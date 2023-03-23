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
        if (other.gameObject.TryGetComponent(out VolumeGrowth grous))
        {
            transform.localScale = new Vector3(transform.localScale.x + grous.Volume, transform.localScale.y + grous.Volume, transform.localScale.z + grous.Volume);
        }

        if (other.gameObject.TryGetComponent(out DecreaseSize decrease))
        {
            transform.localScale = new Vector3(transform.localScale.x - decrease.Size, transform.localScale.y - decrease.Size, transform.localScale.z - decrease.Size);
        }

        if (other.gameObject.TryGetComponent(out FactorMoney factorMoney))
        {
            _endLevels.SetCollision();
            currentFactor += (int)factorMoney.Factor;

            if (transform.localScale.x < currentScale)
            {
                _player.FactorMoney(currentFactor);
            }
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
