using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHandler : Interacting
{
    [SerializeField] GameObject _sphere;
    [SerializeField] Image _image;

    public override void Interact(GameObject getGameObject)
    {
        getGameObject.transform.position = _sphere.transform.position;
    }

    public override void InteractRay(GameObject getGameObject)
    {
        _image.color = new Color(255, 255, 255, 1);
    }

    public override void InteractStopRay(GameObject getGameObject)
    {
        _image.color = new Color(150, 150, 150, 0.7f);
    }

    public override void InteractTriggerRay(GameObject getGameObject)
    {

    }

    public override void InteractTriggerStopRay(GameObject getGameObject)
    {

    }
}
