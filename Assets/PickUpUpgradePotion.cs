using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpgradePotion : PickUpParent
{
    private UpgradePotionTemplate _potion;

    protected override void OnInteraction(PlayerData thisData)
    {
        switch (_potion.PotionType)
        {
            case PotionTypes.Armor:
                thisData.playerDataObject.Armor =+ 1;
                break;
            default:
                break;
        }
    }
}
