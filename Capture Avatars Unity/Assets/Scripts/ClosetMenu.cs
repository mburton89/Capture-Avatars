using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetMenu : Menu
{
    [SerializeField] private MenuButton _topsButton;

    void Start()
    {
        _topsButton.onClick.AddListener(MenuManager.Instance.OpenClosetTopsMenu);
    }
}
