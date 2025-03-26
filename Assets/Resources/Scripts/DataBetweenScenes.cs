using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataBetweenScenes : MonoBehaviour
{
    public ExplorerInfo Info;
   

    public ExplorerInfo ReadInfo()
    {
        return Info;
    }
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
