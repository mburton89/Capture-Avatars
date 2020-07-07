using UnityEngine;
using UnityEngine.UI;

public class SelectableShirt : MonoBehaviour
{
    [HideInInspector] public Color shirtColor;

    private void Start()
    {
        shirtColor = GetComponent<Image>().color;
    }
}
