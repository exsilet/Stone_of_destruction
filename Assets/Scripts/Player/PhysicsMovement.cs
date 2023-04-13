using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
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
        currentScale = transform.localScale.x;
        Time.timeScale = 1;
        StartCoroutine(StartIncrease());

    }

    private IEnumerator StartIncrease()
    {
        yield return null;
        IncreaseVolume();
        IncreaseSpeed();
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector3(direction * _speedHorizontal, Physics.gravity.y * _gravity, currentSpeed);

        _rigidbody.AddTorque(_rotationSpeed, 0f, 0f);
    }

    private void IncreaseVolume()
    {
        _increaseVolume += _skillVolume.CountLevelSkills();
        transform.localScale = new Vector3(transform.localScale.x + _increaseVolume, transform.localScale.y + _increaseVolume, transform.localScale.z + _increaseVolume);
    }

    private void IncreaseSpeed()
    {
        _increaseSpeed += _skillSpeed.CountLevelSkills();
        currentSpeed = _speedForward * _increaseSpeed;
    }

    public void VolumeScale(float movementSpeed)
    {
        if (transform.localScale.x < currentScale)
        {
            movementSpeed = 0;
            _rigidbody.velocity = Vector3.zero;
            EndLevels?.Invoke();
        }
    }
}
