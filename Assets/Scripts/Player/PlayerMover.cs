using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] public float _stepSize;
    [SerializeField] private float _positionSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedMover;
    [SerializeField] private float _gravity;
    [SerializeField] private float _speedAngularVelocity;
    
    private Rigidbody _rigidbody;
    private float movePosition;
    private float currentScale;
    public float SpeedMover => _speedMover;
    public float StepSize => _stepSize;

    public event UnityAction EndLevels;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, _gravity, 0f);
        currentScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        movePosition = Input.GetAxis("Horizontal") * _positionSpeed;
        Vector3 movement = new Vector3(movePosition, transform.position.y, _stepSize) * _speedMover * Time.fixedDeltaTime;


        _rigidbody.angularVelocity = new Vector3(_speedAngularVelocity, 0f, -movePosition * _rotationSpeed);
        
        //_rigidbody.velocity = new Vector3(_stepSize * _speedAngularVelocity, 0f, -movePosition * _rotationSpeed);

        if (transform.localScale.x < currentScale)
        {
            _speedMover = 0;
            _rigidbody.velocity = Vector3.zero;
            EndLevels?.Invoke();
        }
    }
}
