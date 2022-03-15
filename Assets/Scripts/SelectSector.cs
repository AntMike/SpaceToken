using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.Galaxy.Sectors
{
public class SelectSector : MonoBehaviour
{
    private MeshRenderer _renderer;
    private MeshFilter _filter;
    private TargetData _target;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _filter = GetComponent<MeshFilter>();
        _target = GetComponent<TargetData>();
    }

    /// <summary>
    /// Change material on hover
    /// </summary>
    /*private void OnMouseEnter()
    {
        _renderer.material = selectedMaterial;
    }

    private void OnMouseExit()
    {
        _renderer.material = defaultMaterial;
    }*/

    private void OnMouseUp()
    {
        SectorSelectionController.Instantiate.SelectSector(_target, _filter.mesh, _renderer.material);
    }
}
    
}
