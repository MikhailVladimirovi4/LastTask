using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class RoadRenderer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepOffsetZ;

    private MeshRenderer _meshRenderer;
    private Vector2 _meshOffset;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }

    private void Update()
    {
        float offsetZ = Mathf.Repeat(Time.time * _speed, _stepOffsetZ);
        Vector2 offset = new Vector2(_meshOffset.x, offsetZ);
        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
