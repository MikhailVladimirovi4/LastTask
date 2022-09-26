using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BearMovement : MonoBehaviour 
{
    [SerializeField] private Hero _hero;

    private Animator _animator;

    private void OnEnable()
    {
        _hero.Dying += GetAttack;
        _animator = GetComponent<Animator>();
    }

    private void GetAttack()
    {
        transform.position = _hero.transform.position;
        _animator.SetBool(AnimatorBearController.Params.Attack, true);
        _hero.Dying -= GetAttack;
    }
}
