using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpgradePotion : MonoBehaviour,IPickUp
{
    [SerializeField]
    private UpgradePotionTemplate _potion;

    private PlayerData _playerData;

    [SerializeField]
    private int _potionValue;
    [SerializeField]
    private GameObject primaryObject;
    [SerializeField]
    private GameObject secondaryObject;


    private void Start()
    {
        primaryObject.GetComponent<MeshRenderer>().material.color = _potion.PrimaryColor;
        secondaryObject.GetComponent<MeshRenderer>().material.color = _potion.SecondaryColor;
    }

    public void OnInteraction()
    {
        switch (_potion.PotionType)
        {
            case UpgradePotionType.Armor:
                _playerData.playerDataObject.Armor =+_potionValue;
                break;
            case UpgradePotionType.Magic:
                _playerData.playerDataObject.Magic =+_potionValue;
                break;
            case UpgradePotionType.Speed:
                _playerData.playerDataObject.Speed =+_potionValue;
                break;
            case UpgradePotionType.ShotSpeed:
                _playerData.playerDataObject.ShotSpeed =+_potionValue;
                break;
            case UpgradePotionType.ShotPower:
                _playerData.playerDataObject.ShotPower =+_potionValue;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerData = other.GetComponent<PlayerData>();
            OnInteraction();
        }
    }
}
