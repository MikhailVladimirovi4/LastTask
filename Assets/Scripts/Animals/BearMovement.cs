using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class BearMovement : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private float _speed;

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (transform.position != _hero.transform.position)
        {
            transform.Translate((_hero.transform.position - transform.position).normalized * _speed *Time.deltaTime);

            yield return null;
        }

        _animator.SetBool(AnimatorBearController.Params.Attack, true);
        _hero.gameObject.SetActive(false);
    }
}
