using UnityEngine;

[RequireComponent(typeof(Movement))]

public class HeroInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _movementTrigger;

    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (_joystick.Horizontal < -_movementTrigger)
            _movement.TryStepLeft();

        if (_joystick.Horizontal > _movementTrigger)
            _movement.TryStepRight();

        if (_joystick.Vertical > _movementTrigger)
            _movement.TryJump();
    }
}
