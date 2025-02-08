using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "ExampleShowUI", menuName = "Example For UI/Create Example Show UI", order = 1)]
public class ExplorerInfo : ScriptableObject
{
    public string Name;
    public List<TextMeshPro> Text;
    public List<Texture2D> Images;
}
