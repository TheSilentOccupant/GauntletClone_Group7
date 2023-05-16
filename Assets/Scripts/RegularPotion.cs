using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularPotion : MonoBehaviour
{
    public RegularPotionType _potion;

    public void OnInteraction(PlayerData interactingPlayer)
    {
        switch (_potion)
        {
            case RegularPotionType.Orange:
                break;
            case RegularPotionType.Blue:
                GameManager.PotionActivation(interactingPlayer);
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
