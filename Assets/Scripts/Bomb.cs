using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
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
        _targetCollider.isTrigger = false;
    }
}
