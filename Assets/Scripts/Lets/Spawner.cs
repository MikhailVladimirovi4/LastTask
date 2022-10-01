using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<DangerItem> _items;
    [SerializeField] private float _delaySpawnItem;
    [SerializeField] private Transform _itemTargetMovement;
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private float _startSpeedItem;

    private Coroutine _createItem;
    private WaitForSeconds _pauseSpawn;

    private void Start()
    {
        _pauseSpawn = new WaitForSeconds(_delaySpawnItem);
    }

    private void Update()
    {
        if (_createItem != null)
            return;

        _createItem = StartCoroutine(CreateItem());
    }

    private IEnumerator CreateItem()
    {
        var _speedModiferObject = Instantiate(_items[Random.Range(0, _items.Count)], transform.position, Quaternion.identity);
        _speedModiferObject.Initialize(_startSpeedItem, _itemTargetMovement);

        yield return _pauseSpawn;

        _createItem = null;
    }
}
