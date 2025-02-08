using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class Interface : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _button;
    [SerializeField] private Video _video;
    [SerializeField] private TextMeshProUGUI _currentTime;
    [SerializeField] private TextMeshProUGUI _duration;
    [SerializeField] private EventSystem _events;
    
    private void Start()
    {
        _button.onClick.AddListener(delegate { _video.PlayAndPause(); });
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
}