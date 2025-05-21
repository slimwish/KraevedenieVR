using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Portal : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private GameObject _player;

    public void ActivatePortal(bool activate)
    {
        if (activate)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<Collider>().enabled = true;
            activate = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            StartCoroutine(LoadScenePortalAsync());
        }
    }

    public void SetSceneName(string sceneName)
    {
        _sceneName = sceneName;
    }

    private IEnumerator LoadScenePortalAsync()
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
