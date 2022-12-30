using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPlayer : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Magnet _magnet;
    [SerializeField] private SaveLoadSkills _saveLoadSkills;

    private float upgradeMagnet;

    private void Awake()
    {
        IncreaseRadius();
    }

    public void IncreaseRadius()
    {

        _radius += upgradeMagnet;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
