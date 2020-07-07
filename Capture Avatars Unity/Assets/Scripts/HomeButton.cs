using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeButton : HighlightButton
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Image _icon;
    private Vector3 _initialLocalPosition;

}
