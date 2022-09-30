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
        Transform targetTransform = _hero.transform;
        float currentPozitionX = transform.position.x;
        float currentPozitionZ = transform.position.z;

        while (transform.position.z != targetTransform.position.z)
        {
            currentPozitionZ = Mathf.MoveTowards(transform.position.z, targetTransform.position.z, _speed * Time.deltaTime);
            currentPozitionX = Mathf.MoveTowards(transform.position.x, targetTransform.position.x, _speed * Time.deltaTime);
            transform.position = new Vector3(currentPozitionX, transform.position.y, currentPozitionZ);

            yield return null;
        }

        _animator.SetBool(AnimatorBearController.Params.Attack, true);
        _hero.gameObject.SetActive(false);
    }
}
