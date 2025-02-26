using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetEvent : TargetMain
{
    [SerializeField] private Button _teleportButton;

    [SerializeField] private CanvasHandler _canvasHandler;

    [SerializeField] private string _nameText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private Sprite _sprite;

    public override void Interact(GameObject getGameObject)
    {

    }
    public override void InteractRay(GameObject getGameObject)
    {
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material = gameObject.GetComponent<TargetMain>().GetActiveMaterial;
        }
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material = gameObject.GetComponent<TargetMain>().GetBaseMaterial;
        }
    }
    public override void InteractTriggerRay(GameObject getGameObject)
    {
        _teleportButton.gameObject.SetActive(true); // включение кнопачке для включение портала
        _canvasHandler.SetInfo(_nameText, _descriptionText, _sprite); // выставление текста и изображение на канвас
    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {

    }
}
