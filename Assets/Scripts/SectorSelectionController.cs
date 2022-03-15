using System;
using System.Collections;
using System.Collections.Generic;
using SpaceToken.Galaxy.Sectors;
using SpaceToken.UI;
using UnityEngine;

namespace SpaceToken.Galaxy
{
    public class SectorSelectionController : MonoBehaviour
    {

        public static SectorSelectionController Instantiate;

        [SerializeField] private SectorUIInfoController uiInfoController;
        
        private MeshRenderer _meshRenderer;
        private MeshFilter _meshFilter;

        private void Awake()
        {
            if (Instantiate == null)
            {
                Instantiate = this;
            }
            else
            {
                Destroy(this);
            }
        }


        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshFilter = GetComponent<MeshFilter>();
        }

        public void SelectSector(TargetData target, Mesh mesh, Material material)
        {
            var newMesh = new Mesh
            {
                bounds = mesh.bounds,
                vertices = mesh.vertices,
                triangles = mesh.triangles,
                uv = mesh.uv,
                normals = mesh.normals
            };
            var vertices = newMesh.vertices;

            var diff = GetMeshMidPoint(vertices);

            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] -= diff;
            }

            newMesh.vertices = vertices;

            _meshFilter.mesh = newMesh;
            _meshRenderer.material = material;
            _meshRenderer.enabled = true;
            uiInfoController.SetSectorData(target.id);
        }

        public void HideSector()
        {
            _meshRenderer.enabled = false;
            uiInfoController.HideSectorData();
        }

        private Vector3 GetMeshMidPoint(Vector3[] vertices)
        {
            float maxX = float.MinValue;
            float maxZ = float.MinValue;
            float minX = float.MaxValue;
            float minZ = float.MaxValue;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (maxX < vertices[i].x)
                {
                    maxX = vertices[i].x;
                }

                if (maxZ < vertices[i].z)
                {
                    maxZ = vertices[i].z;
                }

                if (minX > vertices[i].x)
                {
                    minX = vertices[i].x;
                }

                if (minZ > vertices[i].z)
                {
                    minZ = vertices[i].z;
                }
            }

            return new Vector3(minX + ((maxX - minX) / 2), 0, minZ + ((maxZ - minZ) / 2));
        }
    }
}