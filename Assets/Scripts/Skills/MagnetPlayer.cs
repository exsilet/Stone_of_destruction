using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPlayer : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Skill _magnet;
    [SerializeField] private SaveLoadSkills _saveLoadSkills;

    private void Start()
    {
        IncreaseRadius();
    }

    public void IncreaseRadius()
    {
        _radius += _magnet.CountLevelSkills();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
