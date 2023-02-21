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
    [SerializeField] private Skill _skillSpeed;
    [SerializeField] private Skill _skillVolume;
    
    private float currentScale;
    private float currentSpeed;
    private float _increaseVolume;
    private float _increaseSpeed = 1f;

    public event UnityAction EndLevels;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, _gravity, 0f);
        currentScale = transform.localScale.x;
        Time.timeScale = 1;
        StartCoroutine(StartIncrese());

    }

    private IEnumerator StartIncrese()
    {
        yield return null;
        IncreaseVolume();
        IncreaseSpeed();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector3(direction * _speedHorizontal, _rigidbody.velocity.y, currentSpeed);

        _rigidbody.AddTorque(_rotationSpeed, 0f, 0f);
    }

    public void IncreaseVolume()
    {
        _increaseVolume += _skillVolume.CountLevelSkills();
        transform.localScale = new Vector3(transform.localScale.x + _increaseVolume, transform.localScale.y + _increaseVolume, transform.localScale.z + _increaseVolume);
    }

    public void IncreaseSpeed()
    {
        _increaseSpeed += _skillSpeed.CountLevelSkills();
        currentSpeed = _speedForward * _increaseSpeed;
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
