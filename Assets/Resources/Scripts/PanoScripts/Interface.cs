using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Interface : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _teleportButton;
    [SerializeField] private string _sceneName;
    [SerializeField] private Video _video;
    [SerializeField] private TextMeshProUGUI _currentTime;
    [SerializeField] private TextMeshProUGUI _duration;
    [SerializeField] private EventSystem _events;
    
    private void Start()
    {
        _video.videoPlayer.clip = FindAnyObjectByType<DataBetweenScenes>().Info.clip;
        _pauseButton.onClick.AddListener(delegate { _video.PlayAndPause(); });
        _duration.text = Convert.ToString((int)_video.videoPlayer.length);
    }
    private void Update()
    {
        if (_video.videoPlayer.isPrepared)
        {
            _slider.maxValue = (float)_video.videoPlayer.length;
        }
        
        if (!_video.videoPlayer.isPaused)
        {
            _slider.value = (float)_video.videoPlayer.time;
        }

        _currentTime.text = Convert.ToString((int)_video.videoPlayer.time);
    }
    public void ManuallyChangeTime()
    {
        _video.videoPlayer.Pause();
        _video.videoPlayer.time = _slider.value;
        _video.videoPlayer.Play();
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