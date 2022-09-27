using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]

public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;
    private int minFillValue = 0;
    private int maxFillValue = 1;

    public void ToFill()
    {
        StartCoroutine(Filling(minFillValue, maxFillValue, _lerpDuration, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(maxFillValue, minFillValue, _lerpDuration, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = maxFillValue;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed/ duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;  
        }

        lerpingEnd?.Invoke(endValue);
    }
}
