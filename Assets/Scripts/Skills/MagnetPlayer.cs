using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPlayer : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Magnet _magnet;

    private float upgradeMagnet;

    private void Awake()
    {
        IncreaseRadius();
    }

    public void IncreaseRadius()
    {
        upgradeMagnet = PlayerPrefs.GetInt(_magnet.Product);
        _radius += upgradeMagnet;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
