using UnityEngine;
using UnityEngine.UI;

public class UIToggleable : MonoBehaviour
{
    private ToggleMenu _toggleMenu;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;

    void Start()
    {
        _toggleMenu = GetComponentInParent<ToggleMenu>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(HandleClick);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(HandleClick);
    }

    void HandleClick()
    {
        _toggleMenu.ToggleOn(this);
    }

    public void ToggleOn()
    {
        _image.enabled = true;
    }

    public void ToggleOff()
    {
        _image.enabled = false;
    }
}
