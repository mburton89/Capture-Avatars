using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorSwitch : MonoBehaviour
{
    [SerializeField] private UIHoverOverHandler _controller;

    [SerializeField] private Color mouseOnColor;
    [SerializeField] private Color mouseOffColor;

    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
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
        _image.color = mouseOnColor;
    }

    void ShowMouseOffColor()
    {
        _image.color = mouseOffColor;
    }
}
