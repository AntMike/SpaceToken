using System.Collections;
using System.Collections.Generic;
using SpaceToken.Galaxy.Sectors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceToken.UI
{
    public class SectorUIInfoController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Text sectorNameTxt;
        [SerializeField] private TMP_Text planetsDiscoveredTxt;
        [SerializeField] private TMP_Text landsActiveTxt;
        [SerializeField] private TMP_Text creatureDiscoveredTxt;
        [SerializeField] private TMP_Text safarisAvailableTxt;
        [SerializeField] private TMP_Text questsToCompleteTxt;
        [SerializeField] private TMP_Text activePlayersTxt;
        [SerializeField] private RectTransform communityProgressFill;

        public void SetSectorData(int sectorId, SectorData sectorData)
        {
            panel.SetActive(true);
            sectorNameTxt.text = sectorData.sectorName;
            planetsDiscoveredTxt.text = sectorData.planetsDiscovered.ToString();
            landsActiveTxt.text = sectorData.landsActive.ToString();
            creatureDiscoveredTxt.text = sectorData.creatureDiscovered.ToString();
            safarisAvailableTxt.text = sectorData.safarisAvailable.ToString();
            questsToCompleteTxt.text = sectorData.questsToComplete.ToString();
            activePlayersTxt.text = sectorData.activePlayers.ToString();
            communityProgressFill.anchorMax = new Vector2(sectorData.communityProgress, .99f);
        }

        public void HideSectorData()
        {
            panel.SetActive(false);
        }
    }
}
