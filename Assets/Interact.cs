using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public abstract class Interacting : MonoBehaviour
{
    public abstract void Interact(GameObject getGameObject);
    public abstract void InteractRay(GameObject getGameObject);
    public abstract void InteractStopRay(GameObject getGameObject);
    public abstract void InteractTriggerRay(GameObject getGameObject);
    public abstract void InteractTriggerStopRay(GameObject getGameObject);
}
