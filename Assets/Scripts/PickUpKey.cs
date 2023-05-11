using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour, IPickUp
{
    [SerializeField]
    private GameObject _doorHolder;

    [SerializeField]
    private GameObject _keyColorCode;

    private void Start()
    {
        _keyColorCode.GetComponent<MeshRenderer>().material.color = _doorHolder.GetComponent<MeshRenderer>().material.color;
    }

    public void OnInteraction()
    {
        _doorHolder.SetActive(false);
    }
}
