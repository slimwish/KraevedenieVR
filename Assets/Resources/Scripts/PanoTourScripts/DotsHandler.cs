using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _dots;
    [SerializeField] private Texture2D _sphereTexture;
    public List<GameObject> dots => _dots;
    public Texture2D sphereTexture => _sphereTexture;
}
