using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathMenu : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _path1Button;
    [SerializeField] private Button _path2Button;

    void Start()
    {
        _backButton.onClick.AddListener(MenuManager.Instance.GoBack);
    }
}
