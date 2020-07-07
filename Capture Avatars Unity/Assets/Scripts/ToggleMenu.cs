using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : Menu
{
    private UIToggleable _currentUIToggleable;

    [SerializeField] private Image _drakeShirt;

    private void Start()
    {
        LayoutElement[] layoutElements = GetComponentsInChildren<LayoutElement>(); 
        _drakeShirt.color = layoutElements[AvatarDataManager.Instance.activeAvatarData.shirtID].GetComponentInChildren<SelectableShirt>().shirtColor;
    }

    public void ToggleOn(UIToggleable uIToggleable)
    {
        if (_currentUIToggleable != null)
        {
            _currentUIToggleable.ToggleOff();
        }
        _currentUIToggleable = uIToggleable;
        _currentUIToggleable.ToggleOn();

        _drakeShirt.color = _currentUIToggleable.GetComponentInChildren<SelectableShirt>().shirtColor;

        AvatarDataManager.Instance.activeAvatarData.shirtID = _currentUIToggleable.GetComponentInParent<LayoutElement>().transform.GetSiblingIndex();
    }
}
