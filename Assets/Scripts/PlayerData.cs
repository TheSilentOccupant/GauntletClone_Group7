using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class PlayerData : MonoBehaviour
{
    /*
    public delegate void playerStatsChangedDelegate(PlayerTemplate classHolder);
    public event playerStatsChangedDelegate playerStatsChangedEvent;
    */

    public PlayerTemplate playerDataObject;

    [SerializeField]
    private ProfileUIManager _myProfileUIManager;
    [SerializeField]
    private PlayerAvatarController _myPlayerAvatarController;

    public bool playerReady;

    private void Start()
    {
        playerReady = false;
    }

    public void OnDataUpdate(PlayerTemplate classHolder)
    {
        Debug.Log("Stat Change");
        playerDataObject = classHolder;
        playerDataObject.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber + 2;
        Debug.Log(playerDataObject.PlayerNumber);
        _myProfileUIManager.PlayerStatsChangedSubscriber(playerDataObject);
        _myPlayerAvatarController.ClassChange(playerDataObject);
    }
}
