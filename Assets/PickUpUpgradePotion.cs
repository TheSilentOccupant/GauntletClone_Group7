using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpgradePotion : MonoBehaviour,IPickUp
{
    private UpgradePotionTemplate _potion;
    private PlayerData _playerData;

    [SerializeField]
    private int PotionValue;
    [SerializeField]
    private GameObject primaryObject;
    [SerializeField]
    private GameObject secodnaryObject;


    private void Start()
    {
        
    }

    public void OnInteraction()
    {
        switch (_potion.PotionType)
        {
            case PotionTypes.Armor:
                _playerData.playerDataObject.Armor =+ PotionValue;
                break;
            case PotionTypes.Magic:
                _playerData.playerDataObject.Magic =+ PotionValue;
                break;
            case PotionTypes.Speed:
                _playerData.playerDataObject.Speed =+ PotionValue;
                break;
            case PotionTypes.ShotSpeed:
                _playerData.playerDataObject.ShotSpeed =+ PotionValue;
                break;
            case PotionTypes.ShotPower:
                _playerData.playerDataObject.ShotPower =+ PotionValue;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerData = other.GetComponent<PlayerData>();
    }
}
