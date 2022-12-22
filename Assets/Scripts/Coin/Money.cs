using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMoney player))
        {
            player.IncreaseMoney(_money);
            Destroy(gameObject);
        }
    }
}
