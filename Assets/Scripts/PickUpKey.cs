using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour, IPickUp
{
    public void OnInteraction()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerInventory>().OnPickUp(InventoryItem.Key))
            {
                OnInteraction();
            }
        }
    }
}
