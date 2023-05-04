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

    public PlayerTemplate PlayerDataObject;

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
<<<<<<< Updated upstream
        PlayerDataObject = classHolder;
        PlayerDataObject.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber + 1;
        Debug.Log(PlayerDataObject.PlayerNumber);
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<ProfileUIManager>().playerStatsChangedSubscriber(PlayerDataObject);
        //playerStatsChangedEvent();
        /*
        if (me != null)
        {
            playerStatsChangedEvent(me);
        }
        */
=======
        me = classHolder;
        me.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber + 2;
        Debug.Log(me.PlayerNumber);
        _myProfileUIManager.PlayerStatsChangedSubscriber(me);
        _myPlayerAvatarController.ClassChange(me);
>>>>>>> Stashed changes
    }
}
