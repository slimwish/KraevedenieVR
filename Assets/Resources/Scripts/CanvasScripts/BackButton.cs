using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _infoOnCanvas;
    // [SerializeField] private Button _teleportButton;
    [SerializeField] private Button _teleportTourButton;

    [SerializeField] private List<GameObject> _allTargets;
    [SerializeField] private GameObject _map;
    [SerializeField] private Portal _portal;

    public void backButton() // логика, обратная SomeEvent.InteractTriggerRay
    {
        for (int i = 0; i < _map.transform.childCount; i++)
        {
            _map.transform.GetChild(i).gameObject.SetActive(true);
            _map.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().enabled = true;
            _map.transform.GetChild(i).transform.localPosition = _map.transform.GetChild(i).GetComponent<SomeEvent>().defaultPositionOnMap;
        }

        for (int i = 0; i < _infoOnCanvas.transform.childCount; i++)
        {
            _infoOnCanvas.transform.GetChild(i).gameObject.SetActive(false);
        }

        // _teleportButton.gameObject.SetActive(false);
        _teleportTourButton.gameObject.SetActive(false);

        foreach (GameObject targets in _allTargets)
        {
            targets.SetActive(false);
        }

        _portal.ActivatePortal(false); // деактивация портала
    }
}
