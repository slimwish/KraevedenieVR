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

    private Interacting _interacting;
    private void Update()
    {
        if (_buttonRayInput.action.triggered)
        {
            if(_interacting != null) _interacting.InteractTriggerRay();
        }
        if (_buttonSelect.action.triggered)
        {
            if(_interacting != null) _interacting.Interact();
        }
    }

    private void FixedUpdate()
    {
            RaycastHit _raycast;

            _interactor.TryGetCurrent3DRaycastHit(out _raycast);

            if (_interacting != null && _raycast.transform != _interacting.transform)
            {
                _interacting.InteractStopRay();
                _interacting.InteractTriggerStopRay();
            }

            if (_raycast.transform != null)
            {
                if (_raycast.transform.gameObject.TryGetComponent<Interacting>(out _interacting))
                {
                        _interacting.InteractRay();
                }
            }
    }
}
