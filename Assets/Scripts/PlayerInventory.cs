using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //public InventoryContainerTemplate inventoryData;

    [SerializeField]
    private PlayerData _playerData;

    [SerializeField]
    private GameObject _firstButton;

    public GameObject inventoryGameObject;

    public InventoryItem[] inventoryList;
    public Text[] inventorySlotList;

    public void OnDisplayInventory()
    {
        if (GameManager.isGameStarted)
        {
            if (inventoryGameObject.activeSelf)
            {

                this.gameObject.GetComponent<PlayerController>()._playerInputController.Player.Movement.Enable();
                this.gameObject.GetComponent<PlayerController>()._playerInputController.Player.Shoot.Enable();
                this.gameObject.GetComponent<PlayerController>()._playerInputController.UI.Disable();
                
                this.GetComponent<MultiplayerEventSystem>().sendNavigationEvents = false;
                //this.GetComponent<MultiplayerEventSystem>().SetSelectedGameObject(null);
                inventoryGameObject.SetActive(false);
            }
            else
            {
                inventoryGameObject.SetActive(true);
                this.gameObject.GetComponent<PlayerController>()._playerInputController.Player.Movement.Disable();
                this.gameObject.GetComponent<PlayerController>()._playerInputController.Player.Shoot.Disable();
                this.gameObject.GetComponent<PlayerController>()._playerInputController.UI.Enable();
                this.GetComponent<MultiplayerEventSystem>().firstSelectedGameObject = _firstButton;
                this.GetComponent<MultiplayerEventSystem>().SetSelectedGameObject(_firstButton);
                this.GetComponent<MultiplayerEventSystem>().sendNavigationEvents = true;
                for (int i = 0; i < inventorySlotList.Length; i++)
                {
                    switch (inventoryList[i])
                    {
                        case InventoryItem.Empty:
                            inventorySlotList[i].text = "Empty";
                            break;
                        case InventoryItem.RegPotionBlue:
                            inventorySlotList[i].text = "BluePotion";
                            break;
                        case InventoryItem.RegPotionOrange:
                            inventorySlotList[i].text = "OrangePotion";
                            break;
                        case InventoryItem.Key:
                            inventorySlotList[i].text = "Key";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }

    public void OnInteraction(int slotNumber)
    {
        switch (inventoryList[slotNumber])
        {
            case InventoryItem.Empty:
                break;
            case InventoryItem.RegPotionBlue:
                GameManager.PotionActivation(_playerData);
                inventoryList[slotNumber] = InventoryItem.Empty;
                break;
            case InventoryItem.RegPotionOrange:
                break;
            case InventoryItem.Key:
                break;
            default:
                break;
        }
    }

    public bool OnCheckKey()
    {
        for (int i = 0; i < inventoryList.Length; i++)
        {
            if (inventoryList[i] == InventoryItem.Key)
            {
                inventoryList[i] = InventoryItem.Empty;
                return true;
            }
        }
        return false;
    }

    public bool OnPickUp(InventoryItem item)
    {
        for (int i = 0; i < inventoryList.Length; i++)
        {
            if (inventoryList[i] == InventoryItem.Empty)
            {
                inventoryList[i] = item;
                return true;
            }
        }
        return false;
    }

    public void OnUpgradePotion(GameObject potion)
    {
        UpgradePotionType tempType = potion.GetComponent<PickUpUpgradePotion>().potion;
        int tempValue = potion.GetComponent<PickUpUpgradePotion>().potionValue;
        switch (tempType)
        {
            case UpgradePotionType.Armor:
                _playerData.playerDataObject.Armor += tempValue;
                break;
            case UpgradePotionType.Magic:
                _playerData.playerDataObject.Magic += tempValue;
                break;
            case UpgradePotionType.ShotPower:
                _playerData.playerDataObject.ShotPower += tempValue;
                break;
            case UpgradePotionType.ShotSpeed:
                _playerData.playerDataObject.ShotSpeed += tempValue;
                break;
            case UpgradePotionType.Speed:
                _playerData.playerDataObject.Speed += tempValue;
                break;
            case UpgradePotionType.FightPower:
                _playerData.playerDataObject.FightPower += tempValue;
                break;
            default:
                break;
        }
    }

    public void OnInteractionBehavior(GameObject other)
    {
        if (other.tag == "Key")
        {
            if (OnPickUp(InventoryItem.Key))
            {
                other.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.tag == "Food")
        {
            other.gameObject.SetActive(false);
            _playerData.OnHeal(100);
        }
        if (other.tag == "Treasure")
        {
            _playerData.OnScoreUp(100);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "RegPotion")
        {
            if (OnPickUp(InventoryItem.RegPotionBlue))
            {
                other.gameObject.SetActive(false);
            }
        }
        if (other.tag == "Door")
        {
            if (OnCheckKey())
                other.gameObject.SetActive(false);
        }
        if (other.tag == "UpPotion")
        {
            OnUpgradePotion(other.gameObject);
        }
    }
}
