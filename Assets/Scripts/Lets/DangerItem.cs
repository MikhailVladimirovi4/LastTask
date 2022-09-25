using UnityEngine;

public class DangerItem : SpawnItems
{
    [SerializeField] private int attackValue;

    public int AttackValue => attackValue;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        if (transform.position == Target.position)
            Destroy(gameObject);
    }
}
