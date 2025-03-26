using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SomeEvent : Interacting
{
    [SerializeField] private GameObject _infoOnCanvas;
    [SerializeField] private Button _teleportButton;
    [SerializeField] private Button _teleportTourButton;

    [SerializeField] private List<GameObject> _regionTargets;
    [SerializeField] private GameObject _map;

    [SerializeField] private CanvasHandler _canvasHandler;

    [SerializeField] private string _nameText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private AnimationClip _animClip;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _activeMaterial;
    [SerializeField] private ExplorerInfo _target;
    [SerializeField] private Canvas _canvas;

    private Vector3 _defaultPositionOnMap;
    public Vector3 defaultPositionOnMap => _defaultPositionOnMap;

    private void Start()
    {
        _defaultPositionOnMap = transform.localPosition;
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
        for (int i = 0; i < _map.transform.childCount; i++)
        {
            _map.transform.GetChild(i).gameObject.SetActive(false);  // ���������� �� ��������� ��������
            _map.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().enabled = false;  // ���������� ����������� Ray � ������ ����� ��������� ��������
            _map.transform.GetChild(i).transform.localPosition = Vector3.zero;  // �������� ������� � �����
        }
        gameObject.SetActive(true); // ��������� ���������� �������

        for (int i = 0; i < _infoOnCanvas.transform.childCount; i++) // ��������� ���������� � ������� �� �������
        {
            _infoOnCanvas.transform.GetChild(i).gameObject.SetActive(true);
        }

        _teleportButton.gameObject.SetActive(false); // ���������� ������ ��������� � �������� ���� ������ ������� �� ������������
        _teleportTourButton.gameObject.SetActive(false);

        _canvasHandler.SetInfo(_nameText, _descriptionText, _sprite); // ����������� ������ � ����������� �� ������

        foreach (GameObject targets in _regionTargets) // ��������� ��������
        {
            targets.SetActive(true);
        }
    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {
        
    } 
}
