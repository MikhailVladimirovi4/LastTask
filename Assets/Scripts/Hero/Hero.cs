using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _lifeTime;

    private Animator _animator;
    public event UnityAction Dying;

    public int Health { get; private set; }

    public float LifeTime { get; private set; }

    public void AddLifeTime(float time)
    {
        LifeTime += time;
    }

    private void Start()
    {
        Health = _health;
        LifeTime = _lifeTime;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
            Dying?.Invoke();
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
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