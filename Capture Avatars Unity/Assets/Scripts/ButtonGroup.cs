
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class ButtonGroup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image _circle;
    [SerializeField] private Image _shadow;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _label;

    [SerializeField] private Color _accentColor;
    [SerializeField] private Color _textHighlightColor;

    [SerializeField] private float _pressedInScale;
    [SerializeField] private float _secondsToPressIn;
    [SerializeField] private float _secondsToUnpress;

    private Vector3 _initialShadowPosition;

    void Awake()
    {
        _initialShadowPosition = _shadow.transform.localPosition;

        if (_icon == null)
        {
            _textHighlightColor = Color.white;
        }
        else
        {
            _textHighlightColor = _accentColor;
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
        Debug.Log("OnPointerClick");
    }
}
