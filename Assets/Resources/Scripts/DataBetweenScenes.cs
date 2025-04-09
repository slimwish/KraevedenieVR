using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class DataBetweenScenes : MonoBehaviour
{
    public VideoClip Clip;
   
    private void Awake()
    {
        DontDestroyOnLoad(this);
        foreach (DataBetweenScenes obj in FindObjectsOfType<DataBetweenScenes>())
        {
            if (this != obj)
            {
                Destroy(obj);
            }
        }
    }
}
