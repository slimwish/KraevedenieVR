using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : Interacting
{
    [SerializeField] private Animator _clip;
    [SerializeField] private MeshRenderer _mesh;

    private bool _isActive;

    public override void InteractRay(GameObject getGameObject)
    {
        if(_isActive == false) _mesh.material.color = Color.red;
    }
    public override void InteractStopRay(GameObject getGameObject)
    {
        _mesh.material.color = Color.white;
    }
    public override void Interact(GameObject getGameObject)
    {
        if (_clip.enabled)
        {
            _clip.Play("New Animation");
        } 
        else _clip.StopPlayback();
    }

    public override void InteractTriggerRay(GameObject getGameObject)
    {
        
    }

    public override void InteractTriggerStopRay(GameObject getGameObject)
    {
    
    }
}
