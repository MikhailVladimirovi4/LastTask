using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    protected Transform Target;
    protected float Speed;

    public void Initialize(float speed, Transform target)
    {
        Speed = speed;
        Target = target;
    }
}
