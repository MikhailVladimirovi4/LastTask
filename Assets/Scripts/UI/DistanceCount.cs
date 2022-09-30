using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class DistanceCount : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _targetDistance;
    [SerializeField] private float _distancePerTime;

    public event UnityAction FateRules;

    private float _reachedDistance = 0;
    private float _secretDistanceDead = 50;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }

    private void Update()
    {
        _reachedDistance += _distancePerTime;
        _slider.value = _reachedDistance / _targetDistance;
    }

    private void FixedUpdate()
    {
        if (_targetDistance - _reachedDistance < _secretDistanceDead)
            FateRules?.Invoke();
    }
}
