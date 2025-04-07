using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastInteractive : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;

    [SerializeField] private InputActionProperty _buttonSelect;

    [SerializeField] private GameObject _mainGameObject;

    private Interacting _interacting;

    private void Update()
    {
        if (_buttonSelect.action.triggered)
        {
            if (_interacting != null) _interacting.Interact(_mainGameObject);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit _raycast;

        RaycastResult _raycastResult;

        _interactor.TryGetCurrentUIRaycastResult(out _raycastResult);
        _interactor.TryGetCurrent3DRaycastHit(out _raycast);

        if (_raycastResult.gameObject != null && (_raycast.transform == null || _raycast.distance < _raycastResult.distance))
        {
            if (_interacting != null && _raycastResult.gameObject.transform != _interacting.transform)
            {
                _interacting.InteractStopRay(_mainGameObject);
            }
            if (_interacting == null || _interacting.transform != _raycastResult.gameObject.transform)
            {
                if (_raycastResult.gameObject.TryGetComponent<Interacting>(out _interacting))
                {
                    _interacting.InteractRay(_mainGameObject);
                }
            }
        }
        else if(_raycast.transform != null)
        {
            if (_interacting != null && _raycast.transform != _interacting.transform)
            {
                _interacting.InteractStopRay(_mainGameObject);
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
            }
            _interacting = null;
        }
    }
}