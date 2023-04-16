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

    public PlayerTemplate me;

    public void OnDataUpdate(PlayerTemplate classHolder)
    {
        Debug.Log("Stat Change");
        me = classHolder;
        me.PlayerNumber = this.gameObject.GetComponent<PlayerController>().playerIndexNumber;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<ProfileUIManager>().playerStatsChangedSubscriber(me);
        //playerStatsChangedEvent();
        /*
        if (me != null)
        {
            playerStatsChangedEvent(me);
        }
        */
    }
}
