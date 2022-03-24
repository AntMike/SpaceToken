using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceToken.Galaxy.Sectors
{
    /// <summary>
    /// Parse JSON to this class
    /// </summary>
    [System.Serializable]
    public class SectorData
    {
        public string sectorName;
        public int planetsDiscovered;
        public int landsActive;
        public int creatureDiscovered;
        public int safarisAvailable;
        public int questsToComplete;
        public int activePlayers;
        [Range(0f,1f)]
        public float communityProgress;
    }
}
