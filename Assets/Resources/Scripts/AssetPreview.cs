using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AssetImageLoader : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        _image.sprite = Sprite.Create(AssetPreview.GetAssetPreview(_prefab), _image.rectTransform.rect, _image.rectTransform.pivot);
    }
}
