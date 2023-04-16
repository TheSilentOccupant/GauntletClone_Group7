using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, ISelectHandler
{
    public PlayerTemplate classHolder;
    public void OnSelect(BaseEventData eventData)
    {
        this.gameObject.transform.parent.parent.gameObject.GetComponent<PlayerData>().OnDataUpdate(classHolder);
    }
}
