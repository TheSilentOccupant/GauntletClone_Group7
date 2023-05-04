using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpParent : MonoBehaviour
{
    protected virtual void OnInteraction()
    {

    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnInteraction();
        }
    }
}
