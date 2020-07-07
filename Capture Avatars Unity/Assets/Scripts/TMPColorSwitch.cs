using UnityEngine;
using TMPro;

public class TMPColorSwitch : MonoBehaviour
{
    [SerializeField] private UIHoverOverHandler _controller;

    [SerializeField] private Color mouseOnColor;
    [SerializeField] private Color mouseOffColor;

    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        _controller.onPointerEnter.AddListener(ShowMouseOnColor);
        _controller.onPointerExit.AddListener(ShowMouseOffColor);
    }

    void OnDisable()
    {
        _controller.onPointerEnter.RemoveListener(ShowMouseOnColor);
        _controller.onPointerExit.RemoveListener(ShowMouseOffColor);
    }

    void ShowMouseOnColor()
    {
        _text.color = mouseOnColor;
    }

    void ShowMouseOffColor()
    {
        _text.color = mouseOffColor;
    }
}
