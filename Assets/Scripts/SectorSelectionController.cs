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
        private Vector3 _initialPosition;

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

            _initialPosition = transform.localPosition;
        }

        public void SelectSector(TargetData target, Mesh mesh)
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
            _meshRenderer.enabled = true;
            uiInfoController.SetSectorData(target.id, target.data);
        }

        public void HideSector()
        {
            _meshRenderer.enabled = false;
            uiInfoController.HideSectorData();
        }

        
        /// <summary>
        /// Return mid point for the mesh by x and Y axis
        /// </summary>
        private Vector3 GetMeshMidPoint(Vector3[] vertices)
        {
            float maxX = float.MinValue;
            float maxY = float.MinValue;
            float minX = float.MaxValue;
            float minY = float.MaxValue;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (maxX < vertices[i].x)
                {
                    maxX = vertices[i].x;
                }

                if (maxY < vertices[i].y)
                {
                    maxY = vertices[i].y;
                }

                if (minX > vertices[i].x)
                {
                    minX = vertices[i].x;
                }

                if (minY > vertices[i].y)
                {
                    minY = vertices[i].y;
                }
            }

            return new Vector3(minX + ((maxX - minX) / 2), minY + ((maxY - minY) / 2), 0 );
        }
    }
}