using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _stepSizeX;
    [SerializeField] private float _stepSpeedX;
    [SerializeField] private float _startSpeed;
    [SerializeField] private int _jumpForce;
    [SerializeField] private float _jumpTrigger;
    [SerializeField] private float _stepSpeedChange;
    [SerializeField] private TrailDust _trailDust;

    private float _currentSpeed;
    private Vector3 _targetPosition;
    private float _startPositionY;
    private Animator _animator;
    private Rigidbody _rigidbody;

    public void TryStepLeft()
    {
        if (_targetPosition.x > -_stepSizeX && _targetPosition.x == transform.position.x)
            SetPosition(-_stepSizeX);
    }

    public void TryStepRight()
    {
        if (_targetPosition.x < _stepSizeX && _targetPosition.x == transform.position.x)
            SetPosition(_stepSizeX);
    }

    public void TryJump()
    {
        if (transform.position.y - _startPositionY < _jumpTrigger)
        {
            _rigidbody.AddForce(0,0,0);
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger(AnimatorHeroController.Params.Jump);        }
    }

    private void Start()
    {
        _targetPosition = transform.position;
        _startPositionY = transform.position.y;
        _currentSpeed = _startSpeed;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator.SetFloat(AnimatorHeroController.Params.Speed, _currentSpeed);
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _stepSpeedX * Time.deltaTime);
        }

        _trailDust.gameObject.SetActive(transform.position.y == _startPositionY);
    }

    private void SetPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }
}
