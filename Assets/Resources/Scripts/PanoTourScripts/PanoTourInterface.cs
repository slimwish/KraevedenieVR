using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanoTourInterface : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;

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
