using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private HomeMenu _homeMenu;
    [SerializeField] private ClosetMenu _closetMenu;
    [SerializeField] private ToggleMenu _closetTopsMenu;

    private Menu _previousMenu;
    private Menu _previousPreviousMenu;
    private Menu _currentMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentMenu = _homeMenu;
        _homeMenu.Open();
    }

    public void OpenHomeMenu()
    {
        _currentMenu.Close();
        _previousMenu = _currentMenu;
        _homeMenu.Open();
        _currentMenu = _homeMenu;
    }

    public void OpenClosetMenu()
    {
        _currentMenu.Close();
        _previousMenu = _currentMenu;
        _closetMenu.Open();
        _currentMenu = _closetMenu;
    }

    public void OpenClosetTopsMenu()
    {
        _currentMenu.Close();
        _previousMenu = _currentMenu;
        _closetTopsMenu.Open();
        _currentMenu = _closetTopsMenu;
    }

    public void OpenMenu(Menu menuToOpen)
    {
        StartCoroutine(OpenMenuCo(menuToOpen));
    }

    private IEnumerator OpenMenuCo(Menu menuToOpen)
    {
        _currentMenu.Close();
        _previousMenu = _currentMenu;
        yield return new WaitForSeconds(UIAestheticsManager.Instance.secondsToMoveButtons);
        _currentMenu = menuToOpen;
        _currentMenu.Open();   
    }

    public void GoBack()
    {
        StartCoroutine(OpenMenuCo(_previousMenu));
    }
}
