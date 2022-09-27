using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _lifeTime;

    private Animator _animator;
    public event UnityAction Dying;
    public event UnityAction<int> HealthChanged;

    public float LifeTime { get; private set; }

    public void AddLifeTime(float time)
    {
        LifeTime += time;
    }

    private void Start()
    {
        LifeTime = _lifeTime;
        _animator = GetComponent<Animator>();
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
            Dying?.Invoke();
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Dying?.Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TimeModifer timeModifer))
        {
            AddLifeTime(timeModifer.StoredTime);
            timeModifer.Destroy();
        }
        else if (other.TryGetComponent(out DangerItem dangerItem))
        {
            TakeDamage(dangerItem.AttackValue);
            _animator.SetTrigger(AnimatorHeroController.Params.TakeDamage);
        }
    }
}