using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTerminal : Interacting
{
    [SerializeField] private AnimationClip _animClip;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _activeMaterial;
    
    public AnimationClip GetClip => _animClip;
    public Material GetBaseMaterial => _baseMaterial;
    public Material GetActiveMaterial => _activeMaterial;

    public override void Interact(GameObject getGameObject)
    {
        
    }
    public override void InteractRay(GameObject getGameObject)
    {
       
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        
    }
    public override void InteractTriggerRay(GameObject getGameObject)
    {
        
    }
    public override void InteractTriggerStopRay(GameObject getGameObject)
    {
        
    }
}
