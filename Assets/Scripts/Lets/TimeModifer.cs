using UnityEngine;

public class TimeModifer : SpawnItems
{
    [SerializeField] private float _storedTime;
    [SerializeField] private float _offsetPositionY;

    public float StoredTime => _storedTime;

    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _offsetPositionY, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        if (transform.position == Target.position)
            Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
