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
    public float _increaseSpeed = 1f;
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
        _rigidbody.velocity = new Vector3(direction * _speedHorizontal, _rigidbody.velocity.y, (_speedForward * _increaseSpeed));
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

    //public float IncreaseSpeed()
    //{
    //    switch (_increaseSpeed)
    //    {
    //        case 1:
    //            return _increaseSpeed = (float)Math.Round((double)(105 / 100));
    //        case 2:
    //            return _increaseSpeed = (float)Math.Round((double)110 / 100);
    //        case 3:
    //            return _speedForward = (float)Math.Round((double)(_speedForward * 115 / 100));
    //        case 4:
    //            return _speedForward = (float)Math.Round((double)(_speedForward * 120 / 100));
    //        case 5:
    //            return _speedForward = (float)Math.Round((double)(_speedForward * 125 / 100));
    //        case 6:
    //            return _speedForward = (float)Math.Round((double)(_speedForward * 130 / 100));
    //    }

    //    return _speedForward;
    //}
}
