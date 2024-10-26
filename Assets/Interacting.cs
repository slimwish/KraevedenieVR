using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interacting : MonoBehaviour
{
    public abstract void Interact();
    public abstract void InteractRay();
    public abstract void InteractStopRay();
}
