
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class ButtonGroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private UIAestheticsManager _controller;

    public UnityEvent onClick;

    [SerializeField] private GameObject _container;
    [SerializeField] private Image _circle;
    [SerializeField] private Image _shadow;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _raycastTarget;
    [SerializeField] private TextMeshProUGUI _label;

    private Color _accentColor;
    private Color _textHighlightColor;

    private float _pressedInScale;
    private float _secondsToPressIn;
    private float _secondsToUnpress;

    private Vector3 _initialContainerPosition;
    private Vector3 _initialShadowPosition;

    [SerializeField] private Menu _menuToOpen;

    public void Init(UIAestheticsManager controller)
    {
        _controller = controller;
        _accentColor = _controller.accentColor;
        _pressedInScale = _controller.pressedInScale;
        _secondsToPressIn = _controller.secondsToPressIn;
        _secondsToUnpress = _controller.secondsToUnpress;
        _initialContainerPosition = _container.transform.localPosition;
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

            //TODO remove when implemented all menus
            if (_menuToOpen == null)
            {
                _label.color = Color.grey;
                _icon.color = Color.grey;
            }
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
        if (_menuToOpen != null)
        {
            MenuManager.Instance.OpenMenu(_menuToOpen, GetComponentInChildren<UIMovable>());
        }
        else
        {
            Debug.LogWarning("Menu not implemented.");
            DebugConsole.Instance.ShowMessage("Menu not implemented.");
        }
    }

    public void MoveOffScreen()
    {
        float duration = _controller.secondsToMoveButtons;
        _container.transform.DOMoveX(-10f, duration);
        _circle.DOFade(0, duration);
        _shadow.DOFade(0, duration);
        _icon.DOFade(0, duration);
        _label.DOFade(0, duration);
        _raycastTarget.raycastTarget = false;
    }

    public void MoveOnScreen()
    {
        float duration = _controller.secondsToMoveButtons;
        _container.transform.localPosition = _initialContainerPosition;
        _circle.DOFade(1, duration);
        _shadow.DOFade(1, duration);
        _icon.DOFade(1, duration);
        _label.DOFade(1, duration);
        _raycastTarget.raycastTarget = true;
    }
}
