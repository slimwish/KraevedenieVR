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
    public List<InfoText> Text;
    public List<InfoImage> Image;
    public VideoClip clip;
}

[Serializable]
public class InfoText
{
    public int Index;
    public string Text;
}

[Serializable]
public class InfoImage
{
    public int Index;
    public Texture2D Image;
}