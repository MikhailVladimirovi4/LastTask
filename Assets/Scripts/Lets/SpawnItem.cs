using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    protected Transform Target;
    protected float Speed;

    public void Initialize(float speed, Transform target)
    {
        Speed = speed;
        Target = target;
    }
}
