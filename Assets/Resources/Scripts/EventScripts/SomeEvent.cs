using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SomeEvent : TargetMain
{
    [SerializeField] private GameObject _infoOnCanvas;
    [SerializeField] private Button _teleportButton;

    [SerializeField] private List<GameObject> _regionTargets;
    [SerializeField] private GameObject _map;

    [SerializeField] private CanvasHandler _canvasHandler;

    [SerializeField] private string _nameText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private Sprite _sprite;

    private Vector3 _defaultPositionOnMap;
    public Vector3 defaultPositionOnMap => _defaultPositionOnMap;

    private void Start()
    {
        _defaultPositionOnMap = transform.localPosition;
    }
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
