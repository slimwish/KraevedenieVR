using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastInteractive : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;

    [SerializeField] private InputActionProperty _buttonRayInput;

    [SerializeField] private InputActionProperty _buttonSelect;

    [SerializeField] private GameObject _mainGameObject;

    [SerializeField] private XRInteractorLineVisual _lineRenderer; 

    private Interacting _interacting;

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

        if (_interacting != null && _raycast.transform != _interacting.transform)
        {
            _lineRenderer.enabled = false;
            _interacting.InteractStopRay(_mainGameObject);
            _interacting.InteractTriggerStopRay(_mainGameObject);
        }

        if (_raycast.transform != null)
        {
            if (_raycast.transform.gameObject.TryGetComponent<Interacting>(out _interacting))
            {
                _lineRenderer.enabled = true;
                _interacting.InteractRay(_mainGameObject);
            }
        }
        else
        {
            _interacting = null;
        }
    }
}
