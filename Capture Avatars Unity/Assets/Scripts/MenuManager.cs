using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private HomeMenu _homeMenu;
    [SerializeField] private ClosetMenu _closetMenu;
    [SerializeField] private ToggleMenu _closetTopsMenu;

    [HideInInspector] public Menu previousMenu;
    [HideInInspector] public Menu currentMenu;

    [SerializeField] private PathMenu _pathMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentMenu = _homeMenu;
        _homeMenu.Open();
    }

    public void OpenHomeMenu()
    {
        currentMenu.Close();
        previousMenu = currentMenu;
        _homeMenu.Open();
        currentMenu = _homeMenu;
    }

    public void OpenClosetMenu()
    {
        currentMenu.Close();
        previousMenu = currentMenu;
        _closetMenu.Open();
        currentMenu = _closetMenu;
    }

    public void OpenClosetTopsMenu()
    {
        currentMenu.Close();
        previousMenu = currentMenu;
        _closetTopsMenu.Open();
        currentMenu = _closetTopsMenu;
    }

    public void OpenMenu(Menu menuToOpen)
    {
        StartCoroutine(OpenMenuCo(menuToOpen));
        _pathMenu.AssignCurrentMenu(menuToOpen);
    }

    private IEnumerator OpenMenuCo(Menu menuToOpen)
    {
        currentMenu.Close();
        previousMenu = currentMenu;
        yield return new WaitForSeconds(UIAestheticsManager.Instance.secondsToMoveButtons);
        currentMenu = menuToOpen;
        currentMenu.Open();   
    }

    public void OpenMenu(Menu menuToOpen, UIMovable uIMovable)
    {
        StartCoroutine(OpenMenuCo(menuToOpen, uIMovable));
        _pathMenu.AssignCurrentMenu(menuToOpen);
    }

    private IEnumerator OpenMenuCo(Menu menuToOpen, UIMovable uIMovable)
    {
        currentMenu.Close(uIMovable);
        previousMenu = currentMenu;
        yield return new WaitForSeconds(UIAestheticsManager.Instance.secondsToMoveButtons * 2);
        currentMenu = menuToOpen;
        currentMenu.Open();
    }

    public void GoBack()
    {
        StartCoroutine(OpenMenuCo(previousMenu));
    }
}
