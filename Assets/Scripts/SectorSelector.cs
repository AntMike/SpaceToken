using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.Galaxy
{
    public class SectorSelector : MonoBehaviour
    {
        [SerializeField] private Camera camera;

        [SerializeField] private List<TargetData> targets;
        
        private int _sectorLayer = LayerMask.GetMask("Sectors");

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera.ScreenPointToRay((Input.mousePosition));

                if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, _sectorLayer))
                {
                    //hitInfo.
                }
            }
        }
    }
}
