using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _teleportButton;

    public void SetInfo(string nameText, string descriptionText, Sprite sprite)
    {
        _name.text = nameText;
        _description.text = descriptionText;
        _image.sprite = sprite;
    }
    public void SetTeleportButtonInfo(string teleportButtonText)
    {
        _teleportButton.text = teleportButtonText;
    }
}
