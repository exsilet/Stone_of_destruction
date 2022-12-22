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

    private void Update()
    {
        //float horizontal = Input.GetAxis(Horizontal);
        //float horizontal = Input.GetAxis(MouseX);
        float moveVector;
        moveVector = Move();

        _movement.Move(new Vector3(moveVector, 0f, (_speedForward + _updateSpeed)));
        _movement.VolumeScale(_speedForward);
    }

    public float Move()
    {
        float horizontal;
        return horizontal = Input.GetAxis(Horizontal);
    }
}
