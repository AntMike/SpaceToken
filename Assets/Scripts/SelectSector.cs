using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.Galaxy.Sectors
{
public class SelectSector : MonoBehaviour
{
    private MeshFilter _filter;
    private TargetData _target;
    
    // Start is called before the first frame update
    void Start()
    {
        _filter = GetComponent<MeshFilter>();
        _target = GetComponent<TargetData>();
    }

    private void OnMouseUp()
    {
        SectorSelectionController.Instantiate.SelectSector(_target, _filter.mesh);
    }
}
    
}
