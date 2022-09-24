using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Hero : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _currentSpeed;
    private Animator _animator;

  //  public event UnityEvent<float> SpeedChanged;

    private void Start()
    {
        _currentSpeed = _startSpeed;
        _animator = GetComponent<Animator>();
        _animator.SetFloat(AnimatorHeroController.Params.Speed, _currentSpeed);
    }

    private void Update()
    {        
        if (_currentSpeed < _startSpeed)
            return;

 //       SpeedChanged?.Invoke(_currentSpeed);
        _animator.SetFloat(AnimatorHeroController.Params.Speed, _currentSpeed);
    }
}