using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.Galaxy.Sectors
{
    public class SectorsController : MonoBehaviour
    {
        [SerializeField] private List<MeshRenderer> sectorsMesh;
        [SerializeField] private MeshRenderer selectedSectorsMesh;


        [SerializeField] private Material constellationsAndLines;
        [SerializeField] private Material constellations;
        [SerializeField] private Material lines;
        [SerializeField] private Material empty;

        private bool _constellationsEnabled = true;
        private bool _linesEnabled = true;

        public void SwitchConstellations(int state)
        {
            _constellationsEnabled = state == 1;
            ApplyFilters();
        }

        public void SwitchLines(int state)
        {
            _linesEnabled = state == 1;
            ApplyFilters();
        }


        private void ApplyFilters()
        {
            Material mat;
            if (_linesEnabled)
            {
                mat = _constellationsEnabled ? constellationsAndLines : lines;
            }
            else
            {
                mat = _constellationsEnabled ? constellations : empty;
            }
            
            
            sectorsMesh.ForEach(x=> x.material = mat);
            selectedSectorsMesh.material = mat;
        }


    }
}
