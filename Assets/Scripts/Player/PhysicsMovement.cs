using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speedDisplacement;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _speedForward;
    [SerializeField] private float _speedHorizontal;

    private float currentScale;
    public event UnityAction EndLevels;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, _gravity, 0f);
        currentScale = transform.localScale.x;
        Time.timeScale = 1;
    }

    public void Move(float direction)
    {
        //Vector3 directionAlongSurfase = _surfaceSlider.Project(direction.normalized);
        //Vector3 offset = directionAlongSurfase * (_speedDisplacement * Time.fixedDeltaTime);

        //_rigidbody.MovePosition(_rigidbody.position + offset);
        _rigidbody.velocity = new Vector3(direction * _speedHorizontal, _rigidbody.velocity.y, (_speedForward * 1.1f));
        //метод incrisesspeed float

        _rigidbody.AddTorque(_rotationSpeed, 0f, 0f);
    }

    public void VolumeScale(float speedMovet)
    {
        if (transform.localScale.x < currentScale)
        {
            speedMovet = 0;
            _rigidbody.velocity = Vector3.zero;
            EndLevels?.Invoke();
        }
    }
}
