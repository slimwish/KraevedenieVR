using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : TargetTerminal
{
    [SerializeField] private GameObject TextBlock;

    public override void Interact(GameObject getGameObject)
    {
        TextBlock.SetActive(true);
        
    }
    public override void InteractRay(GameObject getGameObject)
    {
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material = GetActiveMaterial;
        }
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.material = GetBaseMaterial;
        }
    }
    public override void InteractTriggerRay(GameObject getGameObject)
    {

    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {

    }
}
