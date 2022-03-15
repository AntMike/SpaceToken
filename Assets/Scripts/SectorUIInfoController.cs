using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.UI
{
    public class SectorUIInfoController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        public void SetSectorData(int sectorId)
        {
            panel.SetActive(true);
        }

        public void HideSectorData()
        {
            panel.SetActive(false);
        }
    }
}
