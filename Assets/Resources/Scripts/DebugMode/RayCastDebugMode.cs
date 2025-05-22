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

public class RayCastDebugMode : MonoBehaviour
{
    [SerializeField] private Camera _camera;

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

        Ray _ray = new Ray(_camera.transform.position, _camera.transform.forward);

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;

        // Создаем список результатов
        List<RaycastResult> results = new List<RaycastResult>();

        // Выполняем рейкаст
        EventSystem.current.RaycastAll(pointerData, results);

        if (Physics.Raycast(_ray, out _raycast, 100))
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