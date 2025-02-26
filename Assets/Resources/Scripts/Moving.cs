using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    [SerializeField] private Rigidbody _mainObject;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _deadZoneRegister;
    [SerializeField] private float _sensRotation;
    [SerializeField] private float _speed;
    [SerializeField] private InputActionProperty _mainMoveInput;
    [SerializeField] private InputActionProperty _mainRotationInput;

    private bool _isGetDirection = false;

    private Vector2 _axisVector;

    private Vector3 _movingDirectionForward = Vector3.zero;
    private Vector3 _movingDirectionRight = Vector3.zero;



    private void Update()
    {
        _axisVector = _mainMoveInput.action.ReadValue<Vector2>();
        float rotation = _mainRotationInput.action.ReadValue<Vector2>().x;

        if (_axisVector.x > _deadZoneRegister || _axisVector.x < -_deadZoneRegister || _axisVector.y > _deadZoneRegister || _axisVector.y < -_deadZoneRegister)
        {

            if (_isGetDirection == false)
            {
                _movingDirectionForward = new Vector3(_mainCamera.transform.forward.x, 0, _mainCamera.transform.forward.z);
                _movingDirectionForward.Normalize();

                _movingDirectionRight = new Vector3(_mainCamera.transform.right.x, 0, _mainCamera.transform.right.z);
                _movingDirectionRight.Normalize();

                _isGetDirection = true;
            }
            _mainObject.velocity = ((_axisVector.y * _movingDirectionForward) + (_axisVector.x * _movingDirectionRight)) * _speed;
        }
        else
        {
            _movingDirectionForward = Vector3.zero;
            _movingDirectionRight = Vector3.zero;
            _isGetDirection = false;
        }
        
        if (rotation < -_deadZoneRegister || rotation > _deadZoneRegister)
        {
            _mainObject.transform.Rotate(0, rotation * _sensRotation * 100 * Time.deltaTime, 0, Space.World);

            _movingDirectionForward = new Vector3(_mainCamera.transform.forward.x, 0, _mainCamera.transform.forward.z);
            _movingDirectionForward.Normalize();

            _movingDirectionRight = new Vector3(_mainCamera.transform.right.x, 0, _mainCamera.transform.right.z);
            _movingDirectionRight.Normalize();
        }
        
    }
}
