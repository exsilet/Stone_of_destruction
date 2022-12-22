using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _inpuls;

    private CinemachineImpulseSource source;

    private void Start()
    {
        source = transform.GetComponent<CinemachineImpulseSource>();
    }

    public void StarkShake()
    {
        source.GenerateImpulse(_inpuls);
    }
}
