using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;
    [SerializeField] private InputActionProperty _input;
    private Interacting _interacting;
    private Interacting _interactingBefore;

    private void FixedUpdate()
    {
        if (_input.action.triggered)
        {
            RaycastHit _raycast;

            _interactor.TryGetCurrent3DRaycastHit(out _raycast);

            if (_raycast.transform != null)
            {
                if (_raycast.transform.gameObject.TryGetComponent<Interacting>(out _interacting))
                {
                    _interacting.InteractRay();
                }
            }

            else if (_interacting != null)
            {
                _interacting.InteractStopRay();
            }
        }
    }
}
