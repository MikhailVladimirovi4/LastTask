using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<DangerItem> _items;
    [SerializeField] private TimeModifer _TimeModifer;
    [SerializeField] private int _delaySpawnTime;
    [SerializeField] private float _delaySpawnItem;
    [SerializeField] private Transform _itemTargetMovement;
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private float _startSpeedItem;

    private float _elapsedTimeSpawnTime = 0;
    private float _elapsedTimeSpawnItem = 0;


    private void Update()
    {
        _elapsedTimeSpawnTime += Time.deltaTime;
        _elapsedTimeSpawnItem += Time.deltaTime;

        if (_elapsedTimeSpawnTime > _delaySpawnTime)
        {
            _elapsedTimeSpawnTime = 0;
            CreateItem(_TimeModifer);
            return;
        }
        else if(_elapsedTimeSpawnItem > _delaySpawnItem)
        {
            _elapsedTimeSpawnItem = 0;
            CreateItem(_items[Random.Range(0,_items.Count)]);
        }
    }

    private void CreateItem( SpawnItems item)
    {
       var _speedModiferObject = Instantiate(item, transform.position, Quaternion.identity);
        _speedModiferObject.Initialize(_startSpeedItem, _itemTargetMovement);
    }
}
