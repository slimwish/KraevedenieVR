using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Video;


public class ToPanorama : TargetTerminal
{
    [SerializeField] private VideoPool _pool;
    [SerializeField] private VideoClip _clip;
    [SerializeField] private MeshRenderer _circlePortal;
    [SerializeField] private Portal _portal;
    public override void Interact(GameObject getGameObject)
    {
        _pool.VideoClip = _clip;
        _portal.ActivePortal();
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
