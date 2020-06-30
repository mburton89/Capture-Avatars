using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswordManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _hint;
    private bool _hasStartedCoroutine;

    private void Awake()
    {
        _hasStartedCoroutine = false;
    }

    private void OnEnable()
    {
        _inputField.onValueChanged.AddListener(CheckPassword);
    }

    private void OnDisable()
    {
        _inputField.onValueChanged.RemoveListener(CheckPassword);
    }

    void CheckPassword(string text)
    {
        if (_inputField.text == "MCTOnsite" &&  !_hasStartedCoroutine)
        {
            StartCoroutine(Welcome());
            _hasStartedCoroutine = true;
        }
    }

    private IEnumerator Welcome()
    {
        _hint.text = "Welcome Jon Montego";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
