using UnityEngine;

public class RotationWhell : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0, _rotationSpeed, 0);
    }
}