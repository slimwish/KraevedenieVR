using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{
    [SerializeField] private GameObject _mainObject;

    [SerializeField] private InputActionProperty _mainRotationInput;

    [SerializeField] private float _sensRotation;
    [SerializeField] private float _deadZoneRegister;

    private bool _rotationWasHappened;

    public bool RotationWasHappened => _rotationWasHappened;

    void Update()
    {
        float rotation = _mainRotationInput.action.ReadValue<Vector2>().x;
        if (rotation < -_deadZoneRegister || rotation > _deadZoneRegister)
        {
            _rotationWasHappened = true;
            _mainObject.transform.Rotate(0, rotation * _sensRotation * 100 * Time.deltaTime, 0, Space.World);
        }
        _rotationWasHappened = _rotationWasHappened ? false : true;
    }
    
}
