using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private float _speedForward;

    private float _updateSpeed;
    private const string Horizontal = "Horizontal";
    private const string MouseX = "Mouse X";

    public float UpdateSpeed => _updateSpeed;

    private void FixedUpdate()
    {
        float moveVector;
        moveVector = Input.GetAxis(Horizontal);

        _movement.Move(moveVector);
        _movement.VolumeScale(_speedForward);
    }
}
