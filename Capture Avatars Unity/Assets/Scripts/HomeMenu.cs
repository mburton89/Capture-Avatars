using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenu : Menu
{
    [SerializeField] private ButtonGroup _closetButton;

    void Start()
    {
        //_closetButton.onClick.AddListener(MenuManager.Instance.OpenClosetMenu);
    }
}
