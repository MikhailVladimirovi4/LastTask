using System.Collections;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _alphaChangeRate;
    [SerializeField] private GameController _gameController;

    private void OnEnable()
    {
        _canvasGroup.alpha = 0;
    }

    public void Open()
    {
        StartCoroutine(Display());
    }

    private IEnumerator Display()
    {
        float targetAlpha = 1;

        while (_canvasGroup.alpha != targetAlpha)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, targetAlpha, _alphaChangeRate * Time.deltaTime);

            yield return null;
        }

        _gameController.StopGame();
    }
}
