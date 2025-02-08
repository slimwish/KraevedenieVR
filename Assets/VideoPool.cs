using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPool : MonoBehaviour
{
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    public VideoPlayer Player;
    public VideoClip VideoClip;

}
