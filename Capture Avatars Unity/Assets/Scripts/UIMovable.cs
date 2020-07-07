using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIMovable : MonoBehaviour
{
    [SerializeField] private Vector3 _hiddenPosition;
    [SerializeField] private Vector3 _visiblePosition;

    [SerializeField] private GameObject _container;
    [SerializeField] private List<Image> _images;
    [SerializeField] private List<TextMeshProUGUI> _texts;
    [SerializeField] private Image _raycastTarget;

    public void TweenOffScreen()
    {
        float duration = UIAestheticsManager.Instance.secondsToMoveButtons;
        _container.transform.DOLocalMove(_hiddenPosition, duration);
        foreach (Image image in _images)
        {
            image.DOFade(0, duration);
        }
        foreach (TextMeshProUGUI text in _texts)
        {
            text.DOFade(0, duration);
        }

        _raycastTarget.raycastTarget = false;
    }

    public void TweenOnScreen()
    {
        MoveOffScreenImmediatley();
        float duration = UIAestheticsManager.Instance.secondsToMoveButtons;
        _container.transform.DOLocalMove(_visiblePosition, duration);
        foreach (Image image in _images)
        {
            image.DOFade(1, duration);
        }
        foreach (TextMeshProUGUI text in _texts)
        {
            text.DOFade(1, duration);
        }

        _raycastTarget.raycastTarget = true;
    }

    public void MoveOffScreenImmediatley()
    {
        _container.transform.localPosition = _hiddenPosition;
        foreach (Image image in _images)
        {
            image.DOFade(0, 0);
        }
        foreach (TextMeshProUGUI text in _texts)
        {
            text.DOFade(0, 0);
        }

        _raycastTarget.raycastTarget = false;
    }
}
