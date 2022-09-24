using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _stepSizeX;
    [SerializeField] private float _stepSpeedX;
    [SerializeField] private float _startSpeed;
    [SerializeField] private int _jumpForce;
    [SerializeField] private float _jumpTrigger;

    private float _currentSpeed;
    private float _targetSpeed;
    private Vector3 _targetPosition;
    private float _startPositionY;
    private Animator _animator;
    private Rigidbody _rigidbody;

    public event UnityAction<float> ChangedSpeed;

    private void Start()
    {
        _targetPosition = transform.position;
        _startPositionY = transform.position.y;
        _targetSpeed = _startSpeed;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator.SetFloat(AnimatorHeroController.Params.Speed, _currentSpeed);
    }

    private void Update()
    {

        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _stepSpeedX * Time.deltaTime);

        if (_currentSpeed != _targetSpeed)
            SetSpeed(_targetSpeed);
    }

    private void SetSpeed(float targetSpeed)
    {
        _currentSpeed = targetSpeed;
        ChangedSpeed?.Invoke(_currentSpeed);
        _animator.SetFloat(AnimatorHeroController.Params.Speed, _currentSpeed);
    }

    public void TryStepLeft()
    {
        if (_targetPosition.x > -_stepSizeX)
            SetPosition(-_stepSizeX);
    }

    public void TryStepRight()
    {
        if (_targetPosition.x < _stepSizeX)
            SetPosition(_stepSizeX);
    }

    public void TryJump()
    {
        if (transform.position.y - _startPositionY < _jumpTrigger)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger(AnimatorHeroController.Params.Jump);
        }
    }

    private void SetPosition(float stepSize)
    {
        _targetPosition = new Vector2(transform.position.x + stepSize, transform.position.y);
    }
}
