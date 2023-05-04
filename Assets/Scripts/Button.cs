using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, ISelectHandler
{
    public PlayerTemplate classHolder;

    [SerializeField]
    private PlayerData _myPlayerData;

    public void OnSelect(BaseEventData eventData)
    {
        _myPlayerData.OnDataUpdate(classHolder);
    }
}
