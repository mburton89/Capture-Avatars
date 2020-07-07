
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class HighlightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private UIAestheticsManager _controller;

    [SerializeField] private Image _circle;
    [SerializeField] private Image _shadow;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _label;

    private Color _accentColor;
    private Color _textHighlightColor;

    private float _pressedInScale;
    private float _secondsToPressIn;
    private float _secondsToUnpress;

    private Vector3 _initialLocalPosition;
    private Vector3 _initialShadowPosition;

    public void Init(UIAestheticsManager controller)
    {
        _controller = controller;
        _accentColor = _controller.accentColor;
        _pressedInScale = _controller.pressedInScale;
        _secondsToPressIn = _controller.secondsToPressIn;
        _secondsToUnpress = _controller.secondsToUnpress;
        _initialLocalPosition = transform.localPosition;
        _initialShadowPosition = _shadow.transform.localPosition;

        if (_icon == null)
        {
            _textHighlightColor = Color.white;
        }
        else
        {
            _textHighlightColor = _controller.accentColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _circle.color = _accentColor;
        _label.color = _textHighlightColor;
        if (_icon != null)
        {
            _icon.color = Color.white;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _circle.color = Color.white;
        _label.color = Color.black;
        if (_icon != null)
        {
            _icon.color = Color.black;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(_pressedInScale, _secondsToPressIn);
        _shadow.transform.DOLocalMove(Vector3.zero, _secondsToPressIn);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(1, _secondsToUnpress);
        _shadow.transform.DOLocalMove(_initialShadowPosition, _secondsToUnpress);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //_controller.MoveHomeButtonsOffScreen(this);
    }

    public void MoveOffScreen()
    {
        float duration = _controller.secondsToMoveButtons;
        transform.DOMoveX(-10f, duration);
        _circle.DOFade(0, duration);
        _shadow.DOFade(0, duration);
        _icon.DOFade(0, duration);
        _label.DOFade(0, duration);
    }

    public void MoveOnScreen()
    {
        float duration = _controller.secondsToMoveButtons;
        transform.localPosition = _initialLocalPosition;
        _circle.DOFade(1, duration);
        _shadow.DOFade(1, duration);
        _icon.DOFade(1, duration);
        _label.DOFade(1, duration);
    }
}
