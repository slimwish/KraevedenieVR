using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "ExampleShowUI", menuName = "Example For UI/Create Example Show UI", order = 1)]
public class ExplorerInfo : ScriptableObject
{
    public string Name;
    public string Description;
    public Texture2D MainImage;
    public List<Texture2D> ImageList;
    public VideoClip clip;
}
