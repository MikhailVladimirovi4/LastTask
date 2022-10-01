using UnityEngine;

public class DangerItem : SpawnItem
{
    [SerializeField] private int _attackValue;

    public int AttackValue => _attackValue;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        if (transform.position == Target.position)
            Destroy(gameObject);
    }
}
