using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanoTourInterface : MonoBehaviour
{
    [SerializeField] private InputActionProperty _menuButton;
    [SerializeField] private string _sceneName;
    private bool _status = false;

    private void Start()
    {
        _menuButton.action.started += ButtonWasPressed;
    }
    void ButtonWasPressed(InputAction.CallbackContext context)
    {
        gameObject.SetActive(_status);
        _status = !_status;
    }
    public void LoadScene()
    {
        StartCoroutine(LoadSceneTerminalAsync());
    }
    private IEnumerator LoadSceneTerminalAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            operation.allowSceneActivation = true;
            yield return null;
        }
    }
}
