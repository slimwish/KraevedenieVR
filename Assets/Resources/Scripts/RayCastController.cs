using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastInteractive : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;

    [SerializeField] private InputActionProperty _buttonRayInput;

    [SerializeField] private InputActionProperty _buttonSelect;

    [SerializeField] private GameObject _mainGameObject;

    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private Gradient _lineColor;

    private Interacting _interacting;

    private void Start()
    {
        _lineRenderer.colorGradient = _lineColor;
    }

    private void Update()
    {
        if (_buttonRayInput.action.triggered)
        {
            if(_interacting != null) _interacting.InteractTriggerRay(_mainGameObject);
        }
        if (_buttonSelect.action.triggered)
        {
            if(_interacting != null) _interacting.Interact(_mainGameObject);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit _raycast;

        _interactor.TryGetCurrent3DRaycastHit(out _raycast);
        if (_raycast.transform != null)
        {
            if (_interacting != null && _raycast.transform != _interacting.transform)
            {
                _interacting.InteractStopRay(_mainGameObject);
                _interacting.InteractTriggerStopRay(_mainGameObject);
            }
            if (_interacting == null || _interacting.transform != _raycast.transform)
            {
                if (_raycast.transform.gameObject.TryGetComponent<Interacting>(out _interacting))
                {
                    _interacting.InteractRay(_mainGameObject);
                }
            }
        }
        else
        {
            if (_interacting != null)
            {
                _interacting.InteractStopRay(_mainGameObject);
                _interacting.InteractTriggerStopRay(_mainGameObject);
            }
            _interacting = null;
        }
    }
}