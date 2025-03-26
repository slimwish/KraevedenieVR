using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject canvas;
    public InputActionProperty menuButton;

    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
