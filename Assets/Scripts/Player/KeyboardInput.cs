using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private float _speedForward;
    [SerializeField] private FloatingJoystick _joystick;
    
    private float moveVector;
    private bool _isKeyboardInput;
    private const string Horizontal = "Horizontal";

    private void FixedUpdate()
    {
        if (Application.isMobilePlatform)
        {
            _movement.Move(_joystick.Horizontal);
        }
        else
        {
            moveVector = Input.GetAxis(Horizontal);
            _movement.Move(moveVector);

            if (Input.GetMouseButton(0))
            {
                _movement.Move(_joystick.Horizontal);
            }
        }

        _movement.VolumeScale(_speedForward);
    }
}
