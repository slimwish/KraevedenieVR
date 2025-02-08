using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Portal : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    [SerializeField] private string _playerName;

    //[SerializeField] private Collider

    public void ActivePortal()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == _playerName)
        {
            StartCoroutine(LoadScenePortalAsync());
        }
    }

    private IEnumerator LoadScenePortalAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);
        
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            
        }

        yield return null;
    }
}
