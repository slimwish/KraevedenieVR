using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : Interacting
{
    [SerializeField] MeshRenderer _mesh;
    public override void Interact()
    {
        
    }
    public override void InteractRay()
    {
        //_mesh.material.color = Color.red;
    }
    public override void InteractStopRay()
    {
        //_mesh.material.color = Color.white;
    }
    public override void InteractTriggerRay()
    {
        _mesh.material.color = Color.red;
    }
    public override void InteractTriggerStopRay()
    {
        _mesh.material.color = Color.white;
    }
}
