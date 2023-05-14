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
                        /*
                    case InventoryItem.UpPotionArmor:
                        inventorySlotList[i].text = "Empty";
                        break;
                    case InventoryItem.UpPotionMagic:
                        break;
                    case InventoryItem.UpPotionShotPower:
                        break;
                    case InventoryItem.UpPotionShotSpeed:
                        break;
                    case InventoryItem.UpPotionSpeed:
                        break;
                    case InventoryItem.UpPotionFightPower:
                        break;
                        */
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
        //I was deffinitly not conflicted on how to implement the interactions
        /*
        if (other.tag == "UpPotion")
        {
            _playerData.OnHeal(100);
        }
        */
    }
}
