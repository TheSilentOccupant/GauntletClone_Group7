using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject _exitPoint;

    
    public void OnInteraction(GameObject player)
    {
        player.gameObject.transform.position = _exitPoint.transform.position;
    }
    
}
