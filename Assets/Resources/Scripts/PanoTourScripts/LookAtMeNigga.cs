using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMeNigga : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    void Update()
    {
        transform.LookAt(_playerCamera.transform.position);
    }
}
