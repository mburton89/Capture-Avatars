using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private UIAestheticsManager _controller;

    [SerializeField] private GameObject _container;
    [SerializeField] private Image _bg;
    [SerializeField] private Image _raycastTarget;
    [SerializeField] private TextMeshProUGUI _label;

    private Color _accentColor;
    private Color _textHighlightColor;

    private float _pressedInScale;
    private float _secondsToPressIn;
    private float _secondsToUnpress;

    private Vector3 _onScreenPosition;
    private Vector3 _offScreenPosition;
    private Vector3 _initialShadowPosition;

    public UnityEvent onClick;

    [SerializeField] private Menu _menuToOpen;

    public void Init(UIAestheticsManager controller)
    {
        _controller = controller;
        _accentColor = _controller.accentColor;
        _pressedInScale = _controller.pressedInScale;
        _secondsToPressIn = _controller.secondsToPressIn;
        _secondsToUnpress = _controller.secondsToUnpress;
        _onScreenPosition = _container.transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _bg.color = _accentColor;
        _label.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _bg.color = Color.clear;
        _label.color = Color.black;

        if (_menuToOpen == null)
        {
            _label.color = Color.grey;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(_pressedInScale, _secondsToPressIn);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(1, _secondsToUnpress);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Open Sub Menu for " + gameObject.name);
        //onClick.Invoke();
        if (_menuToOpen != null)
        {
            MenuManager.Instance.OpenMenu(_menuToOpen);
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
        _bg.DOFade(0, duration);
        _label.DOFade(0, duration);
        _raycastTarget.raycastTarget = false;
    }

    public void MoveOnScreen()
    {
        float duration = _controller.secondsToMoveButtons;
        _container.transform.DOMove(_onScreenPosition, duration);
        _bg.DOFade(1, duration);
        _label.DOFade(1, duration);
        _raycastTarget.raycastTarget = true;
    }
}
