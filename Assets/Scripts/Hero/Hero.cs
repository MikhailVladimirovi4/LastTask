using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameController _controller;

    private Animator _animator;
    public event UnityAction Dying;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<float> AddTime;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        HealthChanged?.Invoke(_health);
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Dying?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TimeModifer timeModifer))
        {
            AddTime?.Invoke(timeModifer.StoredTime);
            timeModifer.Destroy();
        }
        else if (other.TryGetComponent(out DangerItem dangerItem))
        {
            TakeDamage(dangerItem.AttackValue);
            _animator.SetTrigger(AnimatorHeroController.Params.TakeDamage);
        }
    }
}