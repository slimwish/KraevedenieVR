using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHandler : Interacting
{
    [SerializeField] GameObject _sphere;

    public override void Interact(GameObject getGameObject)
    {
        getGameObject.transform.position = _sphere.transform.position;
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
