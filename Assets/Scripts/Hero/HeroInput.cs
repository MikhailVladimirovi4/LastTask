using UnityEngine;

[RequireComponent(typeof(Movement))]

public class HeroInput : MonoBehaviour
{
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            _movement.TryStepLeft();

        if (Input.GetKeyDown(KeyCode.D))
            _movement.TryStepRight();
    }
}
