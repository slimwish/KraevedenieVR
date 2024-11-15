using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;
    [SerializeField] private InputActionProperty _triggerInput;
    private Interacting _interacting;

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
                    if (_triggerInput.action.triggered)
                    {
                        _interacting.InteractTriggerRay();
                    }
                    else
                    {
                        _interacting.InteractRay();
                    }
                }
            }
    }
}
