
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Background : MonoBehaviour
{
    [SerializeField] private Movement _heroMovement;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _heroMovement.ChangedSpeed += SetSpeedAnimation;
    }

    private void OnDisable()
    {
        _heroMovement.ChangedSpeed -= SetSpeedAnimation;
    }

    private void SetSpeedAnimation(float speed)
    {
        _animator.SetFloat(AnimatorBackgroundController.States.Play, speed);
    }
}
