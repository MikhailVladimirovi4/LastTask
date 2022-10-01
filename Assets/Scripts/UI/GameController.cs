using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private FixedJoystick _joystik;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private DistanceCount _distanceCount;
    [SerializeField] private BearMovement _bearMovement;

    private float _timeLeft;

    public float GetTime => _timeLeft;

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _hero.Dying += FinishGame;
        _hero.AddTime += AddTime;
        _startScreen.PlayButtonClick += StartGame;
        _distanceCount.FateRules += FinishGame;
    }

    private void OnDisable()
    {
        _hero.Dying -= FinishGame;
        _hero.AddTime -= AddTime;
        _startScreen.PlayButtonClick -= StartGame;
        _distanceCount.FateRules -= FinishGame;
    }

    private void Start()
    {
        _joystik.gameObject.SetActive(false);
        _distanceCount.enabled = false;
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        _startScreen.Close();
        _joystik.gameObject.SetActive(true);
        _distanceCount.enabled = true;
        Time.timeScale = 1;

        foreach (var spawner in _spawners)
            spawner.StartSpawn();
    }
    private void FinishGame()
    {
        _bearMovement.GetAttack();
        _gameOverScreen.Open();

        foreach (var spawner in _spawners)
            spawner.StopSpawn();
    }

    private void AddTime(float time)
    {
        _timeLeft += time;
    }
}
