using UnityEngine;

[RequireComponent(typeof(HeroMovement))]

public class HeroInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _movementTrigger;

    private HeroMovement _movement;

    private void Start()
    {
        _movement = GetComponent<HeroMovement>();
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
