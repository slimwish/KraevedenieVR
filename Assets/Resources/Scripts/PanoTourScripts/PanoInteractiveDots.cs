using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoInteractiveDots : Interacting
{
    [SerializeField] private AnimationClip _animClip;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _activeMaterial;
    [SerializeField] private DotsHandler _dotsHandler;


    public override void Interact(GameObject getGameObject)
    {
        foreach (GameObject dot in _dotsHandler.dots)
        {
            Instantiate(dot);
        }
        Destroy(gameObject);
    }

    public override void InteractRay(GameObject getGameObject)
    {

    }

    public override void InteractStopRay(GameObject getGameObject)
    {
        
    }

    public override void InteractTriggerRay(GameObject getGameObject)
    {
        throw new System.NotImplementedException();
    }

    public override void InteractTriggerStopRay(GameObject getGameObject)
    {
        throw new System.NotImplementedException();
    }
}
