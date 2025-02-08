using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : Interacting
{
    [SerializeField] MeshRenderer _mesh;
    public override void Interact(GameObject getGameObject)
    {
        
    }
    public override void InteractRay(GameObject getGameObject)
    {
        //_mesh.material.color = Color.red;
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        //_mesh.material.color = Color.white;
    }
    public override void InteractTriggerRay(GameObject getGameObject)
    {
        _mesh.material.color = Color.red;
    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {
        _mesh.material.color = Color.white;
    }
}
