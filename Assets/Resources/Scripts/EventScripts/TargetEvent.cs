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
    [SerializeField] private ExplorerInfo _explorerInfo;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _baseMaterial;
    }
    public override void Interact(GameObject getGameObject)
    {
        _teleportButton.gameObject.SetActive(true); // ��������� �������� ��� ��������� �������
        _teleportTourButton.gameObject.SetActive(true);
        _canvasHandler.SetInfo(_nameText, _descriptionText, _sprite); // ����������� ������ � ����������� �� ������
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
