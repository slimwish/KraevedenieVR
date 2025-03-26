using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetEvent : Interacting
{
    [SerializeField] private Button _teleportButton;
    [SerializeField] private Button _teleportTourButton;

    [SerializeField] private CanvasHandler _canvasHandler;

    [SerializeField] private string _nameText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private AnimationClip _animClip;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _activeMaterial;
    [SerializeField] private ExplorerInfo _target;
    [SerializeField] private Canvas _canvas;
    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _baseMaterial;
    }
    public override void Interact(GameObject getGameObject)
    {

    }
    public override void InteractRay(GameObject getGameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material = _activeMaterial;
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material = _baseMaterial;
    }
    public override void InteractTriggerRay(GameObject getGameObject)
    {
        _teleportButton.gameObject.SetActive(true); // включение кнопачке для включение портала
        _teleportTourButton.gameObject.SetActive(true);
        _canvasHandler.SetInfo(_nameText, _descriptionText, _sprite); // выставление текста и изображение на канвас
    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {

    }
}
