using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIPressHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _pressedInScale;
    [SerializeField] private float _secondsToPressIn;
    [SerializeField] private float _secondsToUnpress;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(_pressedInScale, _secondsToPressIn);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(1, _secondsToUnpress);
    }
}
