using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainTerminalUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro _name;
    [SerializeField] private TextMeshPro _desc;

    public TextMeshPro Name => _name;
    public TextMeshPro Desc => _desc;
}
