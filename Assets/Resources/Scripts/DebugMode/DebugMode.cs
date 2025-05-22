using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class DebugMode : MonoBehaviour
{
    [SerializeField] GameObject _mainObject;
    [SerializeField] GameObject _camera;

    [SerializeField] Rigidbody _rb;

    [SerializeField] InputActionProperty _WASD;
    [SerializeField] InputActionProperty _mousLock;
    [SerializeField] InputActionProperty _mouseDelta;

    [SerializeField] float _speed;
    [SerializeField] float _sense;

    [SerializeField] bool _stateActive;

    private bool _cursorLock = false;

    private Vector2 _rotation = new Vector2(0, 0);

    private void OnEnable()
    {
        _mousLock.action.performed += ChangeLockState;
        _WASD.action.actionMap.Enable();
        _mousLock.action.actionMap.Enable();
    }

    private void OnDisable()
    {
        _mousLock.action.performed -= ChangeLockState;
        _WASD.action.actionMap.Disable();
        _mousLock.action.actionMap.Disable();
    }

    private void ChangeLockState(InputAction.CallbackContext ctx)
    {
        if (UnityEngine.Cursor.lockState == CursorLockMode.Locked) UnityEngine.Cursor.lockState = CursorLockMode.None;
        else UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
        Move();
    }
    private void Move()
    {
        _rb.velocity = Vector3.zero;

        Vector2 moving = _WASD.action.ReadValue<Vector2>();
        Vector3 forward = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z).normalized.normalized * moving.y;
        Vector3 right = new Vector3(_camera.transform.right.x, 0, _camera.transform.right.z).normalized * moving.x;
        Vector3 final = (forward + right).normalized;

        _rb.AddForce(final.x, 0, final.z, ForceMode.VelocityChange);
    }
    private void Rotate()
    {
        Vector2 mouseDelta = _mouseDelta.action.ReadValue<Vector2>();

        _rotation.x -= mouseDelta.y / 10;
        _rotation.y += mouseDelta.x / 10;

        _rotation.x = Mathf.Clamp(_rotation.x, -89, 89);

        _camera.transform.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
        _mainObject.transform.rotation = Quaternion.Euler(0, _rotation.y, 0);
    }
}