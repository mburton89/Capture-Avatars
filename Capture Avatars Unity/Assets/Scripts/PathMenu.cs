using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathMenu : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _path1Button;
    [SerializeField] private Button _path2Button;

    [SerializeField] private GameObject _container;
    [SerializeField] private List<GameObject> _level1Elements;
    [SerializeField] private List<GameObject> _level2Elements;

    [SerializeField] private HomeMenu _homeMenu;
    [HideInInspector] public Menu level1Menu;
    [HideInInspector] public Menu level2Menu;

    public enum PathState
    {
        Home,
        Level1,
        Level2
    }

    public PathState CurrentState;

    void Start()
    {
        CurrentState = PathState.Home;
        _backButton.onClick.AddListener(HandleBackClicked);
        _path1Button.onClick.AddListener(HandlePath1ButtonClicked);
        _path2Button.onClick.AddListener(HandlePath2ButtonClicked);
    }

    void HandleBackClicked()
    {
        if (level2Menu != null)
        {
            MenuManager.Instance.previousMenu = _homeMenu;
            MenuManager.Instance.currentMenu = level1Menu;
            level2Menu.Close();
            level1Menu.Open();
            ShowLevel1Elements();
            level2Menu = null;
        }
        else if (level1Menu != null)
        {
            MenuManager.Instance.previousMenu = _homeMenu;
            MenuManager.Instance.currentMenu = _homeMenu;
            level1Menu.Close();
            _homeMenu.Open();
            Hide();
            level1Menu = null;
        }
    }

    public void AssignCurrentMenu(Menu currentMenu)
    {
        if (level1Menu == null)
        {
            level1Menu = currentMenu;
            ShowLevel1Elements();
        }
        else if (level2Menu == null)
        {
            level2Menu = currentMenu;
            ShowLevel2Elements();
        }
    }

    void Hide()
    {
        _container.SetActive(false);
    }

    void ShowLevel1Elements()
    {
        _container.SetActive(true);
        foreach (GameObject gameObject in _level2Elements)
        {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in _level1Elements)
        {
            gameObject.SetActive(true);
        }
    }

    void ShowLevel2Elements()
    {
        foreach (GameObject gameObject in _level2Elements)
        {
            gameObject.SetActive(true);
        }
    }

    void HandlePath1ButtonClicked()
    {
        if (level2Menu != null)
        {
            level2Menu.Close();
            level2Menu = null;
        }
        else if (level1Menu != null)
        {
            level1Menu.Close();
            level1Menu = null;
        }
        MenuManager.Instance.previousMenu = _homeMenu;
        MenuManager.Instance.currentMenu = _homeMenu;
        _homeMenu.Open();
        Hide();
    }

    void HandlePath2ButtonClicked()
    {
        if (level2Menu != null)
        {
            MenuManager.Instance.previousMenu = _homeMenu;
            MenuManager.Instance.currentMenu = level1Menu;
            level2Menu.Close();
            level1Menu.Open();
            ShowLevel1Elements();
            level2Menu = null;
        }
    }
}
