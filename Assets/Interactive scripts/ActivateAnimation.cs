using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : Interacting
{
    [SerializeField] private Animator _clip;
    [SerializeField] private MeshRenderer _mesh;

    private bool _isActive;

    public override void InteractRay()
    {
        if(_isActive == false) _mesh.material.color = Color.red;
    }
    public override void InteractStopRay()
    {
        _mesh.material.color = Color.white;
    }
    public override void Interact()
    {
        if (_clip.enabled)
        {
            _clip.Play("New Animation");
        } 
        else _clip.StopPlayback();
    }

    public override void InteractTriggerRay()
    {
        
    }

    public override void InteractTriggerStopRay()
    {
    
    }
}
