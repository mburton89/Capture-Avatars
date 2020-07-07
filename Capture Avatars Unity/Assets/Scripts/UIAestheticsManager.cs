using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAestheticsManager : MonoBehaviour
{
    public static UIAestheticsManager Instance;

    public Color accentColor;
    public Color textHighlightColor;

    public float pressedInScale = 0.95f;
    public float secondsToPressIn = 0.1f;
    public float secondsToUnpress = 0.45f;
    public float secondsToMoveButtons = 0.25f;

    [SerializeField] private List<ButtonGroup> _homeButtons;
    [SerializeField] private List<MenuButton> _appearanceMenuButtons;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < _homeButtons.Count; i++)
        {
            _homeButtons[i].Init(this);
        }

        for (int i = 0; i < _appearanceMenuButtons.Count; i++)
        {
            _appearanceMenuButtons[i].Init(this);
        }
    }

    //TODO: Remove when not testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MoveHomeButtonsOnScreen();
        }
    }

    public void MoveHomeButtonsOffScreen(ButtonGroup buttonClicked)
    {
        StartCoroutine(MoveHomeButtonsOffScreenCo(buttonClicked));
    }

    private IEnumerator MoveHomeButtonsOffScreenCo(ButtonGroup buttonClicked)
    {
        for (int i = 0; i < _homeButtons.Count; i++)
        {
            if (_homeButtons[i] != buttonClicked)
            {
                _homeButtons[i].MoveOffScreen();
            }
        }
        yield return new WaitForSeconds(0.175f);
        buttonClicked.MoveOffScreen();
    }

    public void MoveHomeButtonsOnScreen()
    {
        StartCoroutine(MoveHomeButtonsOnScreenCo());
    }

    private IEnumerator MoveHomeButtonsOnScreenCo()
    {
        for (int i = 0; i < _homeButtons.Count; i++)
        {
            _homeButtons[i].MoveOnScreen();
            yield return new WaitForSeconds(0.05f);
        } 
    }
}
