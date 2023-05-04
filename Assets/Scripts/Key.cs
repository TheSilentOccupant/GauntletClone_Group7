using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameObject _doorHolder;

    [SerializeField]
    private GameObject _keyColorCode;

    private void Start()
    {
        _keyColorCode.GetComponent<MeshRenderer>().material.color = _doorHolder.GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _doorHolder.SetActive(false);
        }
    }
}
