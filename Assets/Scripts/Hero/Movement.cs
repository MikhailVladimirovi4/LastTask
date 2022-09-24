using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _stepSize;
    [SerializeField] private float _stepSpeed;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _stepSpeed * Time.deltaTime);
    }

    public void TryStepLeft()
    {
        if (_targetPosition.x > -_stepSize)
            SetPosition(-_stepSize);
    }

    public void TryStepRight()
    {
        if (_targetPosition.x < _stepSize)
            SetPosition(_stepSize);
    }

    private void SetPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }
}
