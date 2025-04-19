using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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

    [SerializeField] private VideoClip _video;

    [SerializeField] private GameObject _artefact;

    [SerializeField] private ArtefactSpawner _spawner;

    private DataBetweenScenes _dataBetweenScenes;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _baseMaterial;
        _dataBetweenScenes = FindFirstObjectByType<DataBetweenScenes>();
    }
    public override void Interact(GameObject getGameObject)
    {
        _teleportButton.gameObject.SetActive(true); // включение кнопачке для включение портала
        _teleportTourButton.gameObject.SetActive(true);
        _canvasHandler.SetInfo(_nameText, _descriptionText, _sprite); // выставление текста и изображение на канвас
        _dataBetweenScenes.Clip = _video;
        _spawner.DestroyArtefact();
        _spawner.SetArtefact(_artefact);
        _spawner.SpawnArtefact();
    }
    public override void InteractRay(GameObject getGameObject)
    {
        GetComponent<MeshRenderer>().material = _activeMaterial;
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        GetComponent<MeshRenderer>().material = _baseMaterial;
    }
}
