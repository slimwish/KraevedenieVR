using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactSpawner : MonoBehaviour
{
    private GameObject _artefact;
    private GameObject _createdArtifact;

    public void SetArtefact(GameObject artefact)
    {
        _artefact = artefact;
    }
    public void SpawnArtefact()
    {
        if (_artefact != null)
        {
            _createdArtifact = Instantiate(_artefact, transform);
        }
    }
    public void DestroyArtefact()
    {
        if (_artefact != null)
        {
            Destroy(_createdArtifact);
        }
    }
}
