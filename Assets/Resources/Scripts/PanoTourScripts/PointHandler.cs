using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHandler : Interacting
{
    [SerializeField] GameObject _sphere;
    [SerializeField] Image _image;
    [SerializeField] Color _disabled;
    [SerializeField] Color _enabled;

    public override void Interact(GameObject getGameObject)
    {
        getGameObject.transform.position = _sphere.transform.position;
    }

    public override void InteractRay(GameObject getGameObject)
    {
        _image.color = _enabled;
    }

    public override void InteractStopRay(GameObject getGameObject)
    {
        _image.color = _disabled;
    }
}
