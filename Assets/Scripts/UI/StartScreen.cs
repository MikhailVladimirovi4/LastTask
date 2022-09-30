using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    public event UnityAction PlayButtonClick;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public  void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private  void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
