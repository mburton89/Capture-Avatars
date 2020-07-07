using System.Collections;
using UnityEngine;
using TMPro;

public class DebugConsole : MonoBehaviour
{
    public static DebugConsole Instance;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCo(message));
    }

    private IEnumerator ShowMessageCo(string message)
    {
        _text.SetText(message);
        yield return new WaitForSeconds(3);
        _text.SetText("");
    }
}
