using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _hero.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _hero.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        int numberHeart;

        if (_hearts.Count < value)
        {
            numberHeart = value - _hearts.Count;

            for (int i = 0; i < numberHeart; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value)
        {
            numberHeart =_hearts.Count - value;

            for (int i = 0; i < numberHeart; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
