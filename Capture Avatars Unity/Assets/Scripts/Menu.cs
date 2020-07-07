using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private List<UIMovable> _uiMovables;

    public void Open()
    {
        _container.SetActive(true);
        _container.transform.localScale = Vector3.one;
        foreach (UIMovable uIMovable in _uiMovables)
        {
            uIMovable.TweenOnScreen();
        }
    }

    public void Close()
    {
        StartCoroutine(CloseCo());
    }

    private IEnumerator CloseCo()
    {
        foreach (UIMovable uIMovable in _uiMovables)
        {
            uIMovable.TweenOffScreen();
        }
        yield return new WaitForSeconds(UIAestheticsManager.Instance.secondsToMoveButtons);
        _container.SetActive(false);
    }
}
