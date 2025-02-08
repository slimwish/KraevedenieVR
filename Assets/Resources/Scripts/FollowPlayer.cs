using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _radiusFromPlayer;
    [SerializeField] private float _underCameraStep;
    [SerializeField] private float _deadZonePos;

    bool _isAnimate = false;
    void Update()
    {
        Vector3 point = new Vector3(_playerCamera.transform.forward.x, 0, _playerCamera.transform.forward.z) * _radiusFromPlayer;
        //point = new Vector3(point.x, _playerCamera.transform.position.y, point.z);
        Vector3 newPosition = point + new Vector3(_playerCamera.transform.position.x, _playerCamera.transform.position.y - _underCameraStep, _playerCamera.transform.position.z);
        if (Vector3.Distance(newPosition, transform.position) >= _deadZonePos || _isAnimate)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, (Time.deltaTime * 3)), Mathf.Lerp(transform.position.y, newPosition.y, (Time.deltaTime * 3)), Mathf.Lerp(transform.position.z, newPosition.z, (Time.deltaTime * 3)));
            _isAnimate = true;
            if (Vector3.Distance(newPosition, transform.position) <= _deadZonePos * 0.05f)
            {
                _isAnimate = false; 
            }
        }
        transform.LookAt(_playerCamera.transform.position);
    }
}
