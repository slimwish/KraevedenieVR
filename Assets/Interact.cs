using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public abstract class Interacting : MonoBehaviour
{
    public abstract void Interact();
    public abstract void InteractRay();
    public abstract void InteractStopRay();
    public abstract void InteractTriggerRay();
    public abstract void InteractTriggerStopRay();
}
